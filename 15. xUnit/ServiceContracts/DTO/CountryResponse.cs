using System;
using Entities;

namespace ServiceContracts.DTO
{
    /// -------------------------------- Start of 166. xUnit Test 2 -----------------------------------
    /// <summary>
    /// DTO class that is used as a return type for most of CountryResponse methods.
    /// </summary>
    public class CountryResponse
    {
        /// This CountryResponse class includes with two properties.
        /// Because every time when a method of the service returns,
        /// each country should contain two things, that is CountryId and CountryName.
        /// 
        /// For example, we are retrieving the list of countries from existing data source.
        /// It should include with both id and name, right?
        ///
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        /// As a part of bussiness logic, we have to convert the data from the country object into the CountryResponse.
        /// For example, the user is trying to retrieve all existing countries.
        /// By default, you have list of country, means list of entity model called country.
        /// So, each of these country objects should be converted into the CountryResponse.
        /// So, in this, we are going to add an extension method called
        /// to ToCountryResponse, which converts the data from the country object into CountryResponse.
        ///

        /// -------------------------------- Start of 171. Get All Countries - Implementation -----------------------------------
        ///
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }
            CountryResponse countryResponse = (CountryResponse) obj;
            return (this.CountryID == countryResponse.CountryID && this.CountryName == countryResponse.CountryName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// -------------------------------- End of 171. Get All Countries - Implementation -----------------------------------
    }
    public static class CountryExtensions
    {
        /// <summary>
        /// This extension method is going to be injected into the Country class.
        /// which is the entities class.
        /// Means it behaves like this method was added to the Country class itself.
        /// </summary>
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName,
            };
        }
    }
    /// -------------------------------- End of 166. xUnit Test 2 -----------------------------------
}
