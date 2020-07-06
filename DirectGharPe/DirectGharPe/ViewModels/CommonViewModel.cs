using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class CommonViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
    }
}