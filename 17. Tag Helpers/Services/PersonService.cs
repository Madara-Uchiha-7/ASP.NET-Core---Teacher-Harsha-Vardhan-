using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;
        private readonly ICountryService _countriesService;

        public PersonService(bool initialize = true)
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                _persons.AddRange(new List<Person>()
                {
                    new Person()
                    {
                        ID = Guid.Parse("58EFBDDD-5A26-4CA0-9FF5-2988D3A7793A"),
                        Name = "Stanislaw",
                        Email = "smaharey1@shinystat.com",
                        DateOfBirth = DateTime.Parse("01/02/2000"),
                        Gender = "Male",
                        Address = "3998 Morrow Place",
                        CountryID = Guid.Parse("D3EF2298-7BF9-4ED4-8D1E-3D5B9E234D8C"),
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        ID = Guid.Parse("6198711F-CBE8-4B20-B231-5B81C19D52F4"),
                        Name = "York",
                        Email = "ywitton0@lulu.com",
                        DateOfBirth = DateTime.Parse("10/04/2000"),
                        Gender = "Male",
                        Address = "49545 Hansons Lane",
                        CountryID = Guid.Parse("D3EF2298-7BF9-4ED4-8D1E-3D5B9E234D8C"),
                        ReceiveNewsLetters = true

                    },
                    new Person()
                    {
                        ID = Guid.Parse("9D5350D1-EC83-4725-8013-893AEC5C168B"),
                        Name = "Rockie",
                        Email = "rmatthensen2@amazonaws.com",
                        DateOfBirth = DateTime.Parse("10/01/1992"),
                        Gender = "Male",
                        Address = "271 Ohio Driv",
                        CountryID = Guid.Parse("D0264A93-7546-40EC-8E2E-76946B65CEE8"),
                        ReceiveNewsLetters = false
                    },
                    new Person()
                    {
                        ID = Guid.Parse("2DDE6107-EAED-4405-8D91-301B63EF61C7"),
                        Name = "Obediah",
                        Email = "odemichele3@shutterfly.com",
                        DateOfBirth = DateTime.Parse("8/03/1990"),
                        Gender = "Male",
                        Address = "60 7th Hill",
                        CountryID = Guid.Parse("D0264A93-7546-40EC-8E2E-76946B65CEE8"),
                        ReceiveNewsLetters = true
                    },
                    new Person()
                    {
                        ID = Guid.Parse("DD438518-2DE2-4EC8-BD02-4AE73CFCD3B1"),
                        Name = "Freedman",
                        Email = "fgoundsy4@parallels.com",
                        DateOfBirth = DateTime.Parse("2/10/1991"),
                        Gender = "Male",
                        Address = "0 Brentwood Hill",
                        CountryID = Guid.Parse("7BB6AA5F-FC92-428F-8E31-B830B170B5DE"),
                        ReceiveNewsLetters = true
                    }
                });
            }
        }

        private PersonResponse PersonToPersonResponseWithCountry(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();

            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest personAddRequset)
        {
            if (personAddRequset == null)
                throw new ArgumentNullException(nameof(personAddRequset));

            ValidationContext validationContext = new ValidationContext(personAddRequset);

            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(personAddRequset, validationContext, validationResults, true);
            
            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }

            Person person = personAddRequset.ToPerson();

            person.ID = Guid.NewGuid();

            _persons.Add(person);

            // person.ToPersonResponse();
            // Below line added for above line in lecture 201. Sort In List View - 2
            return PersonToPersonResponseWithCountry(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            //return _persons.Select(person => person.ToPersonResponse()).ToList();
            // Below line added for above line in lecture 201. Sort In List View - 2
            return _persons.Select(person => PersonToPersonResponseWithCountry(person)).ToList();
        }
 
        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
                return null;

            Person? person = _persons.FirstOrDefault(person => person.ID == personID);

            if (person == null)
                return null;

            // person.ToPersonResponse(); 
            // Below line added for above line in lecture 201. Sort In List View - 2
            return PersonToPersonResponseWithCountry(person);

        }

        public List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(PersonResponse.Name):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Name) ? 
                            person.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(PersonResponse.Email):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Email) ?
                            person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(
                        person => (
                            person.DateOfBirth != null ?
                            person.DateOfBirth.Value.ToString("dd MMMM yyyy ").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Gender) ?
                            person.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(PersonResponse.CountryID):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Country) ?
                            person.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                default: 
                    matchingPersons = allPersons; 
                    break;
            }

            return matchingPersons;
        }
        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (sortBy == null)
                return allPersons;

            List<PersonResponse> sortedListPersons = (sortBy, sortOrder)
                switch
            {
                (nameof(PersonResponse.Name), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.Name, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Name), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Name, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.Email, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Email, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.DateOfBirth
                    ).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.DateOfBirth
                    ).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.Age
                    ).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Age
                    ).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.Gender, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Gender, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC) =>
                   allPersons.OrderBy
                   (person =>
                       person.Country, StringComparer.OrdinalIgnoreCase
                   ).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Country, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.Address, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.Address, StringComparer.OrdinalIgnoreCase
                    ).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) =>
                    allPersons.OrderBy
                    (person =>
                        person.ReceiveNewsLetters
                    ).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) =>
                    allPersons.OrderByDescending
                    (person =>
                        person.ReceiveNewsLetters
                    ).ToList(),

                _ => allPersons

            };

            return sortedListPersons;
        }
        
        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(personUpdateRequest));

            // Validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            Person? matchedPerson = _persons.FirstOrDefault(person => person.ID ==  personUpdateRequest.ID);

            if (matchedPerson == null)
                throw new ArgumentException("Given Person ID does not exist.");

            matchedPerson.Name = personUpdateRequest.Name;
            matchedPerson.Email = personUpdateRequest.Email;
            matchedPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchedPerson.Gender = personUpdateRequest.Gender.ToString();
            matchedPerson.CountryID = personUpdateRequest.CountryID;
            matchedPerson.Address = personUpdateRequest.Address;
            matchedPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            // return matchedPerson.ToPersonResponse();
            // Below line added for above line in lecture 201. Sort In List View - 2
            return PersonToPersonResponseWithCountry(matchedPerson);
        }
        public bool DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            Person? person = _persons.FirstOrDefault(person => person.ID == personID);

            if (person == null)
                return false;

            _persons.RemoveAll(person => person.ID == personID);

            return true;
        }
    }
}
