using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;

namespace Services
{
    /// -------------------------------- Start of 176. Add Person - xUnit Test ---------------------------------
    /// We make it a public class so that we can acceess the same in the test as well as controller.
    /// This class implements the IPersonService. So we implements the methods related to it also.
    /// <summary>
    /// 
    /// </summary>
    public class PersonsService : IPersonService
    {
        private readonly List<Person> _persons;

        // Below property, we are using dependency injection
        // When we want to inject one service into another service, we can use the Dependency Injection.
        // 
        private readonly ICountryService _countriesService;

        public PersonsService()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }

        private PersonResponse PersonToPersonResponseWithCountry(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();

            // ?. : Null coalescing operator.
            // If the "_countriesService.GetCountryByCountryID(person.CountryID)"
            // is null, then do not access the ContryName and assign null to "personResponse.Country"
            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

            return personResponse;
        }

        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personAddRequset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PersonResponse AddPerson(PersonAddRequset personAddRequset)
        {
            /// -------------------------------- Start of 177. Add Person - Implementation---------------------------------
            if (personAddRequset == null)
                throw new ArgumentNullException(nameof(personAddRequset));

            if (string.IsNullOrEmpty(personAddRequset.Name))
                throw new ArgumentException($"Name of the {typeof(Person)} can not be blank");

            // We can also add the validations for other properties.

            Person person = personAddRequset.ToPerson();

            person.ID = Guid.NewGuid();

            _persons.Add(person);

            return PersonToPersonResponseWithCountry(person);

            /// -------------------------------- End of 177. Add Person - Implementation---------------------------------
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<PersonResponse> GetAllPersons()
        {
            /// -------------------------------- Start of 177. Add Person - Implementation---------------------------------
            throw new NotImplementedException();
            /// -------------------------------- End of 177. Add Person - Implementation--------------------------------
        }
    }
    /// -------------------------------- End of 176. Add Person - xUnit Test ---------------------------------
}
