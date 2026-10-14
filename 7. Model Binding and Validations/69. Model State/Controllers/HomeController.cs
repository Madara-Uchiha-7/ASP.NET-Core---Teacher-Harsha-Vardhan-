using Microsoft.AspNetCore.Mvc;
using _69._Model_State.Models;

namespace _68._Introduction_to_Model_Validations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                // The ModelState.Values will have each property of the Model class.
                // If any property of the model has the error present then we will 
                // iterate through the collection of the Errors for that perticular property.
                // Because for one property of the model class, there can be more than one error present.
                // In case of no validation errors for perticular property, .Errors will be empty.
                var errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(string.Join("\n", errors));

                // We can write the above C# code in LINQ:
                string errorMessages = string.Join(
                    "\n",
                    ModelState.Values.
                    SelectMany(value => value.Errors).
                    Select(err => err.ErrorMessage));

            }
            return Content($"{person}");
        }
    }
}
