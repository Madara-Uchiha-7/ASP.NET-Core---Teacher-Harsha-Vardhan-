using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// -------------------------------- Start of 178. Add Person - Validation ---------------------------------
namespace ServiceContracts
{
    public interface IPersonService_Copy
    {
        PersonResponse AddPerson(PersonAddRequest_Copy? personAddRequsetCopy);
        List<PersonResponse> GetAllPersons();

        /// -------------------------------- Start of 179. GetPersonByPersonID xUnit Test ---------------------------------
        /// <summary>
        /// Returns the Person object based on the given person ID.
        /// </summary>
        /// <param name="personID">Person Id to search</param>
        /// <returns>A matching person object</returns>
        PersonResponse? GetPersonByPersonID(Guid? personID);
        /// -------------------------------- End of 179. GetPersonByPersonID xUnit Test ---------------------------------
        /// 


        /// -------------------------------- Start of 184. GetFilteredPersons - xUnit Test ---------------------------------
        /// 
        /// <summary>
        /// Returns all person objects that matches with the given search field and search string.
        /// </summary>
        /// <param name="searchBy">Search Field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>Returns all matching persons based on the given search field and search string.</returns>
        List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString);

        /// -------------------------------- End of 184. GetFilteredPersons - xUnit Test ---------------------------------
        /// 

        /// -------------------------------- Start of. 186. Get Sorted Persons - xUnit Test ---------------------------------
        ///<summary>
        /// Returns the Sorted List of persons
        /// </summary>
        /// <param name="allPersons">Represents list of persons to sort</param>
        /// <param name="sortBy">Name of the Property (key), based on which the person should be sorted</param>
        /// <param name="sortOrder">ASC or DESC</param>
        /// <returns>The list of sorted Persons</returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
        /// -------------------------------- End of. 186. Get Sorted Persons - xUnit Test ---------------------------------


        /// -------------------------------- Start of 189. UpdatePerson - xUnit Test --------------------------------
        /// 

        ///<summary>
        /// Updates the specified person details based on the given Person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person details to update, including the person ID</param>
        /// <returns>Updated Person response object</returns>
        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
        /// -------------------------------- End of 189. UpdatePerson - xUnit Test --------------------------------

        /// -------------------------------- Start of 191. Delete Person - xUnit Test --------------------------------
        ///
        ///<summary>
        /// Deletes the person of given Person ID
        /// </summary>
        /// <param name="personID">person ID using which you will delete the person</param>
        /// <returns>true if delete is successfull otherwise false</returns>
        bool DeletePerson(Guid? personID);
        /// -------------------------------- Start of 191. Delete Person - xUnit Test --------------------------------
        ///


    }
}
/// -------------------------------- End of 178. Add Person - Validation ---------------------------------
