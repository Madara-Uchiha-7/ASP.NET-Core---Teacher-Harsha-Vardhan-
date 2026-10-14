using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContract_1;
using Services_3;


namespace _136._Service_Scope.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService_1;
        private readonly ICitiesService _citiesService_2;
        private readonly ICitiesService _citiesService_3;

        private readonly ILifetimeScope _lifetimeScope;

        public HomeController(
            ICitiesService citiesService_1,
            ICitiesService citiesService_2,
            ICitiesService citiesService_3,
            ILifetimeScope serviceScopeFactory
        )
        {
            _citiesService_1 = citiesService_1;
            _citiesService_2 = citiesService_2;
            _citiesService_3 = citiesService_3;
            _lifetimeScope = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService_1.GetCities();

            ViewBag.InstanceId_CitiesService_1 = _citiesService_1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService_2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService_3.ServiceInstanceId;

            //using (IServiceScope scope_1 = _serviceScopeFactory.CreateScope())
            // Because we are using the Child scope, we are using this api ILifetimeScope
            // In case if you don't need child scopes in your case, you don't need to use that.
            // So once you have enabled Autofac with this code,
            // within the same application anywhere in any service, you can inject any other service.
            // For example, you have created the service one,
            // and you can inject the same in service two, or in the controller,
            // or in any middleware, or wherever required in the entire project.
            // Thus, the classes or services will not call each other directly,
            // but indirectly, through dependency injection, they are related.
            // It is the overall goal of this entire dependency concept.
            // We have already discussed about the dependency problem,
            // and how the dependency injection solves the problem of the dependency.
            // 
            using (ILifetimeScope scope_1 = _lifetimeScope.BeginLifetimeScope())
            {
                ICitiesService citiesService = scope_1.Resolve<ICitiesService>();

                ViewBag.InstanceId_CititesService_InScope = citiesService.ServiceInstanceId;
            }

            return View(cities);
        }
    }
}
