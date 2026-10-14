using Microsoft.AspNetCore.Mvc;

namespace _105._Creating_Layout_View___2.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-products")]
        public IActionResult Search()
        {
            return View();
        }

        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
