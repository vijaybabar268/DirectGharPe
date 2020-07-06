using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DirectGharPe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = new CommonViewModel()
            {
                Categories = _context.Categories.Where(c => c.ParentId == 0).ToList(),
                Title = null
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}