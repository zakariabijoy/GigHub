using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class ArtistController : Controller
    {
        private ApplicationDbContext _context;

        public ArtistController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(a=>a.Followee);

            var viewModel = new ArtistViewModel()
            {
                FollowingArtist = artists
            };

            return View(viewModel);
        }
    }

    public class ArtistViewModel
    {
        public IEnumerable<ApplicationUser> FollowingArtist { get; set; }   
    }
}