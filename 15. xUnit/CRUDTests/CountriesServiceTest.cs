using System;
using System.Collections.Generic;
using ServiceContracts.DTO;
using ServiceContracts;
using Entities;
using Services;
using Xunit;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        /// -------------------------------- Start of 166. xUnit Test 2 -----------------------------------
        private readonly ICountryService? _countryService;

        public CountriesServiceTest()
        {
            /// Lets create a dummy service class for below.
            /// Add a new Project in solution.
            /// We are going to add the implementation of the Service classes in a separate class library.
            /// The benefit of separating everything is that 
            /// each class library can be independently developed by different developers
            /// based on the requirement. and it will be easy to integrate it later.
            /// Name it : Services and add a class in it or rename the class1 to "CountriesService.cs"
            /// Make sure to have the same .NET version as others. Check the code and comments in it and then comeback here.
            /// After this we have created the xUnit Test 3.
            /// We added add a package reference of Services in CRUDTests.
            /// Now we are here.
            /// 

            /// -------------------------------- Start of 166. xUnit Test 3 -----------------------------------
            _countryService = new CountriesService();
            /// -------------------------------- End of 166. xUnit Test 3 -----------------------------------
        }

        /// -------------------------------- Start of 166. xUnit Test 3 -----------------------------------
         
        #region AddCountry
        /// This is the time to create actual test method.
        /// when you supply null, it should throw argument null exception.
        /// The second requirement is, or the second test case is,
        /// when the country name is null, it should throw argument exception. 
        /// Next, when the country name is duplicate, it should throw again argument exception.
        /// And then the fourth requirement is, or the fourth unit test is,
        /// when you supply proper country name, it should insert the same into the list of countries.
        /// 
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
        /// When you will run above test case, it will throw the ArgumentNullException
        /// because our method AddCountry is yet to be implemented. So, test will throw the NotImplementedException
        /// So, when developer will implement that AddCountry method, then this test case will work
        /// because when developer will implement it, he will add the checks and will return "ArgumentNullException"
        /// if object CountryAddRequest is null. This returned "ArgumentNullException" will be checked here with our
        /// provided "<ArgumentNullException>" so, in that case our test case will pass.
        /// Lets implement remaining test cases below:
        /// 

        [Fact]
        public void AddCountry_CountryNameIsNull() // This is the preferred naming convension
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = null};

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
            // Some value in argument is wrong this means ArgumentException
            Assert.Throws<ArgumentException>(() =>
            {
                // Act 
                _countryService.AddCountry(request1);
                _countryService.AddCountry(request2);
            });
        }
        public void AddCountry_ProperCountryDetails() // This is the preferred naming convension
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            { CountryName = "Japan" };

            // Act
            CountryResponse countryResponse = _countryService.AddCountry(request);
            List<CountryResponse> countriesFromGetAllCountries = _countryService.GetAllCountries();

            // Assert
            Assert.True(countryResponse.CountryID != Guid.Empty);
            // If we adds a country but it does not get added property into our list then below will check that part.
            Assert.Contains(countryResponse, countriesFromGetAllCountries);
            //********Note about above line in the end of this file - This comment is from  171. Get All Countries - Implementation
        }
        #endregion AddCountry

        /// -------------------------------- End of 166. xUnit Test 3 -----------------------------------

        /// -------------------------------- Start of 170. Get All Countries - xUnit Test -----------------------------------

        #region GetAllCountries
        // The list of countries should be empty by default
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

            List<CountryResponse> actualCountrieResponse =  _countryService.GetAllCountries();

            foreach(CountryResponse expectedCountry in countriesFromAddCountry)
            {
                // Assert
                Assert.Contains(expectedCountry, actualCountrieResponse);
                //********Note about above line in the end of this file - This comment is from  171. Get All Countries - Implementation
            }
        }

        #endregion GetAllCountries

        /// -------------------------------- End of 170. Get All Countries - xUnit Test -----------------------------------

        #region GetCountryByCountryID
        /// -------------------------------- Start of 172. Get Country ID - xUnit Test -----------------------------------
        /// Generally the region names are same as the method names so that its easier to understand.
        /// 
        [Fact]
        public void GetCountryByCountryID_NullCountryID()
        {
            // Arrange
            Guid? guid = null;

            // Act
            CountryResponse? countryResponse = _countryService.GetCountryByCountryID(guid);

            // Assert 
            // If you expect the value to be not null then we write Assert.NotNull 
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
            // We have already overriden the Equals method in CountryResponse class.
            Assert.Equal(countryResponseGet, countryResponseAdd);
        }

        /// -------------------------------- End of 172. Get Country ID - xUnit Test -----------------------------------
        #endregion GetCountryByCountryID 


        /// -------------------------------- End of 166. xUnit Test 2 -----------------------------------
        /// 
    }
}

/// ------------------- Below have given in lecture 171. Get All Countries - Implementation ----------
// Note for : Assert.Contains(...  
///
/// Contains :-> Internally, it calls the equals method for each object.
/// That means it takes up 1st argument object and takes the element from 2nd argument
/// and calls the equals method between them to ensure both are equal.
/// And in the same way, for the second iteration, it takes the 1st argument object
/// but takes the second element from the 2nd argument.
/// Like that, it repeats the same process to ensure 1st argument element matches with at least one of the
/// elements in the list or not.
/// 
/// So it compares the objects with equals method.
/// That's what the point.
/// But the problem is the default functionality of the equals method is
/// it compares the reference instead of comparing the actual data.
/// 
/// We have to compare the country ID of the A object with the B object.
/// Same way, we have to compare the country name of the first object with the second object.
/// 
/// This functionality is not default.
/// We have to override, means implement yourself.
/// Exactly this is the situation where you will override the equals method.
/// So switch to the CountryResponseClass.
/// There we have added the code to override "Equals" method. 
/// Once this is done, only the this will work.
/// 
/// Since as per C# rule, if we override the Equals method,
/// we also need to override the GetHashCode method, so we have overridden it too.
/// 
/// In C-sharp, the getHashCode method makes the object
/// to be participate as a key in the dictionary.
/// That means if you override your own getHashCode of your class,
/// then those objects can be participate as a key in the dictionary.
/// We have kept the default code for GetHashCode in this case.
/// 
///
