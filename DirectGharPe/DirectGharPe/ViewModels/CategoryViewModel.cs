using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
    }
}