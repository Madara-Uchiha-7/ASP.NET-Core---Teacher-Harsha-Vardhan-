using Microsoft.AspNetCore.Mvc;
using ServiceContract;


namespace _130._Dependency_Inversion_Principle.Controllers
{
    public class HomeController : Controller
    {
        //private readonly CitiesService _citiesService;  : Older code
        private readonly ICitiesService _citiesService;

        public HomeController()
        {
            _citiesService = // what to pass here, will be written in nect lecure.
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
