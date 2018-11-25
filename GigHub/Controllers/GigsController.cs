using GigHub.Models;
using GigHub.Repositories;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly AttendanceRepository _attendanceRepository;
        private readonly GigRepository _gigRepository;
        private readonly GenreRepository _genreRepository;

        public GigsController()
        {
            _attendanceRepository= new AttendanceRepository();
            _gigRepository = new GigRepository();
            _genreRepository = new GenreRepository();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var gigs = _gigRepository.GetFutureArtistGigs(User.Identity.GetUserId());

            return View(gigs);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = _gigRepository.GetGigsUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending",
                Attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.GigId)
            };

            return View("Gigs", viewModel);
        }
        
        [HttpPost]
        public ActionResult Search(GigsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new {query = viewModel.SearchTerm});
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _genreRepository.GetAll(),
                Heading = "Add a Gig"
            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // voir aussi la view
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _genreRepository.GetAll();
                return View("GigForm", viewModel);       //refus de la validation si la validation n'est pas valide
            }                
                

            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(), // récupération de l'id de l'utilisateur connecté
                Datetime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _gigRepository.Create(gig);

            return RedirectToAction("Mine", "Gigs");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var gig = _gigRepository.Get(id);

            if (gig == null)
                return HttpNotFound();

            if(gig.ArtistId != User.Identity.GetUserId())
                return  new HttpUnauthorizedResult();

            var viewModel = new GigFormViewModel
            {
                Heading = "Edit a Gig",
                Id     = gig.Id,
                Genres = _genreRepository.GetAll(),
                Date   = gig.Datetime.ToString("dd/MM/yyyy"),
                Time   = gig.Datetime.ToString("HH:mm"),
                Genre  = gig.GenreId,
                Venue  = gig.Venue
            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // voir aussi la view
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _genreRepository.GetAll();
                return View("GigForm", viewModel);       //refus de la validation si la validation n'est pas valide
            }


            var gig = _gigRepository.GetGigWithAttendees(viewModel.Id);

            if (gig == null)
                return HttpNotFound();

            if(gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _gigRepository.Complete();

            return RedirectToAction("Mine", "Gigs");
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            
            var gig = _gigRepository.GetWithFollowersAndAttendances(id);

            if (gig == null)
                return HttpNotFound();
            
            var viewModel = new GigDetailViewModel
                {
                    Id = gig.Id,
                    Venue = gig.Venue,
                    DateTime = gig.Datetime,
                    ArtistId = gig.ArtistId,
                    ArtistName = gig.Artist.Name,
                    Attending = gig.Attendances.Any(a => a.AttendeeId == userId),
                    Following = gig.Artist.Followers.Any(a => a.FollowerId == userId)
            };
            
            return View("Details", viewModel);
        }
    }
}