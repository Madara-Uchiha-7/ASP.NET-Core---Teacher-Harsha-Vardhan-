using Microsoft.AspNetCore.Mvc;
using _73._Custom_Validation_with_Multiple_Properties.Models;

namespace _73._Custom_Validation_with_Multiple_Properties.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(string.Join("\n", errors));
            }
            return Content($"{person}");
        }
    }
}
