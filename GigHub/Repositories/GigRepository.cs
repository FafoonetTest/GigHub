using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class GigRepository : Repository
    {
        public Gig Get(int id)
        {
            return _context.Gigs.SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(x => x.AttendeeId == userId)
                .Select(y => y.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAttendees(int id)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetFutureArtistGigs(string artistId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == artistId && g.Datetime > DateTime.Now && !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetWithFollowersAndAttendances(int id)
        {
            return _context.Gigs
                .Include(g => g.Artist.Followers)
                .Include(g => g.Attendances)
                .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetUpcomingGigs()
        {
            return _context.Gigs
                .Include(x => x.Artist)
                .Include(x => x.Genre)
                .Where(x => x.Datetime > DateTime.Now && !x.IsCanceled);
        }
        
        public int Create(Gig gig)
        {
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return gig.Id;
        }
    }
}