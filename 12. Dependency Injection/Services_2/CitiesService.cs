using ServiceContract_1;

namespace Services_2
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        // ------------------------------------------
        // From : 135. Transient, Scoped, Singleton - Part 2

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId { 
            get 
            {
                return _serviceInstanceId;
            } 
        }


        // End of : 135. Transient, Scoped, Singleton - Part 2
        // ------------------------------------------

        public CitiesService()
        {
            // ------------------------------------------
            // From : 135. Transient, Scoped, Singleton - Part 2

            _serviceInstanceId = Guid.NewGuid();

            // End of : 135. Transient, Scoped, Singleton - Part 2
            // ------------------------------------------

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
    }
}
