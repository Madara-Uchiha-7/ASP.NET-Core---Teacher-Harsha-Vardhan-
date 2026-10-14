using _154._Configuration_as_Service.WeatherApis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _154._Configuration_as_Service.Controllers
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
