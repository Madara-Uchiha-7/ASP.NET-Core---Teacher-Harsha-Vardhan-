using Microsoft.AspNetCore.Mvc;

namespace _144._Environment_in_Launch_Settings.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }


        //[Route("/")]
        //public IActionResult Dummy()
        //{
        //    return View();

        //}
    }
}
