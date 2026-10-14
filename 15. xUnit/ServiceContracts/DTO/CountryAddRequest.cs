using System;
using System.Collections.Generic;
using Entities; // Dont do: "using Entities.Country". It did not work

namespace ServiceContracts.DTO
{

    /// -------------------------------- Start of 166. xUnit Test-----------------------------------
    /// 
    /// <summary>
    /// DTO Class for adding a new Country.
    /// </summary>
    public class CountryAddRequest
    {
        // It contains only one, that is, CountryName. It doesn't contain the CountryID.
        // Because while inserting the data, we will not have the CountryID with us,
        // but we will have a CountryName which is entered by the user.
        // So after adding this country as an object in the list of countries,
        // then the CountryID, that means the GUID should be generated automatically.
        // That means the CountryID is unknown before adding.
        // Since Country.cs is a Domain Model, it has both Country Id and name.
        public string? CountryName { get; set; }

        // But as a part of the Service class, after validating this CountryName, if it is correct,
        // we have to convert the same into Country object in order to add the same into the actual data source.
        // For example, we have to insert the same into ListOfCountry as DataStore.
        // So at that point of time, you have to convert the country details
        // from the CountryAddRequest into the Country class.
        // In order to make it easy, we are going to create a method called public Country ToCountry.
        // It is a custom method which creates and returns an object of the Country class
        // and which initializes the CountryName.
        public Country ToCountry()
        { 
            return new Country() { CountryName = CountryName };
        }
        // So by calling ToCountry method in the service, you can easily convert an existing CountryAddRequest object into Country class.
        // We will do that in the next lecture while implementation.
    }
    /// -------------------------------- End of 166. xUnit Test-----------------------------------
}
