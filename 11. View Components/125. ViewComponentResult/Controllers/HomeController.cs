using _125._ViewComponentResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace _125._ViewComponentResult.Controllers
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

        [Route("friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Friends",
                people = new List<Person>() {
                    new Person()
                    {
                        JobTitle = "Senior Software Developer",
                        Name = "Chinmay"
                    },
                    new Person()
                    {
                        JobTitle = "Senior Software Designer",
                        Name = "Bhav khau Kapil"
                    }
                }
            };
            return ViewComponent("Grid", new
            {
                viewPersonGridModel = personGridModel
            });
        }
    }
}
