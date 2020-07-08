using DirectGharPe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectGharPe.Areas.Admin.Data
{
    public static class Seed
    {                
        public static void Data(ApplicationDbContext _context)
        {
            try
            {
                // Import Product data.
                if (!_context.Products.Any())
                {
                    var productData =
                        System.IO.File.ReadAllText("D:\\Work\\Projects\\DirectGharPe\\DirectGharPe\\DirectGharPe\\Areas\\Admin\\Data\\Products\\Products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        product.IsActive = true;
                        product.Slug = product.Name.Trim().ToLower().Replace(' ', '-');
                        product.DateAdded = DateTime.Now;

                        _context.Products.Add(product);
                    }

                    _context.SaveChanges();
                }

                // Import category data.
                if (!_context.Categories.Any())
                {
                    var categoryData =
                        System.IO.File.ReadAllText("D:\\Work\\Projects\\DirectGharPe\\DirectGharPe\\DirectGharPe\\Areas\\Admin\\Data\\Products\\ProductCategories.json");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);

                    foreach (var category in categories)
                    {
                        category.IsActive = true;
                        _context.Categories.Add(category);
                    }

                    _context.SaveChanges();
                }

                // Import brand data.
                if (!_context.Brands.Any())
                {
                    var brandsData =
                        System.IO.File.ReadAllText("D:\\Work\\Projects\\DirectGharPe\\DirectGharPe\\DirectGharPe\\Areas\\Admin\\Data\\Products\\ProductBrands.json");
                    var brands = JsonConvert.DeserializeObject<List<Brand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        brand.IsActive = true;
                        _context.Brands.Add(brand);
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }                                               
        }
    }
}