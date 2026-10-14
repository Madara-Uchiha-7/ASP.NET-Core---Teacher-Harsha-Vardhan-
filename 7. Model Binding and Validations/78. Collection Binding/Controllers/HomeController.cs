using Microsoft.AspNetCore.Mvc;
using _78._Collection_Binding.Models;
using _78._Collection_Binding.CustomModelBinders;

namespace _78._Collection_Binding.Controllers
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
