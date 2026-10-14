using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    /// -------------------------------- Start of 166. xUnit Test 2 -----------------------------------
    public class CountriesService : ICountryService
    {
        /// Here We have to add the project reference of ServiceContracts
        /// Because the CountriesService implements the ICountryService from the ServiceContracts.
        /// This class will implement the "ICountryService" and will add the method code related to it.
        /// 

        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            // When ever you are yet to implement the method, it is better to write below statement so that your project
            // build will not fail.
            // throw new NotImplementedException();

            /// -------------------------------- Start of 169. Add Country Implementation -----------------------------------
            /// Since we are implementing this method, we have commented the "throw new NotImplementedException();"
            /// Same we are going to do for remaining methods also.
            /// 

            // Check if "countryAddRequest" is not null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            // Validate all properties of "countryAddRequest"
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            // Validation :  Duplicate Country Names are not allowed.
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name Already Exists.");
            }

            // Convert the CountryAddRequest to Country
            Country country = countryAddRequest.ToCountry();

            // Generate new CountryID
            country.CountryID = Guid.NewGuid();

            // Then add it to List<Country>
            _countries.Add(country);

            // Return CountryResponse object with generated CountryID
            return country.ToCountryResponse(); // This is the extension method from CountryResponse class.

            /// -------------------------------- End of 169. Add Country Implementation -----------------------------------
        }

        /// -------------------------------- Start of 170. Get All Countries - xUnit Test -----------------------------------
        ///
        public List<CountryResponse> GetAllCountries()
        {
            // When ever you are yet to implement the method, it is better to write below statement so that your project
            // build will not fail.
            //throw new NotImplementedException();

            /// -------------------------------- Start of 171. Get All Countries - Implementation -----------------------------------
            ///
            // Select returns the IEnumerable but we need to return the List so we have used ToList
            return _countries.Select(country => country.ToCountryResponse()).ToList();

            /// -------------------------------- End of 171. Get All Countries - Implementation -----------------------------------
        }

        /// -------------------------------- End of 170. Get All Countries - xUnit Test -----------------------------------
        /// 

        /// -------------------------------- Start of 172. Get Country ID - xUnit Test -----------------------------------
        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            Country? countryResponseFromContries = _countries.FirstOrDefault(country =>
            
                country.CountryID == countryID
            );

            if (countryResponseFromContries == null)
            {
                return null;
            }

            return countryResponseFromContries?.ToCountryResponse();
        }
        /// -------------------------------- End of 172. Get Country ID - xUnit Test -----------------------------------
    }
    /// -------------------------------- Start of 166. xUnit Test 2 -----------------------------------
}
