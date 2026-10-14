using Microsoft.AspNetCore.Mvc;

namespace _54._ContentResult.Controllers
{
    // It is not advisable or not a general practice to return string
    // type of data from the action method, because there you have to
    // mention the content type explicitly by using the response.headers, but if
    // you can create and return an object of the content result class, in a shortcut syntax, you can
    // mention the content as well as content type. Example is Index(), in which you can check 
    // the return type of the action method and how we are returning the value.
    // The first property called, Content contains the actual information 
    // that you want to return, that will be as it is added in the response body. 
    // Then you give the ContentType which will be the MIME type of that content.
    // It is to tell what type of content we are returning.
    // Run the application, you will see the data we are returning.
    // Now go to network -> Response -> You will see the data we are returning.
    // Network -> Headers -> Response Headers -> Content Type: text/plain, which we set.

    // Now there is a shortcut to create the object of the ContentResult.
    // You can use predefined method Content() and pass Content and ContentType as arguments.
    // But in which class this Content() method is available? 
    // In order to use that Content() you must inherit the class Controller.
    // Check About() action method.
    // Benifit of this class is it provides ready-made methods for returning different types of action
    // results, and also it provides additional information about model binding, validation status, etc.
    // Internally Content() returns the object of ContentResult class which we are returning manually in
    // Index(). This Content() is defined in ControllerBase abstract class. This ControllerBase class is parent of
    // our abstract Controller class.
    // Check ContactUs() to see the HTML return type. To create proper Page we will need a razor views.

    [Controller] // This attribute is not needed because we are already added the suffix called Controller to our class.
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("Home")]
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Hello From Index :)",
                ContentType = "text/plain",
            };
        }

        [Route("About")]
        public ContentResult About()
        {
            return Content("Hello from about", "text/plain");
        }

        [Route("Contact")]
        public ContentResult ContactUs()
        {
            return Content("<h1>Hello from ContactUs</h1>", "text/html");
        }

        [Route("Contact/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUsPara()
        {
            return "Hello from Contact with mobile number.";
        }
    }
}
