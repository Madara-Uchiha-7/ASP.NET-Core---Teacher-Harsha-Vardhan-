namespace ServiceContract_1
{
    public interface ICitiesService
    {
        // ------------------------------------------
        // From : 135. Transient, Scoped, Singleton - Part 2

        Guid ServiceInstanceId { get; }

        // End of : 135. Transient, Scoped, Singleton - Part 2
        // ------------------------------------------
        List<string> GetCities();
    }
}
