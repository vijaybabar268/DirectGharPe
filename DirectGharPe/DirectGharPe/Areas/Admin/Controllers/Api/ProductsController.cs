﻿using DirectGharPe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace DirectGharPe.Areas.Admin.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Product> Products()
        {
            var products = _context.Products
                .Include(c => c.Category)
                .Include(b => b.Brand)
                .Include(p => p.Photo)
                .ToList();

            return products;
        }

        [HttpGet]
        public Product Product(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            return product;
        }

        [Route("Api/Products/ProductByCategory/{id}")]
        [HttpGet]
        public IEnumerable<Product> ProductByCategory(int id)
        {
            var categoryProduct = _context.Products
                .Where(p => p.IsActive && p.CategoryId == id)
                .ToList();

            return categoryProduct;
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            product.Slug = product.Name.Trim().ToLower().Replace(' ', '-');
            product.IsActive = true;
            product.DateAdded = DateTime.Now;
            
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            var productInDb = _context.Products.FirstOrDefault(p => p.Id == id);

            if (productInDb == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.PriceBefore = product.PriceBefore;
            productInDb.Discount = product.Discount;
            productInDb.Price = product.Price;
            productInDb.Save = product.Save;
            productInDb.Quantity = product.Quantity;
            productInDb.Slug = product.Name.Trim().ToLower().Replace(' ', '-');
            productInDb.IsActive = product.IsActive;
            product.DateModified = DateTime.Now;
            productInDb.CategoryId = product.CategoryId;
            productInDb.BrandId = product.BrandId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
