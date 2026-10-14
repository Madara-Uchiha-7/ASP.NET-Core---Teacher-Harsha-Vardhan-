using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// -------------------------------- Start of 166. xUnit Test 2 -----------------------------------
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

        /// -------------------------------- Start of 170. Get All Countries - xUnit Test -----------------------------------
        /// 
        /// <summary>
        /// When you add the XML Comment like this, when another dev hover over the method name below then 
        /// this comment will be shown to him, which helps him to understand what this method does.
        /// Returns all Countries from list
        /// </summary>
        /// <returns>All Countries from the list</returns>
        List<CountryResponse> GetAllCountries();
        /// -------------------------------- End of 170. Get All Countries - xUnit Test -----------------------------------

        // -------------------------------- Start of 172. Get Country ID - xUnit Test -----------------------------------
        // If the given country id is not exist, means incorrect country id, then it returns null value, not exception.
        // This method will return the country object based on the Country ID.
        CountryResponse? GetCountryByCountryID(Guid? countryID);
        // -------------------------------- End of 172. Get Country ID - xUnit Test -----------------------------------

    }
    /// -------------------------------- End of 166. xUnit Test 2 -----------------------------------
}
