using Microsoft.AspNetCore.Mvc;
using ServiceContract_1;


namespace _135._Transient__Scoped__Singleton___Part_2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService_1;
        private readonly ICitiesService _citiesService_2;
        private readonly ICitiesService _citiesService_3;

        public HomeController(
            ICitiesService citiesService_1,
            ICitiesService citiesService_2,
            ICitiesService citiesService_3
        )
        {
            _citiesService_1 = citiesService_1;
            _citiesService_2 = citiesService_2;
            _citiesService_3 = citiesService_3;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService_1.GetCities(); // Use any instance for this, it does not matter which one.

            // InstanceId_CitiesService_1 is a variable name, you can give any other name, it is upto us.
            ViewBag.InstanceId_CitiesService_1 = _citiesService_1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService_2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService_3.ServiceInstanceId;

            return View(cities);
        }
    }
}
