using Microsoft.AspNetCore.Mvc;
using _76._Custom_Model_Binders.Models;
using _76._Custom_Model_Binders.CustomModelBinders;

namespace _76._Custom_Model_Binders.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(
            [ModelBinder(BinderType = typeof(PersonModelBinder))]
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
