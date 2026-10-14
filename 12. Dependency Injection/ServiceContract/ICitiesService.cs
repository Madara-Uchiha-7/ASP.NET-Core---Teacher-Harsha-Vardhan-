namespace ServiceContract
{
    public interface ICitiesService
    {
        // Now in this, you should not write a constructor or properties. Only one thing, that is,
        // the actual method which you are going to plan to create in the service.
        // Assume as of now the service is not ready.

        List<string> GetCities();
    }
}
