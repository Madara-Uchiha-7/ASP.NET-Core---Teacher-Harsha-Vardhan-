using Microsoft.AspNetCore.Mvc;
using _68._Introduction_to_Model_Validations.Models;

namespace _68._Introduction_to_Model_Validations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            return Content($"{person}");
        }
    }
}
