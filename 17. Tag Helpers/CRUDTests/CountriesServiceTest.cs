using Services;
using ServiceContracts.DTO;
using ServiceContracts;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountryService? _countryService;

        public CountriesServiceTest()
        {
            _countryService = new CountriesService(false);
        }
        
        #region AddCountry

        [Fact]
        public void AddCountry_NullCountry() // This is the preferred naming convension
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act 
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_CountryNameIsNull() // This is the preferred naming convension
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = null };

            // Assert
            // Some value in argument is wrong this means ArgumentException
            Assert.Throws<ArgumentException>(() =>
            {
                // Act 
                _countryService.AddCountry(request);
            });
        }

        [Fact]
        public void AddCountry_DuplicateCountryName() // This is the preferred naming convension
        {
            // Arrange
            CountryAddRequest? request1 = new CountryAddRequest()
            { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest()
            { CountryName = "USA" };


            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act 
                _countryService.AddCountry(request1);
                _countryService.AddCountry(request2);
            });
        }
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = "Japan" };

            // Act
            CountryResponse countryResponse = _countryService.AddCountry(request);
            List<CountryResponse> countriesFromGetAllCountries = _countryService.GetAllCountries();

            // Assert
            Assert.True(countryResponse.CountryID != Guid.Empty);
            Assert.Contains(countryResponse, countriesFromGetAllCountries);
        }

        #endregion AddCountry

        #region GetAllCountries

        [Fact]
        public void GetAllCountries_EmpyList()
        {
            // Acts 
            List<CountryResponse> actualCountriesFromResponseList = _countryService.GetAllCountries();

            // Assert
            Assert.Empty(actualCountriesFromResponseList);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            // Arrange
            List<CountryAddRequest> coutryAddRequests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() {CountryName = "USA"},
                new CountryAddRequest() {CountryName = "Japan"},
                new CountryAddRequest() {CountryName = "Spain"},
            };

            // Act
            List<CountryResponse> countriesFromAddCountry = new List<CountryResponse>();
            foreach (CountryAddRequest countryRequest in coutryAddRequests)
            {
                countriesFromAddCountry.Add(_countryService.AddCountry(countryRequest));
            }

            List<CountryResponse> actualCountrieResponse = _countryService.GetAllCountries();

            foreach (CountryResponse expectedCountry in countriesFromAddCountry)
            {
                // Assert
                Assert.Contains(expectedCountry, actualCountrieResponse);
            }
        }

        #endregion GetAllCountries

        #region GetCountryByCountryID

        [Fact]
        public void GetCountryByCountryID_NullCountryID()
        {
            // Arrange
            Guid? guid = null;

            // Act
            CountryResponse? countryResponse = _countryService.GetCountryByCountryID(guid);

            // Assert 
            Assert.Null(countryResponse);
        }

        [Fact]
        public void GetCountryByCountryID_ValidCountryID()
        {
            // Arrange 
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            { CountryName = "China" };

            CountryResponse countryResponseAdd = _countryService.AddCountry(countryAddRequest);

            // Act
            CountryResponse countryResponseGet = _countryService.GetCountryByCountryID(countryResponseAdd.CountryID);

            // Assert
            Assert.Equal(countryResponseGet, countryResponseAdd);
        }

        #endregion GetCountryByCountryID 
    }
}
