using Microsoft.AspNetCore.Mvc;

namespace _151._IConfiguration_in_Controller.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration) // IOC container will give us the object in parameter "configuration"
        {
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.MyKey = _configuration["MyKey"];
            ViewBag.MyAPIKey = _configuration.GetValue("MyApiKey", "The Default Value");
            return View();
        }
    }
}
