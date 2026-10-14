using Microsoft.AspNetCore.Mvc;

namespace _85._Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
