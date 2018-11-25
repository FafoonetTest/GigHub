using GigHub.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    [System.Web.Http.Authorize]
    public class FolloweesController : Controller
    {
        private FollowingRepository _followingRepository;

        public FolloweesController()
        {
            _followingRepository = new FollowingRepository();
        }

        [System.Web.Http.HttpPost]
        public ActionResult Index()
        {
            var artists = _followingRepository.GetFollowers(User.Identity.GetUserId());

            return View(artists);
        }
    }
}
