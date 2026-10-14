namespace Entities
{
    /// -------------------------------- Start of 166. xUnit Test-----------------------------------
    /// 
    /// <summary>
    /// If you give the /// above the class name then VS will automatically 
    /// create Documentation Comments or XML comments, i.e. in which we are currently writing this.
    /// Here you can write the documentation comment.
    /// This below class is called as the Domain Model.
    /// So this is the Domain Model for storing the Country Details.
    /// You will not expose this domain model
    /// to the presentation layer, even to the controller. Because the view as well as controller are being
    /// a part of the presentation layer. So, you will not expose this Country class either as argument
    /// or return type to the controller. That is why we are trying to implement the DTO, that is,
    /// Data Transfer Objects. The controller sends the country details as an object of CountryAddRequest,
    /// which is the DTO. Instead, it doesn't create and send an object of Country class.
    /// In that way, the service creates a protection layer surrounding the domain.
    /// Lets create a DTO in seperate class Library. 
    /// Lets call it as "ServiceContracts"
    /// This will contain the service contracts, that means interfaces, as well as DTO classes.
    /// Rename the class1 file to ICountryService.cs
    /// It is helpful for dependency injection.
    /// Lets create a DTO classes.
    /// In ServiceContracts right click -> Add new folder -> "DTO" 
    /// In this add : CountryAddRequest.cs and 
    /// Make it a public class from internal.
    /// Check that classe.
    /// In it, declare the properties that you want to include in the
    /// CountryAddRequest.
    /// Check the code and comments in that class.
    /// We have to add a project reference in ServiceContracts 
    /// of Entities so that it can use the Conntry class.
    /// Then import it using "using" statement.
    /// 
    /// </summary>
    public class Country
    {
        // There is a specific max limit for the integer and long,
        // There is no such max limit for the guide.
        // Because the GUID or guide is dynamically generated
        // based on the timestamp and a random number and machine-specific MAC address.
        // 
        public Guid CountryID { get; set; }

        // If you want to accept 
        // null values, suffix with question mark for the string, that means your property is ready to
        // accept null values.
        public string? CountryName { get; set; }
    }
    /// -------------------------------- End of 166. xUnit Test-----------------------------------
}
