using Microsoft.AspNetCore.Mvc;

namespace _110._Layout_Views_Sections.Controllers
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
