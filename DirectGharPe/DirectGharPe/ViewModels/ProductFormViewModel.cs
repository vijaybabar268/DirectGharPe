using DirectGharPe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectGharPe.ViewModels
{
    public class ProductFormViewModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal? Price { get; set; }
        
        public byte? Quantity { get; set; }
        
        public int Category { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
        
        public int Brand { get; set; }
        
        public IEnumerable<Brand> Brands { get; set; }

        public string Slug 
        {
            get
            {
                return Name.Trim().ToLower().Replace(' ', '-');
            }
        }
    }
}