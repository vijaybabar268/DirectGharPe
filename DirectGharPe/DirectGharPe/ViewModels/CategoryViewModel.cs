using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> ProductSubCategories { get; set; }
        public IEnumerable<Brand> ProductBrands { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }    
        public string Title { get; set; }   
    }
}