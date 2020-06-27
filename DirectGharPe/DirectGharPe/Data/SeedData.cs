using DirectGharPe.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DirectGharPe.Data
{
    public static class Seed
    {                
        public static void Data(ApplicationDbContext _context)
        {
            // Import category data.
            if (!_context.Categories.Any())
            {
                var categoryData =
                    System.IO.File.ReadAllText("D:\\Work\\Projects\\DirectGharPe\\DirectGharPe\\DirectGharPe\\Data\\Products\\ProductCategories.json");
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
                    System.IO.File.ReadAllText("D:\\Work\\Projects\\DirectGharPe\\DirectGharPe\\DirectGharPe\\Data\\Products\\ProductBrands.json");
                var brands = JsonConvert.DeserializeObject<List<Brand>>(brandsData);

                foreach (var brand in brands)
                {
                    brand.IsActive = true;
                    _context.Brands.Add(brand);
                }

                _context.SaveChanges();
            }                        
        }
    }
}