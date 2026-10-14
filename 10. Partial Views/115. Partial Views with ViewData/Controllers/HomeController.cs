using Microsoft.AspNetCore.Mvc;

namespace _115._Partial_Views_with_ViewData.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Citites";
            ViewData["ListItems"] = new List<string>() { "Paris", "New York", "New Mumbai", "Rome" };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["ListTitle"] = "Citites";
            ViewData["ListItems"] = new List<string>() { "Paris", "New York", "New Mumbai", "Rome" };
            return View();
        }
    }
}
