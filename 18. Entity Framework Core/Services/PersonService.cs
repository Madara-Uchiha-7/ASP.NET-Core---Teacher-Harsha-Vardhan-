using Azure;
using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonsDbContext _db;
        private readonly ICountryService _countriesService;

        public PersonService(PersonsDbContext personsDbContext, ICountryService countryService)
        {
            _db = personsDbContext;
            _countriesService = countryService;
        }

        private PersonResponse PersonToPersonResponseWithCountry(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();

            // personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
            // Above line was commented in the lecture 231. Table Relations with EF
            // Below was added for it:
            personResponse.Country = person.Country?.CountryName;
            // Som,

            return personResponse;
        }

        //public PersonResponse AddPerson(PersonAddRequest personAddRequset)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<PersonResponse> AddPerson(PersonAddRequest personAddRequset)
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

            // _db.Persons.Add(person);
            // _db.SaveChanges();
            // Above lines are commented in lecture : 227. EF Stored Proc with Parameters and added below one line:
            // _db.sp_InsertPerson(person);
            // Above line was commented and below was added in lecture:
            // 228. Changes in Table Structure
            _db.Persons.Add(person);
            
            //_db.SaveChanges();
            // The above line is commented and replaced in "232. Async EF Operations"
            await _db.SaveChangesAsync();

            //return PersonToPersonResponseWithCountry(person);
            // Above line is updaed in lecture 231. Table Relations with EF
            return person.ToPersonResponse();
        }

        //public List<PersonResponse> GetAllPersons()
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<List<PersonResponse>> GetAllPersons()
        {
            //return _db.Persons.Select(person => person.ToPersonResponse()).ToList();
            // Below line added for above line in lecture 201. Sort In List View - 2
            //return _db.Persons.ToList().Select(person => PersonToPersonResponseWithCountry(person)).ToList();
            // Below line added for above line in lecture 226. EF Stored Proc
            // return _db.sp_GetAllPersons().Select(person => PersonToPersonResponseWithCountry(person)).ToList();
            // Above line was commented and below was added in lecture:
            // 228. Changes in Table Structure
            //return _db.Persons.ToList().Select(person => PersonToPersonResponseWithCountry(person)).ToList();

            // Above line was commented and below was added in lecture:
            // 231. Table relations with EF
            //var persons = _db.Persons.Include("Country").ToList();
            // The above line is commented and replaced in "232. Async EF Operations"
            var persons = await _db.Persons.Include("Country").ToListAsync();


            // return persons.Select(person => PersonToPersonResponseWithCountry(person)).ToList();
            // Above line is updaed in lecture 231. Table Relations with EF
            return persons.Select(temp => temp.ToPersonResponse()).ToList();
            // Above line, we did not added ToListAsync() instead of ToList()
            // because in above line we are not calling the database. We are 
            // performing our normal c# operation.
            // Only IO-bound operations can be converted into asynchronous methods.

            /*
                Why we added ToList() : in "_db.Persons.ToList()." in lecture 201. Sort In List View - 2
                Think of _db.Persons as data sitting in the database.
                There are two worlds: DATABASE WORLD and  C# WORLD
                Before .ToList() → you're asking the database for data.
                After .ToList() → you have the data in C#.
                So, after "_db.Persons.ToList()" , the Persons are in C#.
                Then ".Select(person => PersonToPersonResponseWithCountry(person))"
                means hello C#, take each Person and run my C# method on it.
                If you do not add .ToList() then
                the code "_db.Persons.Select(person => PersonToPersonResponseWithCountry(person))"
                Means, "Database, run this C# method."
                But the database doesn't know your C# method i.e. the 
                the code we wrote in "PersonToPersonResponseWithCountry(person)"
                SQL Server doesn't know what that method means. 
                So you first do: .ToList()
                to say: "Okay, get the Persons from the database first."
            */
        }

        //public PersonResponse? GetPersonByPersonID(Guid? personID)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<PersonResponse?> GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
                return null;

            // Person? person = _db.Persons.FirstOrDefault(person => person.ID == personID);
            // Above line is updated in lecture, 231. Table relations with EF.
            // Person? person = _db.Persons.Include(person => person.Country).FirstOrDefault(person => person.ID == personID);
            // Include(person => person.Country) means :
            // "When I get this Person, also fetch the Country related through CountryID."
            // The above line is commented and replaced in "232. Async EF Operations"
            Person? person = await _db.Persons.Include(person => person.Country).FirstOrDefaultAsync(person => person.ID == personID);

            if (person == null)
                return null;

            // person.ToPersonResponse(); 
            // Below line added for above line in lecture 201. Sort In List View - 2

            //return PersonToPersonResponseWithCountry(person);
            // Above line is updaed in lecture 231. Table Relations with EF
            return person.ToPersonResponse();

        }

        //public List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<List<PersonResponse>> GetFilteredPerson(string searchBy, string? searchString)
        {
            //List<PersonResponse> allPersons = GetAllPersons();
            // The above line is commented and replaced in "232. Async EF Operations"
            List<PersonResponse> allPersons = await GetAllPersons();
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
        //public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<List<PersonResponse>> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
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

        //public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(personUpdateRequest));

            // Validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            // Person? matchedPerson = _db.Persons.FirstOrDefault(person => person.ID == personUpdateRequest.ID);
            // The above line is commented and replaced in "232. Async EF Operations"
            Person? matchedPerson = await _db.Persons.FirstOrDefaultAsync(person => person.ID == personUpdateRequest.ID);

            if (matchedPerson == null)
                throw new ArgumentException("Given Person ID does not exist.");

            matchedPerson.Name = personUpdateRequest.Name;
            matchedPerson.Email = personUpdateRequest.Email;
            matchedPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchedPerson.Gender = personUpdateRequest.Gender.ToString();
            matchedPerson.CountryID = personUpdateRequest.CountryID;
            matchedPerson.Address = personUpdateRequest.Address;
            matchedPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            //_db.SaveChanges();
            // The above line is commented and replaced in "232. Async EF Operations"
            await _db.SaveChangesAsync();

            //return PersonToPersonResponseWithCountry(matchedPerson);
            // Above line is updaed in lecture 231. Table Relations with EF
            return matchedPerson.ToPersonResponse();

        }
        // public bool DeletePerson(Guid? personID)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<bool> DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            //Person? person = _db.Persons.FirstOrDefault(person => person.ID == personID);
            // The above line is commented and replaced in "232. Async EF Operations"
            Person? person = await _db.Persons.FirstOrDefaultAsync(person => person.ID == personID);

            if (person == null)
                return false;

            _db.Persons.Remove(_db.Persons.First(person => person.ID == personID));

            //_db.SaveChanges();
            // The above line is commented and replaced in "232. Async EF Operations"
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
