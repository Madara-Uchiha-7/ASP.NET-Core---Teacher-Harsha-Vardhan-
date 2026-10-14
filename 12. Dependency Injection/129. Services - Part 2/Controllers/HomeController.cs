using Microsoft.AspNetCore.Mvc;
using Services;


namespace _129._Services___Part_2.Controllers
{
    public class HomeController : Controller
    {
        // Always make that reference variable as private read-only field.
        // By making this field as read-only field,
        // you will avoid unwanted assignment of unwanted values into the field.
        // And it is recommended to prefix underscore for all the private fields.
        private readonly CitiesService _citiesService;

        public HomeController()
        {
            _citiesService = new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
