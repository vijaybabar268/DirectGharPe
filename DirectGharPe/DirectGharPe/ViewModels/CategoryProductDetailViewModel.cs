using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class CategoryProductDetailViewModel
    {
        public IEnumerable<Product> SimilarProducts { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
    }
}