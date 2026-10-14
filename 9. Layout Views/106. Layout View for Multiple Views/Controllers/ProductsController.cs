using Microsoft.AspNetCore.Mvc;

namespace _106._Layout_View_for_Multiple_Views.Controllers
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
