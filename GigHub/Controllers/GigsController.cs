using GigHub.Models;
using GigHub.ViewModels;
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
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new GigFormViewModel
            {
                Genres = genres
            };

            return View(viewModel);
        }
    }
}