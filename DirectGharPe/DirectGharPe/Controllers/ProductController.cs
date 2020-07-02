using System.Web.Mvc;

namespace DirectGharPe.Controllers
{
    public class ProductController : Controller
    {        
        public ActionResult Category(string id, string name)
        {
            ViewBag.CategoryName = name;

            return View();
        }

        public ActionResult Detail(string id)
        {
            return View();
        }
    }
}