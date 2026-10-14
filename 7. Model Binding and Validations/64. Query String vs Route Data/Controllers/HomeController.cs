using Microsoft.AspNetCore.Mvc;

namespace _64._Query_String_vs_Route_Data.Controllers
{
    public class HomeController : Controller
    {
        // We can pass the parameters to our action method to get the query string parameter.
        // E.g. we have added the int bookId. So you can assume that asp.net core automatically supplies the
        // values for this parameter that are retrieved from the model binding. But always the model binding executes
        // in the same order. But at the fourth position, there is a source called query string parameters.
        // That means probably this parameter can pick up the value from the query string.
        // So let's execute this application with "/bookstore?bookId=1&isLoggedIn=true".
        // If value is not supplied then to accept the null values add the ? after the datatype.
        // You can check using .HasValue in the if condition if the parameter had a value or not.
        [Route("bookstore")]
        public IActionResult Index(int? bookId, bool? isLoggedIn)
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

// if (!isLoggedIn) is not going to work, so we have used isLoggedIn == false
// Why: because bool? can accept null, true and false. But bool can not accept null, it can accept
// only true and false. So,
// We can not do !isLoggedIn becuase it can make true to false and false to true but it can not do
// anything to null.

// IMP Difference:

// Above was Query String Parameters
// approch. In that we pass url like : "/bookstore?bookId=1&isLoggedIn=true" and use 
// paramters in the action method to get them.

// Lets see the Route data way, This has more priority than Query String Parameters.
// Here also we will use the parameters in the Action method. 
// You can get the route data by adding the bookId and isLoggedIn values in the route parameters:
// [Route("bookstore/{bookId?}/{isLoggedIn?}")]
// Notice how we have made them optional by adding the ? in the end.
// URl will look like : "/bookstore/1/true" for the Route Data. 

// We can also pass ulr like: "/bookstore/1/false?bookId=1&isLoggedIn=true
// This means we are passing both i.e. Route data and Query String Parameters.
// But Model binding will pick only "/bookstore/1/false" because Route data has more priority
// and we havde added the route Parameters in the Route Attribute to get the
// Route Data, with the Parameters in the action method
// so that we do not need to use "ControllerContext.HttpContext.Request.Query["bookid"]" or
// "Request.Query.ContainsKey("bookid")" lengthy statements to get the data.
// If any specific parameter is not present in the Route Data then Model biding will check if 
// it is present in the Query String Parameters and it will be available in Parameter of the action method.