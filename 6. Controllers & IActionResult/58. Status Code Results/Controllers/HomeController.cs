using Microsoft.AspNetCore.Mvc;
using _58._Status_Code_Results.Models;


namespace _58._Status_Code_Results
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            // Check if requests contains the bookid in the url.
            if (!Request.Query.ContainsKey("bookid"))
            {
                // Response.StatusCode = 400;
                // return Content("Book Id is not supplied.");

                // We can use BadRequestResult(); instead of Response.StatusCode = 400;
                // E.g.:
                // return new BadRequestResult();
                // But we can also use shorthand for above i.e.:
                return BadRequest("Book Id is not supplied.");
                // As you can see, we can also pass our error message.
                // Now we do not need to add 2 lines. Now, we also pass our message and status
                // code is now automatically set to 400.
            }
            // bookid can not be empty.
            else if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                // NotFound will set the status code to 404 automatically.
                // If we give the message in the NotFound("message") then NotFoundObjectResult class object is returned.
                // If do not give the message and only do : return NotFound();
                // then NotFound will return NotFoundResult class object.
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
                // Unauthorized("error message");
                // this is the shorthand for : return new UnauthorizedResult();
                // This will set the status 401 automatically.
                // If we pass the argument i.e. the error message to Unauthorized() then
                // it will return UnauthorizedObjectResult class object.
                // If we did not pass the argument then it will return UnauthorizedResult class object.
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