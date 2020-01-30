using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool? GetFollowing(string artistId, string userId)
        {
           return _context.Followings
                        .Any(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }
    }
}