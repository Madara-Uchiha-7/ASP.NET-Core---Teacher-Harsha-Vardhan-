using Microsoft.AspNetCore.Mvc;
using _59._Redirect_Results___Part_1.Models;
using _59._Redirect_Results___Part_1.Controllers;


namespace _59._Redirect_Results___Part_1
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            // Check if requests contains the bookid in the url.
            if (!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Book Id is not supplied.");
            }
            // bookid can not be empty.
            else if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return NotFound("Book Id can not be null.");
            }

            // bookid must me in 1 - 1000
            // Below is the actual way to access the request object.
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0)
            {
                return BadRequest("Bool Id can not be less than 0.");
            }
            else if (bookId > 1000)
            {
                return BadRequest("Bool Id can not be greater than 1000.");
            }

            if (!Request.Query.ContainsKey("isLoggedIn"))
            {
                return BadRequest("Book Id is not supplied.");
            } 
            else if (!Convert.ToBoolean(Request.Query["isLoggedIn"]))
            {
                return Unauthorized("User must login.");
            }

            // arg 1 : Action name.
            // arg 2 : Controller name. Skip the suffix Controller if you are using Suffix.
            // arg 3 : Route parameter values if any.
            // Using only by Action and Controller name, the Route attribute url will be picked automatically.
            // The current action will add the new url as response header in the Location header.
            // By default we return 302 i.e. Found as status code.
            return new RedirectToActionResult("Books", "Store", new { });
            // Since we do not want to pass any Route Values we are passing anonymous object,
            // means classless object. That means we are creating an object based on the system.object
            // class itself. So, new {} will be for route values.

            // Since we want all the validations to work in older URL, we have not removed those validations.
            // You can check the network tab, after the above return, you will see 302 status code in 
            // Headers -> General
            // 302 Means server says to the browser such that Hey browser, go to another URL.
            // The New URL you can see in
            // Headers -> Response Headers -> Location.

            // If you do not want to use 302 which is by defult used if you use above code syntax,
            // then you can pass the 4th argument as true, which means it will be 301 i.e. Moved permanently.
            // return new RedirectToActionResult("Books", "Store", new { }, true); // By defualt this 4th is false.

            // 302 means temporary redirection and 301
            // means permanent redirection. What's the difference?
            // In case of 301, since it is the permanent redirection, the
            // browsers and search engines remember that OK, the old URL doesn't work.
            // They will remember the new URL that means for example if Google -like search engines already cached this
            // URL like bookstore now it automatically gets updated with the new URL that is store/books.
            // So, in that way next time onwards somebody searches for our application instead of showing this old
            // URL in the search results it will keep showing the new URL because it is the permanent redirection.
        }
    }
}


// Chart->
// Interface IActionResult -> 
    // Class ActionResult ->
        // Class ContentResult
        // Class JsonResult
        // Class ViewResult
        // Class EmptyResult
        // Class StatusCodeResult
        // Class FileResult
        // Class ViewComponentResult
        // Class RedirectResult
        // Class LocalRedirectResult
        // Class PartialViewResult
        // Class ObjectResult
        // Class RedirectToRouteResult
        // Class RedirectToActionResult