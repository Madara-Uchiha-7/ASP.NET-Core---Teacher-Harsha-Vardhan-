using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// -------------------------------- Start of 176. Add Person - xUnit Test ---------------------------------
    /// Make it as a public interface so that we can call it in the web project
    /// and in the test project. Import the namespace of DTO. 
    /// 
    /// <summary>
    /// Represents the business logic for manipulating Person entity. 
    /// </summary>
    public interface IPersonService
    {

        /// <summary>
        /// It adds a new person into the existing list of Persons.
        /// </summary>
        /// <param name="personAddRequset">Person to add</param>
        /// <returns>Returns a person details, along with newly generated PersonID</returns>
        /// We made personAddRequset parameter as a nullable parameter because we want to check the null test case also.
        /// In that case we will be passing the null here.
        PersonResponse AddPerson(PersonAddRequset? personAddRequset);

        /// <summary>
        /// Returns all persons 
        /// </summary>
        /// <returns>A list of objects of PersonResponse type</returns>
        List<PersonResponse> GetAllPersons();
    }
    /// -------------------------------- End of 176. Add Person - xUnit Test ---------------------------------
}
