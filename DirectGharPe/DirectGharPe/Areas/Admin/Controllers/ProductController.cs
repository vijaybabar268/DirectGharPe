using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DirectGharPe.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel()
            {
                Categories = _context.Categories.ToList(),
                Brands = _context.Brands.ToList()
            };

            return View(viewModel);
        }
    }
}