using _158._Custom_Json_Configuration.WeatherApis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _158._Custom_Json_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOptions _weatherApiOptions;

        public HomeController(IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _weatherApiOptions = weatherApiOptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.ClientIDNumber = _weatherApiOptions.ClientID;
            ViewBag.ClientSecretName = _weatherApiOptions.ClientSecret;
            return View();
        }
    }
}
