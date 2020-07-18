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
                                        .Where(c => c.CategoryId == 20).Take(4)
                                        .Include(x=>x.Photo)
                                        .ToList(),

                topSellerCloating = _context.Products.Where(c => c.CategoryId == 20).Take(4)
                                        .Include(p => p.Photo)
                                        .ToList(),

                topSellerJewellery = _context.Products.Where(c => c.CategoryId == 20).Take(4)
                                        .Include(p => p.Photo)
                                        .ToList(),

                topSellerFashion = _context.Products.Where(c => c.CategoryId == 20).Take(4)
                                        .Include(p => p.Photo)
                                        .ToList(),

                mostPopular = _context.Products.Where(c => c.CategoryId == 20).Take(4)
                                    .Include(p => p.Photo)
                                    .ToList(),
            };

            Session["MainCategory"] = _context.Categories.Where(c=> c.IsActive && c.ParentId == 0).ToList();

            return View(viewModel);
        }    
        
        public ActionResult MyOrders(string id)
        {
            return View();
        }

        public ActionResult MyProfile(string id)
        {
            return View();
        }
    }
}