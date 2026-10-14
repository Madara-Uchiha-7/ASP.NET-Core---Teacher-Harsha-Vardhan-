using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using Entities;
using Xunit.Abstractions;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;
        private readonly ITestOutputHelper _testOutputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _personService = new PersonService(false);
            _countryService = new CountriesService(false);
            _testOutputHelper = testOutputHelper; 
        }

        #region AddPerson

        /// <summary>
        /// When we supply the null value as PersonAddRequest, it should throw ArgumentNullException
        /// </summary>
        [Fact]
        public void AddPerson_NullPerson()
        {
            // Arrange
            PersonAddRequest personAddRequset = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _personService.AddPerson(personAddRequset);
            });
        }

        [Fact]
        public void AddPerson_PersonNameNull()
        {
            // Arrange
            PersonAddRequest personAddRequset = new PersonAddRequest() { Name = null };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _personService.AddPerson(personAddRequset);
            });
        }

        /// <summary>
        /// If we supply proper details then it should add them in the list.
        /// </summary>
        /// <returns>An object of PersonResponse which includes with newly generated Person ID</returns>
        public void AddPerson_ProperPersonDetails()
        {
            // Arrange
            PersonAddRequest personAddRequset = new PersonAddRequest()
            {
                Name = "Harsha",
                Email = "teacher@udemy.com",
                Address = "Bharat",
                CountryID = Guid.NewGuid(),
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            // Act
            PersonResponse personResponseFromAdd = _personService.AddPerson(personAddRequset);
            List<PersonResponse> personList = _personService.GetAllPersons();

            // Aseert
            Assert.True(personResponseFromAdd.ID != Guid.Empty);

            Assert.Contains(personResponseFromAdd, personList);
        }

        #endregion AddPerson

        #region GetPersonByPersonID

        [Fact]
        public void GetPersonByPersonID_NullPersonID()
        {
            // Arrange
            Guid? personID = null;

            // Act
            PersonResponse personResponseFromGet = _personService.GetPersonByPersonID(personID);

            // Assert
            Assert.Null(personResponseFromGet);
        }

        [Fact]
        public void GetPersonByPersonID_WithPersonID()
        {
            // Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "Canada"
            };
            CountryResponse countryResponse = _countryService.AddCountry(countryAddRequest);

            // Act
            PersonAddRequest personAddRequset = new PersonAddRequest()
            {
                Name = "Harsha the Teacher",
                Email = "Harsha@udemy.com",
                Address = "Earth",
                CountryID = countryResponse.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            PersonResponse personResposneFromAdd = _personService.AddPerson(personAddRequset);

            PersonResponse? personResposneFromGet = _personService.GetPersonByPersonID(personResposneFromAdd.ID);

            // Arrange
            Assert.Equal(personResposneFromGet, personResposneFromAdd);
        }

        #endregion GetPersonByPersonID

        #region GetAllPersons
        [Fact]
        public void GetAllPersons_EmptyList() // Before you add any Person, the list must be empty
        {
            // Act
            List<PersonResponse> personResponseFromGet = _personService.GetAllPersons();

            // Assert
            Assert.Empty(personResponseFromGet);
        }

        [Fact]
        public void GetAllPersons_AddFewPersons()
        {
            // Arrange
            CountryAddRequest usa = new CountryAddRequest()
            { CountryName = "USA" };

            CountryAddRequest india = new CountryAddRequest()
            { CountryName = "India" };

            CountryResponse usaAdded = _countryService.AddCountry(usa);
            CountryResponse indiaAdded = _countryService.AddCountry(india);

            PersonAddRequest john = new PersonAddRequest()
            {
                Name = "John the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = usaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            PersonAddRequest krystina = new PersonAddRequest()
            {
                Name = "Krystina the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = indiaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>()
            {
                john,
                krystina
            };
            List<PersonResponse> addedPersons = new List<PersonResponse>();

            foreach (PersonAddRequest personToAdd in peopleToAdd)
            {
                PersonResponse addedPerson = _personService.AddPerson(personToAdd);
                addedPersons.Add(addedPerson);  // Response after we add the Person
            }

            _testOutputHelper.WriteLine("The Persons which we have added and the Response we got for each of them After add:");
            foreach (PersonResponse personResponse in addedPersons)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Act
            List<PersonResponse> allPersonList = _personService.GetAllPersons();

            _testOutputHelper.WriteLine("Total Successfully added persons:");
            foreach (PersonResponse personResponse in allPersonList)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Assert
            foreach (PersonResponse addedPerson in addedPersons)
            {
                Assert.Contains(addedPerson, allPersonList);
            }
        }

        #endregion GetAllPersons

        #region GetFilteredPersons

        // If search text is empty and search by is "PersonName", its should return all persons 
        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            // Arrange
            CountryAddRequest usa = new CountryAddRequest()
            { CountryName = "USA" };

            CountryAddRequest india = new CountryAddRequest()
            { CountryName = "India" };

            CountryResponse usaAdded = _countryService.AddCountry(usa);
            CountryResponse indiaAdded = _countryService.AddCountry(india);

            PersonAddRequest john = new PersonAddRequest()
            {
                Name = "John the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = usaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            PersonAddRequest krystina = new PersonAddRequest()
            {
                Name = "Krystina the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = indiaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>()
            {
                john,
                krystina
            };
            List<PersonResponse> addedPersons = new List<PersonResponse>();

            foreach (PersonAddRequest personToAdd in peopleToAdd)
            {
                PersonResponse addedPerson = _personService.AddPerson(personToAdd);
                addedPersons.Add(addedPerson);  
            }

            // Print :
            _testOutputHelper.WriteLine("The Persons which we have added and the Response we got for each of them After add:");
            foreach (PersonResponse personResponse in addedPersons)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Act
            List<PersonResponse> personListFromSearch = _personService.GetFilteredPerson(nameof(Person.Name), "");

            _testOutputHelper.WriteLine("After Search:");
            foreach (PersonResponse personResponse in personListFromSearch)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Assert
            foreach (PersonResponse addedPerson in addedPersons)
            {
                Assert.Contains(addedPerson, personListFromSearch); // Note type of both arguments should be same in .Contains
            }
        }


        // First we will add few persons; and then we will search 
        // based on person with some search string. It should return the matching persons.
        [Fact]
        public void GetFilteredPersons_SearchByPersonName()
        {
            // Arrange
            CountryAddRequest usa = new CountryAddRequest()
            { CountryName = "USA" };

            CountryAddRequest india = new CountryAddRequest()
            { CountryName = "India" };

            CountryResponse usaAdded = _countryService.AddCountry(usa);
            CountryResponse indiaAdded = _countryService.AddCountry(india);

            PersonAddRequest john = new PersonAddRequest()
            {
                Name = "John the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = usaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            PersonAddRequest krystina = new PersonAddRequest()
            {
                Name = "Krystina the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = indiaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>()
            {
                john,
                krystina
            };
            List<PersonResponse> addedPersons = new List<PersonResponse>();

            foreach (PersonAddRequest personToAdd in peopleToAdd)
            {
                PersonResponse addedPerson = _personService.AddPerson(personToAdd);
                addedPersons.Add(addedPerson);  // Response after we add the Person
            }

            // Print :
            _testOutputHelper.WriteLine("The Persons which we have added and the Response we got for each of them After add:");
            foreach (PersonResponse personResponse in addedPersons)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Act
            List<PersonResponse> personListFromSearch = _personService.GetFilteredPerson(nameof(Person.Name), "ry");

            _testOutputHelper.WriteLine("After Search:");
            foreach (PersonResponse personResponse in personListFromSearch)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            // Assert
            foreach (PersonResponse addedPerson in addedPersons)
            {
                if (addedPerson.Name != null && addedPerson.Name.Contains("ry", StringComparison.OrdinalIgnoreCase))
                {
                    // Note type of both arguments should be same in .Contains
                    Assert.Contains(addedPerson, personListFromSearch);
                }
            }
        }

        #endregion GetFilteredPersons

        #region GetSortedPersons

        // When we sort based on the Person Name in DESC, it should return the persons in desc order for Person name.
        [Fact]
        public void GetSortedPersons()
        {
            // Arrange
            CountryAddRequest usa = new CountryAddRequest()
            { CountryName = "USA" };

            CountryAddRequest india = new CountryAddRequest()
            { CountryName = "India" };

            CountryResponse usaAdded = _countryService.AddCountry(usa);
            CountryResponse indiaAdded = _countryService.AddCountry(india);

            PersonAddRequest john = new PersonAddRequest()
            {
                Name = "John the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = usaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            PersonAddRequest krystina = new PersonAddRequest()
            {
                Name = "Krystina the Teacher",
                Email = "John@udemy.com",
                Address = "Earth",
                CountryID = indiaAdded.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>()
            {
                john,
                krystina
            };
            List<PersonResponse> addedPersons = new List<PersonResponse>();

            foreach (PersonAddRequest personToAdd in peopleToAdd)
            {
                PersonResponse addedPerson = _personService.AddPerson(personToAdd);
                addedPersons.Add(addedPerson);
            }

            // Print :
            _testOutputHelper.WriteLine("The Persons which we have added and the Response we got for each of them After add:");
            foreach (PersonResponse personResponse in addedPersons)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            List<PersonResponse> allPersons = _personService.GetAllPersons();

            // Act
            List<PersonResponse> personListFromSort = _personService.GetSortedPersons(allPersons, nameof(Person.Name), SortOrderOptions.DESC);

            _testOutputHelper.WriteLine("After Search:");
            foreach (PersonResponse personResponse in personListFromSort)
            {
                _testOutputHelper.WriteLine(personResponse.ToString());
            }

            addedPersons = addedPersons.OrderByDescending(person => person.Name).ToList();

            // Assert
            for (int i = 0; i < addedPersons.Count; i++)
            {
                Assert.Equal(addedPersons[i], personListFromSort[i]);
            }
        }

        #endregion GetSortedPersons
 
        #region UpdatePerson

        // When supply null value for a PersonUpdateRequest, it should throw the ArgumentNullException
        [Fact]
        public void UpdatePerson_NullPerson()
        {
            // Arrage
            PersonUpdateRequest? personUpdateRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => _personService.UpdatePerson(personUpdateRequest));
        }


        // If person id is invalid then should throw Argument Exception
        [Fact]
        public void UpdatePerson_InvalidPersonID()
        {
            // Arrage
            PersonUpdateRequest? personUpdateRequest = new PersonUpdateRequest()
            {
                ID = Guid.NewGuid()
            };

            // Assert
            Assert.Throws<ArgumentException>(() => _personService.UpdatePerson(personUpdateRequest));
        }

        // When the person name is null it should throw Argument Exception
        [Fact]
        public void UpdatePerson_PersonNameIsNull()
        {
            // Arrage
            CountryAddRequest country = new CountryAddRequest()
            {
                CountryName = "Bharat"

            };
            CountryResponse addedCountryBharat = _countryService.AddCountry(country);

            PersonAddRequest person = new PersonAddRequest()
            {
                Name = "Tom",
                CountryID = addedCountryBharat.CountryID,
                Email = "Tom@Jerry.com",
                Address = "Mars",
                Gender = GenderOptions.Male
            };
            PersonResponse addedPersonTom = _personService.AddPerson(person);

            PersonUpdateRequest personUpdateRequest = addedPersonTom.ToPersonUpdateRequest();

            personUpdateRequest.Name = null;

            // Assert
            Assert.Throws<ArgumentException>(() => {
                // Act
                _personService.UpdatePerson(personUpdateRequest);
            });
        }

        // When new person is added, and then we update it, it should be added successfully
        [Fact]
        public void UpdatePerson_PersonFullDetailsUpdation()
        {
            // Arrage
            CountryAddRequest country = new CountryAddRequest()
            {
                CountryName = "Bharat"

            };
            CountryResponse addedCountryBharat = _countryService.AddCountry(country);

            PersonAddRequest person = new PersonAddRequest()
            {
                Name = "Tom",
                CountryID = addedCountryBharat.CountryID,
                Address = "Earth",
                DateOfBirth = DateTime.Parse("01-01-2000"),
                Email = "Tom@Jerry.com",
                Gender = GenderOptions.Female,
                ReceiveNewsLetters = false
            };
            PersonResponse addedPersonTom = _personService.AddPerson(person);

            PersonUpdateRequest personUpdateRequest = addedPersonTom.ToPersonUpdateRequest();

            personUpdateRequest.Name = "Tomi";
            personUpdateRequest.Email = "Tomi@Jerry.com";

            // Act
            PersonResponse updatedPerson = _personService.UpdatePerson(personUpdateRequest);

            PersonResponse? updatedPersonCheck = _personService.GetPersonByPersonID(updatedPerson.ID);
            // Assert
            Assert.Equal(updatedPersonCheck, updatedPerson);
        }

        #endregion UpdatePerson

        #region DeletePerson

        // If you supply an valid person id then it should return true
        [Fact]
        public void DeletePerson_ValidPersonID()
        {
            // Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "France"
            };

            CountryResponse addedCountry = _countryService.AddCountry(countryAddRequest);

            PersonAddRequest personToAdd = new PersonAddRequest()
            {
                Name = "Batman",
                Address = "City",
                CountryID = addedCountry.CountryID,
                DateOfBirth = DateTime.Parse("01-01-2000"),
                Email = "SaveThe@City.com",
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true
            };

            PersonResponse addedPerson = _personService.AddPerson(personToAdd);

            // Act
            bool deletedPersonIsSuccess = _personService.DeletePerson(addedPerson.ID);

            // Assert
            Assert.True(deletedPersonIsSuccess);
        }

        // If you supply an invalid person id then it should return false
        [Fact]
        public void DeletePerson_InvalidPersonID()
        {
            // Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "France"
            };

            CountryResponse addedCountry = _countryService.AddCountry(countryAddRequest);

            PersonAddRequest personToAdd = new PersonAddRequest()
            {
                Name = "Batman",
                Address = "City",
                CountryID = addedCountry.CountryID,
                DateOfBirth = DateTime.Parse("01-01-2000"),
                Email = "SaveThe@City.com",
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true
            };

            PersonResponse addedPerson = _personService.AddPerson(personToAdd);

            // Act
            bool deletedPersonIsSuccess = _personService.DeletePerson(Guid.NewGuid());

            // Assert
            Assert.False(deletedPersonIsSuccess);
        }

        #endregion DeletePerson
    }
}
