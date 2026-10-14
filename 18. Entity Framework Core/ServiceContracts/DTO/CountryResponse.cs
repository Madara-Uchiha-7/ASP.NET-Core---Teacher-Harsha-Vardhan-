using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used as a return type for most of CountryResponse methods.
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }
            CountryResponse countryResponse = (CountryResponse)obj;
            return (this.CountryID == countryResponse.CountryID && this.CountryName == countryResponse.CountryName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountryExtensions
    {
        /// <summary>
        /// This extension method is going to be injected into the Country class.
        /// which is the entities class.
        /// Means it behaves like this method was added to the Country class itself.
        /// </summary>
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName,
            };
        }
    }
}
