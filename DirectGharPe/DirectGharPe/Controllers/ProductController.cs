using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DirectGharPe.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Category(string id, string name)
        {            
            var viewModel = new CommonViewModel()
            {
                Categories = _context.Categories.Where(c => c.ParentId == 0).ToList(),
                Title = name                
            };

            return View(viewModel);                        
        }

        public ActionResult Detail(string id)
        {
            var viewModel = new CommonViewModel()
            {
                Categories = _context.Categories.Where(c => c.ParentId == 0).ToList(),
                Title = "Product Detail"
            };

            return View(viewModel);
        }
    }
}