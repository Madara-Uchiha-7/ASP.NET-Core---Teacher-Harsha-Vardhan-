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

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(
            ICitiesService citiesService_1,
            ICitiesService citiesService_2,
            ICitiesService citiesService_3,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            _citiesService_1 = citiesService_1;
            _citiesService_2 = citiesService_2;
            _citiesService_3 = citiesService_3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService_1.GetCities();

            ViewBag.InstanceId_CitiesService_1 = _citiesService_1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService_2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService_3.ServiceInstanceId;

            /*
                  In order to create a child scope, we need to inject a predefined service called, ServiceScoped factory.
                  For this we have created  :
            
                private readonly IServiceScopeFactory _serviceScopeFactory;

                We initialized this in the constructor.

                So automatically ASP.NET Core IOC container creates an object of the ServiceScopeFactory
                and supplies the same as argument to constructor parameter.

                This way we have successfully injected IServiceScopeFactory.

                Lets add a code below now:
                    _serviceScopeFactory.CreateScope() will create a new scope. 
                    Since we are using "using" block, at the end of the using block, automatically it calls the dispose method of 
                    IServiceScope' scope i.e. scope_1. 
                    so it internally and automatically calls the dispose method for all the services that are injected as a part of this using 
                    scope.
            */

            using (IServiceScope scope_1 = _serviceScopeFactory.CreateScope()) 
            {
                // Assume, Cities Service has been injected within this particular scope,
                // Lets do that:
                // ServiceProvider object is responsible to supply the service instances.
                // So it has a method called getRequiredService. In that we need to provide the interface of the service.
                // So this code is almost equivalent to injecting ICitiesService into the constructor.
                ICitiesService citiesService = scope_1.ServiceProvider.GetRequiredService<ICitiesService>();
                // above, right side of =  will automatically creates a new object of the Cities Service.

                // Now citiesService can call any method.
                // So assume the database connection has been opened here using one of that method.
                // At the end if }, it automatically calls Dispose method of CitiesService.
                // This ServiceProvider will call dispose on all the services which are created here in this "using" block.
                // And you are not supposed to call that dispose method of the Cities Service manually.

                // In this scope you will get another service instance Id different from above once.
                ViewBag.InstanceId_CititesService_InScope = citiesService.ServiceInstanceId;
                // We have printed above in our index view. i.e. index.cshtml
            }

            return View(cities);
        }
    }
}
