using Microsoft.AspNetCore.Mvc;

namespace _106._Layout_View_for_Multiple_Views.Controllers
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
