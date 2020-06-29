using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System;
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

        public ActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
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

        [HttpPost]
        public ActionResult Create(ProductFormViewModel viewModel)
        {            
            var product = new Product()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Slug = viewModel.Slug,
                IsActive = true,
                DateAdded = DateTime.Now,
                CategoryId = viewModel.Category,
                BrandId = viewModel.Brand
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}