using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> MainCategory { get; set; }
        public IEnumerable<Product> topSellerElectronics { get; set; }
        public IEnumerable<Product> topSellerCloating { get; set; }
        public IEnumerable<Product> topSellerJewellery { get; set; }
        public IEnumerable<Product> topSellerFashion { get; set; }
        public IEnumerable<Product> mostPopular { get; set; }
    }
}