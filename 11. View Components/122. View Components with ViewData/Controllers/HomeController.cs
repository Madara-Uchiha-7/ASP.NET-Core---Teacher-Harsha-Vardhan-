using Microsoft.AspNetCore.Mvc;

namespace _122._View_Components_with_ViewData.Controllers
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
