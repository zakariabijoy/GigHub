using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.Date > DateTime.Now)
                .ToList();
        }

        public bool? GetAttendances(int gigId, string userId)
        {
            return _context.Attendances
                   .Any(a => a.GigId == gigId && a.AttendeeId == userId);
        }
    }
}