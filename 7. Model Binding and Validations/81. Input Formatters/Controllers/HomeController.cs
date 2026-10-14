using Microsoft.AspNetCore.Mvc;
using _81._Input_Formatters.Models;
using _81._Input_Formatters.CustomModelBinders;

namespace _81._Input_Formatters.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index([FromBody] Person person)
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
