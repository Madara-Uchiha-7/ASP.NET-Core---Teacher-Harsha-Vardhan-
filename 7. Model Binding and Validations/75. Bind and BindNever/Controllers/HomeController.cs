using Microsoft.AspNetCore.Mvc;
using _75._Bind_and_BindNever.Models;

namespace _75._Bind_and_BindNever.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(
            [Bind(
            nameof(Person.Name),
            nameof(Person.Password),
            nameof(Person.ConfirmPassword)
            )]
            Person person)
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
