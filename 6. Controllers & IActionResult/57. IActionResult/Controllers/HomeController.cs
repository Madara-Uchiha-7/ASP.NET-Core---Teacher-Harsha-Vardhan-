using Microsoft.AspNetCore.Mvc;
using _57._IActionResult.Models;


// As you can see that in out Index action method we are returning the File() or Content()
// depending on the situation. But because we are using the IActionResult interface, we can return either of them
// and our return type is not fixed. This is the benifit of using return type as IActionResult.
// 
namespace _57._IActionResult
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            // We are adding the validations for bookid in if-else blocks.
            // We can write all these validation rules in the route constraints, right?
            // Yes, it is possible, but it is not advisable to merely depend on the route constraints.
            // Because in case if the user supplies invalid values such as greater than 1000,
            // then simply that route doesn't match.
            // So then you cannot give an appropriate error message to the user saying that
            // OK, this value should be less than 1000.
            // So it is not advisable to depend on route constraints for validation of the route parameters
            // Or the query string parameters.
            


            // Check if requests contains the bookid in the url.
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400; // By default it will be 200
                return Content("Book Id is not supplied.");
            }
            // bookid can not be empty.
            else if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book Id can not be null.");
            }

            // bookid must me in 1 - 1000
            // Below is the actual way to access the request object.
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0)
            {
                Response.StatusCode = 400;
                return Content("Bool Id can not be less than 0.");
            }
            else if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Bool Id can not be greater than 1000.");
            }

            if (!Request.Query.ContainsKey("isLoggedIn"))
            {
                Response.StatusCode = 400;
                return Content("Book Id is not supplied.");
            } 
            else if (!Convert.ToBoolean(Request.Query["isLoggedIn"]))
            {
                Response.StatusCode = 401; // 401 : Is used for unauthorized.
                return Content("User must login.");
            }
            return File("/sample.pdf", "application/pdf");
        }
    }
}


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