using GigHub.Dtos;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private FollowingRepository _followingRepository;

        public FollowingsController()
        {
            _followingRepository = new FollowingRepository();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_followingRepository.Exists(userId, dto.FolloweeId))
                return BadRequest("Attendance already exists.");

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _followingRepository.Create(following);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var following = _followingRepository.Get(User.Identity.GetUserId(), id);

            if (following == null)
                return NotFound();
            
            _followingRepository.Remove(following);

            return Ok(id);
        }
    }
}
