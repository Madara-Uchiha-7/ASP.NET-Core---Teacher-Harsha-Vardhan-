using Microsoft.AspNetCore.Mvc;

namespace _65._FromQuery_and_FromRoute.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId?}/{isLoggedIn?}")]
        public IActionResult Index([FromRoute]int? bookId,[FromQuery] bool? isLoggedIn)
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
            if (isLoggedIn == false) // if (!isLoggedIn) is not going to work
            {
                return Unauthorized("User must login.");
            } 
            return Content("All good!", "text/plain");
        }
    }
}

// If we are using [FromRoute] and the data is not present in the Route Data then
// that value will not be taken from Query String Parameter i.e. from "?bookId=10/..." will not be taken
// even if it is present in the URL as a Query String Parameter.