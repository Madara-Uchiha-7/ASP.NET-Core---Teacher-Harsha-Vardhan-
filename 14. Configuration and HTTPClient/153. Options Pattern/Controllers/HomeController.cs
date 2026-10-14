using _153._Options_Pattern.OptionPatterns.WeatherApis;
using Microsoft.AspNetCore.Mvc;

namespace _153._Options_Pattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            IConfiguration weatherApiSection = _configuration.GetSection("WeatherApi");
            WeatherApiOptions weatherApiOptions =  weatherApiSection.Get<WeatherApiOptions>();

            ViewBag.ClientIDNumber = weatherApiOptions.ClientID;
            ViewBag.ClientSecretName = weatherApiOptions.ClientSecret;

            // There is another way to perform this same task.
            // You can use this Bind method as well.
            // In this case, you have to create an
            // options class object yourself first.
            // And you have to supply that existing instance as an Argument to Bind()
            // Shown below:
            WeatherApiOptions weatherApiOptionsForBind = new WeatherApiOptions();
            weatherApiSection.Bind(weatherApiOptionsForBind);
            // This bind will load the values of our keys into our "weatherApiOptionsForBind" object.
            ViewBag.ClientIDNumberForBind = weatherApiOptionsForBind.ClientID;
            ViewBag.ClientSecretNameForBind = weatherApiOptionsForBind.ClientSecret;

            return View();
        }
    }
}
