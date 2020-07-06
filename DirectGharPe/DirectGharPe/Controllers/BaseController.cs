using DirectGharPe.Models;
using DirectGharPe.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DirectGharPe.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var model = filterContext.Controller.ViewData.Model as BaseViewModel;

            model.MainCategory = _context.Categories.Where(c => c.ParentId == 0).ToList();                            
        }
    }
}