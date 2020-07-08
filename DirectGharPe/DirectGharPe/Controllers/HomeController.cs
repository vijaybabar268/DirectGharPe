using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System.Data.Entity;
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
            var viewModel = new HomeViewModel()
            {                
                topSellerElectronics = _context.Products
                                        .Where(c => c.CategoryId == 1).Take(4).ToList(),

                topSellerCloating = _context.Products.Where(c => c.CategoryId == 2).Take(4)
                                        .Include(p => p.Photo).ToList(),

                topSellerJewellery = _context.Products.Where(c => c.CategoryId == 3).Take(4)
                                        .Include(p => p.Photo).ToList(),

                topSellerFashion = _context.Products.Where(c => c.CategoryId == 4).Take(4)
                                        .Include(p => p.Photo).ToList(),

                mostPopular = _context.Products.Where(c => c.CategoryId == 1).Take(4)
                                    .Include(p => p.Photo).ToList(),
            };

            Session["MainCategory"] = _context.Categories.Where(c => c.ParentId == 0).ToList();

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