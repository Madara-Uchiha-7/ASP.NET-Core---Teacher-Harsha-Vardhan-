using Microsoft.AspNetCore.Mvc;

namespace _114._Creating_Partial_Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
