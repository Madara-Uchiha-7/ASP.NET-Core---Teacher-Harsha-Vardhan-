using ServiceContract_1;

namespace Services_3
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }

        public CitiesService()
        {

            _serviceInstanceId = Guid.NewGuid();

            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            // Lets say we create the database connection in the constructor.
            // We will close it here.
            // Do we need to call this Dispose by ourselves?
            /*
                In case if you registered this service as a scoped service, at the end of the request only,
                that means before giving the response to the browser,
                then only it calls the dispose method of all the scoped services.
                In case if you want to dispose the connection as soon as possible,
                once your database operation is completed, then you have to implement child scopes.
                So you will create a child scope by calling CreateScope method.
                And then you will inject that database connection related service.
                And at the end of the scope, automatically it calls the dispose method of the service.
            */

            // Lets assume we have the database close logic written here.
        }
    }
}
