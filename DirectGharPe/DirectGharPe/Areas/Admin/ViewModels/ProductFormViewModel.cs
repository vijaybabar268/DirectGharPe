using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.Areas.Admin.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public decimal? PriceBefore { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Price { get; set; }

        public decimal? Save { get; set; }

        public byte? Quantity { get; set; }
        
        public int Category { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
        
        public int? Brand { get; set; }
        
        public IEnumerable<Brand> Brands { get; set; }

        public string Slug 
        {
            get
            {
                return Name.Trim().ToLower().Replace(' ', '-');
            }
        }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Product" : "Edit Product";
            }
        }
    }
}