using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity.
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Adds the Country object into the list of countries.
        /// </summary>
        /// <param name="countryAddRequest">The country object to be added.</param>
        /// <returns>Same country object after adding it (including newly Country id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// When you add the XML Comment like this, when another dev hover over the method name below then 
        /// this comment will be shown to him, which helps him to understand what this method does.
        /// Returns all Countries from list
        /// </summary>
        /// <returns>All Countries from the list</returns>
        List<CountryResponse> GetAllCountries();

        CountryResponse? GetCountryByCountryID(Guid? countryID);
    }
}
