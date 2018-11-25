using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowingRepository : Repository
    {
        
        public IEnumerable<ApplicationUser> GetFollowers(string followerId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == followerId)
                .Select(f => f.Followee)
                .ToList();
        }

        public Following Get(string followerId, string folleweeId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == folleweeId && f.FollowerId == followerId);
        }

        public bool Exists(string followerId, string folleweeId)
        {
            return _context.Followings.Any(x => x.FollowerId == followerId && x.FolloweeId == folleweeId);
        }

        public void Create(Following following)
        {
            _context.Followings.Add(following);
            _context.SaveChanges();
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
            _context.SaveChanges();
        }
    }
}