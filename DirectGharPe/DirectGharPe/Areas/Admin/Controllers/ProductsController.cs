﻿using DirectGharPe.Areas.Admin.ViewModels;
using DirectGharPe.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DirectGharPe.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {            
            return View();
        }
        
        public ActionResult New()
        {
            var viewModel = new ProductFormViewModel()
            {
                Categories = _context.Categories.Where(c => c.IsActive == true).ToList(),
                Brands = _context.Brands.Where(c => c.IsActive == true).ToList()
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                var product = new Product()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    PriceBefore = viewModel.PriceBefore,
                    Discount = viewModel.Discount,
                    Price = viewModel.Price,
                    Save = viewModel.Save,
                    Quantity = viewModel.Quantity,
                    Slug = viewModel.Slug,
                    IsActive = true,
                    DateAdded = DateTime.Now,
                    CategoryId = viewModel.Category,
                    BrandId = viewModel.Brand
                };

                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.FirstOrDefault(p => p.Id == viewModel.Id);

                if (productInDb == null)
                    return HttpNotFound();

                productInDb.Name = viewModel.Name;
                productInDb.Description = viewModel.Description;
                productInDb.PriceBefore = viewModel.PriceBefore;
                productInDb.Discount = viewModel.Discount;
                productInDb.Price = viewModel.Price;
                productInDb.Save = viewModel.Save;
                productInDb.Quantity = viewModel.Quantity;
                productInDb.Slug = viewModel.Slug;
                productInDb.DateModified = DateTime.Now;
                productInDb.CategoryId = viewModel.Category;
                productInDb.BrandId = viewModel.Brand;
            }
                        
            _context.SaveChanges();                        

            return RedirectToAction("Index", "Products");
        }

        public ActionResult ToggleStatus(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            if (product.IsActive)
                product.IsActive = false;
            else
                product.IsActive = true;

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
                
        public ActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                PriceBefore = product.PriceBefore,
                Discount = product.Discount,
                Price = product.Price,
                Save = product.Save,
                Quantity = product.Quantity,                
                Categories = _context.Categories.Where(c => c.IsActive == true).ToList(),
                Brands = _context.Brands.Where(c => c.IsActive == true).ToList(),
                Category = product.CategoryId,
                Brand = product.BrandId                
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}