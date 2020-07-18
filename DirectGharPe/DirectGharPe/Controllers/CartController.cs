using System.Web.Mvc;

namespace DirectGharPe.Controllers
{
    public class CartController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(string id, string name, string price, string quantity, string action)
        {
            return Content("Added to Cart");
        }

        public ActionResult BuyNow()
        {
            return View();
        }

    }
}