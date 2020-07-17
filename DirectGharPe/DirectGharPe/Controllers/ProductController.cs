using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System;
using System.Data.Entity;
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
            byte parentCatId = Byte.Parse(id);
            var childCatId = _context.Categories.Where(c => c.IsActive && c.ParentId == parentCatId).Select(s => s.Id);

            var viewModel = new CategoryViewModel()
            {
                FilterListings = _context.Products.Where(c => c.IsActive && c.Price != null && childCatId.Contains(c.CategoryId))
                                .Include(p => p.Photo)
                                .ToList(),

                ProductSubCategories = _context.Categories.Where(c => c.ParentId == parentCatId).ToList(),
                ProductBrands = _context.Brands.Where(b => b.ParentId == parentCatId).ToList(),
                CategoryId = id,
                CategoryName = name                
            };

            Session["MainCategory"] = _context.Categories.Where(c => c.IsActive && c.ParentId == 0).ToList();

            return View(viewModel);                        
        }

        public ActionResult Detail(string id)
        {
            var viewModel = new CategoryViewModel()
            {                
                Title = "Product Detail"
            };

            return View(viewModel);
        }
    }
}