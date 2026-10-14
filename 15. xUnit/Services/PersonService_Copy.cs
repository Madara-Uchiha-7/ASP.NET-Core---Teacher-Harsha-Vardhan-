using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
/// -------------------------------- Start of 178. Add Person - Validation ---------------------------------
/// 
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Services
{
    public class PersonService_Copy : IPersonService_Copy
    {
        private readonly List<Person> _persons;
        private readonly ICountryService _countriesService;

        public PersonService_Copy()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }

        private PersonResponse PersonToPersonResponseWithCountry(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();

            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest_Copy personAddRequset)
        {
            if (personAddRequset == null)
                throw new ArgumentNullException(nameof(personAddRequset));

            // Model Validations:
            // We have to programmatically call the model validations related methods,
            // which are part of the ComponentModel.DataAnnotations
            // For this, here also, we need using System.ComponentModel.DataAnnotations; 
            // We will use ValidationContext.
            // The context object contains the reference to the model, which has to be validated.
            ValidationContext validationContext = new ValidationContext(personAddRequset);

            // And in order to store the validation errors,
            // we will create another object called list of ValidationResult.
            List<ValidationResult> validationResults = new List<ValidationResult>();

            // Then we need to call the predefined class called validator.
            // It has a method called tryValidateObject. It validates the entire model object,
            // So we need to pass the object which has to be validated, then ValidationContext object and then list which will hold the error
            // and then a boolean true. 
            // We have to supply a boolean value true to validate all model properties.
            // In case if you supply false or if you ignore the last parameter, it validates only the required parameters,
            // means only the required validation rules. We need to check all validations like range, email, etc, we are passing true.
            bool isValid = Validator.TryValidateObject(personAddRequset, validationContext, validationResults, true);
            // The TryValidateObject() returns true.
            // If true means validations are successfull, if any one fails then it will be false.

            if (!isValid)
            {
                // If we found any first error or default error then we return it as the ErrorMessage
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }

            Person person = personAddRequset.ToPerson();

            person.ID = Guid.NewGuid();

            _persons.Add(person);

            return PersonToPersonResponseWithCountry(person);

            /*
                The code from "ValidationContext validationContext"
                to code of "if (!isValid)" 
                You can Add it in the method, why? because this code part will be used in other methods also....
                So, we will be creating the helper class.
                That means the reusable class. And for other methods we will use that class.
                We will not use this class for this method, because this is where you understand how to use Validator and etc.
                So create in services project create new folder,
                Helpers -> add a class -> ValidationHelper.cs
                Check the code in it.
                You can use this class as below: (Import the namespace : Services.Helpers;)
                ValidationHelper.ModelValidation(your_obj_name);
            */
        }

        public List<PersonResponse> GetAllPersons()
        {
            /// -------------------------------- Start of 182. GetAllPersons - Implementation ---------------------------------
            ///
            // Select takes each object in _persons and one by one converts it into PersonResponse
            // In the end return IEnumerable of PersonResponse. We then Convert it into the list Using ToList() method.
            return _persons.Select(person =>person.ToPersonResponse()).ToList();

            /// -------------------------------- End of 182. GetAllPersons - Implementation ---------------------------------
        }

        /// -------------------------------- Start of 179. GetPersonByPersonID xUnit Test ---------------------------------
        /// 
        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            /// -------------------------------- Start of 180. GetPersonByPerson ID - Implementation ---------------------------------
            /// 
            if (personID == null)
                return null;

            // FirstOrDefault will return null if does not find any person with given id in the _persons list.
            // Since there is a null possibility, we have added the ? after the Person.
            Person? person = _persons.FirstOrDefault(person => person.ID == personID);

            if (person == null)
                return null;

            return person.ToPersonResponse();

            /// -------------------------------- End of 180. GetPersonByPerson ID - Implementation ---------------------------------
        }
        /// -------------------------------- End of 179. GetPersonByPersonID xUnit Test ---------------------------------


        /// -------------------------------- Start of 184. GetFilteredPersons - xUnit Test ---------------------------------
        ///
        // When I removed the public access modifier, I got the error called the class does not implement the 
        // method GetFilteredPerson().
        public List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString)
        {
            /// -------------------------------- Start of 185. GetFilteredPersons - Implementation ---------------------------------
            ///

            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(Person.Name):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Name) ? 
                            person.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(Person.Email):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Email) ?
                            person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(Person.DateOfBirth):
                    matchingPersons = allPersons.Where(
                        person => (
                            person.DateOfBirth != null ?
                            person.DateOfBirth.Value.ToString("dd MMMM yyyy ").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(Person.Gender):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Gender) ?
                            person.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                case nameof(Person.CountryID):
                    matchingPersons = allPersons.Where(
                        person => (
                            !string.IsNullOrEmpty(person.Country) ?
                            person.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true
                        )).ToList();
                    break;

                // Same cases you can add for address and other properties.

                default: 
                    matchingPersons = allPersons; 
                    break;

                // Contains method do not expect the null value, if it receives the null value then
                // it will throw the error, so each time we are checking the the value which we are passing 
                // is null or not.
            }

            return matchingPersons;
            /// -------------------------------- Start of 185. GetFilteredPersons - Implementation ---------------------------------
        }
        /// -------------------------------- End of 184. GetFilteredPersons - xUnit Test ---------------------------------

        /// -------------------------------- Start of 186. Get Sorted Persons - xUnit Test ---------------------------------
        /// 
        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            /// -------------------------------- Start of 187. GetSortedPersons - Implementation ---------------------------------
            /// 
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

                // Use reflection to avoid the repetition of code.
            };

            return sortedListPersons;
            /// -------------------------------- End of 187. GetSortedPersons - Implementation ---------------------------------
        }
        /// -------------------------------- End of 186. Get Sorted Persons - xUnit Test ---------------------------------

        /// -------------------------------- Start of 189. UpdatePerson - xUnit Test --------------------------------
        /// 
        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            /// -------------------------------- Start of 190. UpdatePerson - Implementation --------------------------------
            /// 

            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(personUpdateRequest));

            // Validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            // Get matching person object to update
            // FirstOrDefault returns null if no match found so we have to implement the "matchedPerson"
            Person? matchedPerson = _persons.FirstOrDefault(person => person.ID ==  personUpdateRequest.ID);

            if (matchedPerson == null)
                throw new ArgumentException("Given Person ID does not exist.");

            // Update the details
            matchedPerson.Name = personUpdateRequest.Name;
            matchedPerson.Email = personUpdateRequest.Email;
            matchedPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchedPerson.Gender = personUpdateRequest.Gender.ToString();
            matchedPerson.CountryID = personUpdateRequest.CountryID;
            matchedPerson.Address = personUpdateRequest.Address;
            matchedPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return matchedPerson.ToPersonResponse();
            /// -------------------------------- End of 190. UpdatePerson - Implementation --------------------------------
        }
        /// -------------------------------- End of 189. UpdatePerson - xUnit Test --------------------------------
        /// 

        /// -------------------------------- Start of 191. Delete Person - xUnit Test --------------------------------
        ///
        public bool DeletePerson(Guid? personID)
        {
            /// -------------------------------- Start of 192. Delete Person - Implementation --------------------------------
            /// 
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            Person? person = _persons.FirstOrDefault(person => person.ID == personID);

            if (person == null)
                return false;

            _persons.RemoveAll(person => person.ID == personID);

            return true;
            /// -------------------------------- End of 192. Delete Person - Implementation --------------------------------
        }
        /// -------------------------------- Start of 191. Delete Person - xUnit Test --------------------------------
        ///

    }
}
/// -------------------------------- End of 178. Add Person - Validation ---------------------------------