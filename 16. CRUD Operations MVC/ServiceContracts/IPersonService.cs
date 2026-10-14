using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse AddPerson(PersonAddRequest? personAddRequset);
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Returns the Person object based on the given person ID.
        /// </summary>
        /// <param name="personID">Person Id to search</param>
        /// <returns>A matching person object</returns>
        PersonResponse? GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Returns all person objects that matches with the given search field and search string.
        /// </summary>
        /// <param name="searchBy">Search Field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>Returns all matching persons based on the given search field and search string.</returns>
        List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString);

        ///<summary>
        /// Returns the Sorted List of persons
        /// </summary>
        /// <param name="allPersons">Represents list of persons to sort</param>
        /// <param name="sortBy">Name of the Property (key), based on which the person should be sorted</param>
        /// <param name="sortOrder">ASC or DESC</param>
        /// <returns>The list of sorted Persons</returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);

        ///<summary>
        /// Updates the specified person details based on the given Person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person details to update, including the person ID</param>
        /// <returns>Updated Person response object</returns>
        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);

        ///<summary>
        /// Deletes the person of given Person ID
        /// </summary>
        /// <param name="personID">person ID using which you will delete the person</param>
        /// <returns>true if delete is successfull otherwise false</returns>
        bool DeletePerson(Guid? personID);
    }
}
