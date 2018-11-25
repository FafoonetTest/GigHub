using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class AttendanceRepository : Repository
    {

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.Datetime > DateTime.Now)
                .ToList();
        }

        public bool IsGigAttendant(int gigId, string attendant)
        {
            return _context.Attendances.Any(x => x.GigId == gigId && x.AttendeeId == attendant);
        }

        public void Create(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public bool RemoveByGigAndAttendee(int gigId, string attendeeId)
        {
            var attendance = _context.Attendances
                .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == attendeeId);

            if (attendance == null)
                return false;

            Remove(attendance);
            return true;
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
        }
    }
}