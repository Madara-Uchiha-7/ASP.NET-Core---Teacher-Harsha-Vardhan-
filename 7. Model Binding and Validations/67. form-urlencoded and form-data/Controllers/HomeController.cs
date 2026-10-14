using Microsoft.AspNetCore.Mvc;
using _67._form_urlencoded_and_form_data.Models;

namespace _67._form_urlencoded_and_form_data.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId?}/{isLoggedIn?}")]
        public IActionResult Index(
            [FromRoute]int? bookId,
            [FromRoute] bool? isLoggedIn,
            Book book)
        {
            if (!bookId.HasValue)
            {
                return NotFound("Book Id can not be null.");
            }
            if (bookId <= 0)
            {
                return BadRequest("Bool Id can not be less than 0.");
            }
            else if (bookId > 1000)
            {
                return BadRequest("Bool Id can not be greater than 1000.");
            }
            if (isLoggedIn == false) 
            {
                return Unauthorized("User must login.");
            }  

            return Content($"All good! {book}", "text/plain");
        }
    }
}
