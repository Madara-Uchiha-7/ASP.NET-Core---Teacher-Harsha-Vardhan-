using Microsoft.AspNetCore.Mvc;

namespace _107._ViewData_in_Layout_Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about-company")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact-support")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
