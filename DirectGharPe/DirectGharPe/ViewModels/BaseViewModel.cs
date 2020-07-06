using DirectGharPe.Models;
using System.Collections.Generic;

namespace DirectGharPe.ViewModels
{
    public class BaseViewModel
    {
        public IEnumerable<Category> MainCategory { get; set; }
    }
}