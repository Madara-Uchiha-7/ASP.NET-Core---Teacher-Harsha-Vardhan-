using _117._PartialViewResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace _117._PartialViewResult.Controllers
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

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModels = new ListModel()
            { 
                ListTitle = "Programming Languages",
                ListItems = new List<string>()
                {
                    "Python",
                    "PHP",
                    "JavaScript"
                }
            };

            return PartialView("_ListPartialView", listModels);
        }
    }
}
