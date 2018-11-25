using GigHub.Dtos;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendancesController()
        {
            _attendanceRepository = new AttendanceRepository();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_attendanceRepository.IsGigAttendant(dto.GigId, userId))
                return BadRequest("Attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _attendanceRepository.Create(attendance);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            if (!_attendanceRepository.RemoveByGigAndAttendee(id, User.Identity.GetUserId()))
                return NotFound();
            
            return Ok(id);
        }
    }
}
