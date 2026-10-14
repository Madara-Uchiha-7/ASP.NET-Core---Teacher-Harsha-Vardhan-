using Microsoft.AspNetCore.Mvc;

namespace _53._Takeouts_about_Controllers.Controllers
{
    public class HomeController
    {
        [Route("Home")]
        [Route("/")]
        public string Index()
        {
            return "Hello from Index";
        }

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

        [Route("Contact/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUsPara()
        {
            return "Hello from Contact with mobile number.";
        }
    }
}
