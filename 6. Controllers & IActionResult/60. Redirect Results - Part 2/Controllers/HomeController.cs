using Microsoft.AspNetCore.Mvc;
using _60._Redirect_Results___Part_2.Models;
using _60._Redirect_Results___Part_2.Controllers;


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
            // For below line : which return 302 by default:
            // return new RedirectToActionResult("Books", "Store", new { });
            // There is a shorthand method:
            return RedirectToAction("Books", "Store", new 
            {
                id = bookId
            });
            // This method return "RedirectToActionResult" class object.
            // And then you will mention the ActionResult first, and then ControllerName, and then RouteValues.
            // We are passing our bookId to the new URL. 
            // So, we can accept it in the Route Attribute of it.
            // Check StoreController for it.
            // If you want to use shorthand method for RedirectToActionResult() but for 301 instead of 301, use:
            // return RedirectToActionPermanent("Books", "Store", new
            // {
            //     id = bookId
            // });


            // For the case of LocalRedirectResult, class, you will directly mention the
            // route URL instead of supplying the action name and controller name.
            // Url which we are going to pass here will work only if its related to out applcation.
            // Also we can pass the RouteValue, so here we need to pass the bookId which we are using in our URL.
            // For e.g. it will not work and to google.come if you try to add it here:
            // return new LocalRedirectResult("store/books/{bookId}");
            // Though mostly in real word RedirectToActionPermanent is better to use.
            // Because we can differ things based on the action and controller name and also name of the action 
            // and controller, we can keep it in some variable.
            // If your URL is complex and big then in this case People use LocalRedirectResult().
            // There is a shortcut present for LocalRedirectResult() also:
            // return LocalRedirect();
            // LocalRedirectResult() and LocalRedirect() both works on 302 response.
            // To use them both for 301 response, pass 2nd argument as true
            // or You can use return LocalRedirectPermanent();

            // There is one more method RedirectResult("url", permenant);
            // This works in the same way as LocalRedirectResult();
            // The difference is the LocalRedirectResult has a restriction such that the
            // URL should be a local one, means be a part of the same web application which we are creating.
            // That means from your application, you cannot redirect to another application by using LocalRedirectResult.
            // In case if you are moving from one domain to another domain, let's say Website1 to Website2, in
            // that case, RedirectResult is better. RedirectResult also works with local url:
            // So you can also do and also lets use the shorthand for this method also:
            // return Redirect("\"store/books/{bookId}\"");
            // To use permanent shorthand use:
            // return RedirectPermanent("\"store/books/{bookId}\"");
        }
    }
}

/*
That 3rd argument is for route values (route parameters / query string) 
that you want to send to the next action while redirecting.



So instead of just redirecting to /Store/Books, you can redirect to something like:

/Store/Books?bookid=5&category=dotnet



Example:

return new RedirectToActionResult(
  actionName: "Books",
  controllerName: "Store",
  routeValues: new { bookid = bookId, category = "dotnet" }
);


So basically, it is “pass data in the URL while redirecting”. 
*/


// Chart->
// InterfaceIActionResult -> 
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
