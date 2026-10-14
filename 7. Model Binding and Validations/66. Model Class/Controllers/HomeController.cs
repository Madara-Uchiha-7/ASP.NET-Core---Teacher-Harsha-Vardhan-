using Microsoft.AspNetCore.Mvc;
using _66._Model_Class.Models;

// Model Binding will creates an object of the Book automatically, So then it fills up all
// the values from the route data or query string where the route
// data has more priority and will put it in the Properties of Book class.
// Again like last time as we saw many times, model binding will give the null value if value is not present in the
// url.
// So it is our responsibility to check if the value is present or not.
// Remember that Model class property names are not case-sensitive in terms of model
// binding. Same as last time, this Model will pick the value from Route Data if not present there then
// it will check if it is present in the Query String Parameter.
// If you do [FromQuery] Book book, then this will be applied on the entire Book Object. Other rules are
// same as we learned in the last lecture.
// If you want to have the [FromQuery] or [FromRoute] to specific property of the book class then 
// then goto that model class -> Above that property -> add [FromQuery] or [FromRoute].
// In such case, in that file you need to add Using Microsoft.AspnetCore.Mvc;
//
// If you are using the PostMan then you can use the same url way which we are using in browser or
// we can also pass the Query String Parameters in Params tab.
namespace _66._Model_Class.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId?}/{isLoggedIn?}")]
        public IActionResult Index(
            [FromRoute]int? bookId,
            [FromQuery] bool? isLoggedIn,
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
            if (isLoggedIn == false) // if (!isLoggedIn) is not going to work
            {
                return Unauthorized("User must login.");
            } 
            // {book} will call ToString which we have overriden. 
            return Content($"All good! {book}", "text/plain");
        }
    }
}
