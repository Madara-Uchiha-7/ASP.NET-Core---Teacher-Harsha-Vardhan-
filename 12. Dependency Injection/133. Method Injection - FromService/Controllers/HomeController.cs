using Microsoft.AspNetCore.Mvc;
using ServiceContract;


namespace _133._Method_Injection___FromService.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICitiesService _citiesService;

        // Last lecture Code
        //public HomeController(ICitiesService citiesService) 
        //{
        //    _citiesService = citiesService;
        //}

        [Route("/")]
        public IActionResult Index([FromServices]ICitiesService citiesService)
        {
            List<string> cities = citiesService.GetCities();
            return View(cities);
        }
    }
}
