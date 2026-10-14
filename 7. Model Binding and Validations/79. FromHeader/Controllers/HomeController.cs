using Microsoft.AspNetCore.Mvc;
using _79._FromHeader.Models;
using _79._FromHeader.CustomModelBinders;

namespace _79._FromHeader.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
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
            return Content($"{person} : {UserAgent}");
        }
    }
}
