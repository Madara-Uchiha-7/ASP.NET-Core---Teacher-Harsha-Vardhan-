using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // To Access the class called Fact
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Entities;
using Services;

namespace CRUDTests
{
    /// -------------------------------- Start of 176. Add Person - xUnit Test ---------------------------------
    /// We make the class public
    /// <summary>
    /// 
    /// </summary>
    public class PersonsServiceTest
    {
        // We have to inject an object of the IPersonsService. So lets create a privare readonly field for it.
        private readonly IPersonService _personService;

        public PersonsServiceTest()
        {
            _personService = new PersonsService();
        }

        #region AddPerson
        /// <summary>
        /// When we supply the null value as PersonAddRequest, it should throw ArgumentNullException
        /// </summary>
        [Fact]
        public void AddPerson_NullPerson()
        {
            // Arrange
            PersonAddRequset personAddRequset = null;

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
            PersonAddRequset personAddRequset = new PersonAddRequset() { Name = null};

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _personService.AddPerson(personAddRequset);
            });
        }
        // You can write many more test cases like email's format', minimum Date of birth, as many as you want.

        /// <summary>
        /// If we supply proper details then it should add them in the list.
        /// </summary>
        /// <returns>An object of PersonResponse which includes with newly generated Person ID</returns>
        public void AddPerson_ProperPersonDetails()
        {
            /// Remember, every unit test case executed as independent.
            /// The data that was inserted in the previous unit test cases
            /// will not be carried forward to the upcoming unit test cases.
            /// Means, the person's list is basically empty
            /// for every individual unit test case.
            /// So, we can write some dummy person details.
            /// 
            // Arrange
            PersonAddRequset personAddRequset = new PersonAddRequset()
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
    }
    /// -------------------------------- End of 176. Add Person - xUnit Test ---------------------------------
}
