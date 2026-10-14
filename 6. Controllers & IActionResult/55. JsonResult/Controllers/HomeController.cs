using Microsoft.AspNetCore.Mvc;
using _55._JsonResult.Models;

namespace _55._JsonResult.Controllers
{
    // In ASP.NET Core web applications, you can return the JSON data for sending the data back to
    // the browser. Generally, it is used in AJAX, asynchronous JavaScript and XML.
    // That means you are going to make an asynchronous request through JavaScript code so that this JSON
    // data can be read by that JavaScript code.
    // Right click on this project, new folder called Models.
    // So a model class is going to be a Poco class, that means plain old CLR object class
    // that contains a set of properties. So it defines what data you would like to store in an
    // object. For example, the person class can represent what person details you would like to store in that.
    // Right click on Models folder -> new Item -> Select C# class under Visual C#.
    // Name it: Person.cs
    // Go in that Person class.

    // Lets use  "_55._JsonResult.Models" namespace.
    // Lets see to ways to return the JSON.
    // Check JsonFormat1() and JsonFormat2()
    public class HomeController : Controller
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

        [Route("Json1")]
        public JsonResult JsonFormat1()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Age = 10
            };
            return new JsonResult(person); // This JsonResult will convert our class properties into JSON at runtime.
            // Even the content type will be set automatically.
        }
        [Route("Json2")]
        public JsonResult JsonFormat2()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Age = 10
            };
            // Predefined parent class Controller class provides, shorthand method that is JSON.
            // This below code will be equivalant to new JsonResult code because internally Json()
            // returns an object of the JsonResult class. This Json() is preferred by the devs.
            return Json(person);
        }

        [Route("Contact/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUsPara()
        {
            return "Hello from Contact with mobile number.";
        }
    }
}
