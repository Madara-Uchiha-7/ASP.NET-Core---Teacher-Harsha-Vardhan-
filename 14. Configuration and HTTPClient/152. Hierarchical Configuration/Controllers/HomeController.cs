using Microsoft.AspNetCore.Mvc;

namespace _152._Hierarchical_Configuration.Controllers
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
            ViewBag.MyKey = _configuration["MasterKey:Child1"];
            ViewBag.MyKey2 = _configuration.GetSection("MasterKey")["Child2"];
            ViewBag.MyAPIKey = _configuration.GetValue("MasterKey:Child3", "The Default Value");
            return View();
        }
    }
}
// ViewBag.MyKey2 = _configuration.GetSection("MasterKey")["Child2"]; 
// Is same as:
// IConfigurationSection weatherApiSection = _configuration.GetSection("MasterKey");
// weatherApiSection["Child2"];
// This way you can use weatherApiSection variable more than once to get all children one by one.
// So you do not have to write the _configuration.GetSection("MasterKey")[""] this whole line for each child.
