using Services;
using ServiceContracts.DTO;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Entities;
using System.Threading.Tasks; // This is for the Task return type

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountryService? _countryService;

        public CountriesServiceTest()
        {
            _countryService = new CountriesService(
                new Entities.PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options)
            );
        }

        #region AddCountry

        [Fact]
        // public void AddCountry_NullCountry() // This is the preferred naming convension
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task AddCountry_NullCountry()
        // When the return type is task, it is equivalent to returning void.
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            //Assert.Throws<ArgumentNullException>(() =>
            //{
            //    // Act 
            //    _countryService.AddCountry(request);
            //});
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Act 
                await _countryService.AddCountry(request);
            });
        }

        [Fact]
        //public void AddCountry_CountryNameIsNull() // This is the preferred naming convension
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task AddCountry_CountryNameIsNull()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = null };

            // Assert
            // Some value in argument is wrong this means ArgumentException
            //Assert.Throws<ArgumentException>(() =>
            //{
            //    // Act 
            //    _countryService.AddCountry(request);
            //});
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // Act 
                await _countryService.AddCountry(request);
            });
        }

        [Fact]
        //public void AddCountry_DuplicateCountryName() // This is the preferred naming convension
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task AddCountry_DuplicateCountryName()
        {
            // Arrange
            CountryAddRequest? request1 = new CountryAddRequest()
            { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest()
            { CountryName = "USA" };


            // Assert
            //Assert.Throws<ArgumentException>(() =>
            //{
            //    // Act 
            //    _countryService.AddCountry(request1);
            //    _countryService.AddCountry(request2);
            //});
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                // Act 
                await _countryService.AddCountry(request1);
                await _countryService.AddCountry(request2);
            });
        }

        //public void AddCountry_ProperCountryDetails()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = "Japan" };

            // Act
            //CountryResponse countryResponse = _countryService.AddCountry(request);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            CountryResponse countryResponse = await _countryService.AddCountry(request);

            //List<CountryResponse> countriesFromGetAllCountries = _countryService.GetAllCountries();
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<CountryResponse> countriesFromGetAllCountries = await _countryService.GetAllCountries();

            // Assert
            Assert.True(countryResponse.CountryID != Guid.Empty);
            Assert.Contains(countryResponse, countriesFromGetAllCountries);
        }

        #endregion AddCountry

        #region GetAllCountries

        [Fact]
        //public void GetAllCountries_EmpyList()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task GetAllCountries_EmpyList()
        {
            // Acts 
            //List<CountryResponse> actualCountriesFromResponseList = _countryService.GetAllCountries();
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<CountryResponse> actualCountriesFromResponseList = await _countryService.GetAllCountries();

            // Assert
            Assert.Empty(actualCountriesFromResponseList);
        }

        [Fact]
        //public void GetAllCountries_AddFewCountries()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task GetAllCountries_AddFewCountries()
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
                //countriesFromAddCountry.Add(_countryService.AddCountry(countryRequest));
                // The above line is replaced with below in lecture "233. Async Controller Action Methods"
                countriesFromAddCountry.Add(await _countryService.AddCountry(countryRequest));
            }

            //List<CountryResponse> actualCountrieResponse = _countryService.GetAllCountries();
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<CountryResponse> actualCountrieResponse = await _countryService.GetAllCountries();

            foreach (CountryResponse expectedCountry in countriesFromAddCountry)
            {
                // Assert
                Assert.Contains(expectedCountry, actualCountrieResponse);
            }
        }

        #endregion GetAllCountries

        #region GetCountryByCountryID

        [Fact]
        //public void GetCountryByCountryID_NullCountryID()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods
        public async Task GetCountryByCountryID_NullCountryID()
        {
            // Arrange
            Guid? guid = null;

            // Act
            //CountryResponse? countryResponse = _countryService.GetCountryByCountryID(guid);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods
            CountryResponse? countryResponse = await _countryService.GetCountryByCountryID(guid);

            // Assert 
            Assert.Null(countryResponse);
        }

        [Fact]
        //public void GetCountryByCountryID_ValidCountryID()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods
        public async Task GetCountryByCountryID_ValidCountryID()
        {
            // Arrange 
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            { CountryName = "China" };

            //CountryResponse countryResponseAdd = _countryService.AddCountry(countryAddRequest);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods
            CountryResponse countryResponseAdd = await _countryService.AddCountry(countryAddRequest);

            // Act
            //CountryResponse countryResponseGet = _countryService.GetCountryByCountryID(countryResponseAdd.CountryID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods
            CountryResponse countryResponseGet = await _countryService.GetCountryByCountryID(countryResponseAdd.CountryID);

            // Assert
            Assert.Equal(countryResponseGet, countryResponseAdd);
        }

        #endregion GetCountryByCountryID 
    }
}
