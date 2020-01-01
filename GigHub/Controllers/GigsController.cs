using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context =new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new GigFormViewModel
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                Venue = viewModel.Venue,
                Date = viewModel.GetDateTime(),
                GenreId = viewModel.Genre

            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}