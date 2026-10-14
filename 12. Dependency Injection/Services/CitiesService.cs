namespace Services
{
    public class CitiesService
    {
        // -----------------------------------------------------------------
        // From : 128. Services - Part 1
        private List<string> _cities;

        // Since we do not have the db, we will use static data
        public CitiesService() 
        { 
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };
        }

        public List<string> GetCities ()
        {
            // In real life, here you will get a data from database.
            return _cities;
        }
        // End of : 128. Services - Part 1
        // -----------------------------------------------------------------
    }
}
