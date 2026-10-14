using Microsoft.AspNetCore.Mvc;

namespace _107._ViewData_in_Layout_Views.Controllers
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
