using System.Web.Mvc;

namespace DirectGharPe.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return Content("Hello from Product controller admin panel.");
        }
    }
}