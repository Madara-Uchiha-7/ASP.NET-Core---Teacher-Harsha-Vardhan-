using Microsoft.AspNetCore.Mvc;

namespace _52._Multiple_Action_Method.Controllers
{
    public class HomeController
    {
        // Generally, in the real-world projects, the first action method is named as index.
        // It is more of a convention. And of course, you can give it any other name.
        // And you can return some response.
        // And you can add multiple routes for the same action method.
        // Lets add the default route also. 
        [Route("Home")]
        [Route("/")]
        public string Index()
        {
            return "Hello from Index";
        }

        // Lets create more action methods.
        [Route("About")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("Contact")]
        public string ContactUs()
        {
            return "Hello from ContactUs";
        }

        // We are returning the string from the action method.
        // That string is getting displayed on the browser window. That will be present also  
        // in the network tab. In network tab ->  Select Home -> Response

        // You can also use the route parameters and route constraints in this attribute routing as well.
        // For example, for a parameter, you can prefix with curly brases and specify
        // the parameter name. 
        // E.g. mobile will be the name of the parameter. And you can specify any constraints.
        // e.g. [Route("Contact/{mobile:int}")] 
        // Below for constraints, we have given regex. It always starts with ^ and ends with $.
        // To accept digits only we have given:
        // \d
        // To avoid escape sequence, we added one more \
        // in {} we add number of digits/characters you want to accept.
        // We added {{}} instead of {} because we are already writing this in {}.
        // So to avoid confusion to the compiler, we need to add this.
        // Since we are going to accept 10 digits in total, we added the 10.

        [Route("Contact/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUsPara()
        {
            return "Hello from Contact with mobile number.";
        }
    }
}
