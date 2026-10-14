using Microsoft.AspNetCore.Mvc;

namespace _109._Dynamic_Layout_View.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-products/{ProductID?}")]
        public IActionResult Search(int? productID)
        {
            ViewBag.ProductID = productID;
            return View();
        }

        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
