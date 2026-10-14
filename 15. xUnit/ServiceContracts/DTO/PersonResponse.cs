using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    /// -------------------------------- Start of 175. Add Person - Model - 2 -----------------------------------
    /// <summary>
    /// Represents DTO class that is used as return type of most methods of Persons Service.
    /// </summary>
    public class PersonResponse
    {
        /// 
        /// In this PersonResponse class, you would like to declare the properties of person which you would like to return to the
        /// controller or unit test case.
        /// For example, if you try to retrieve the person data,
        /// it includes with all the person details such as person ID, person name, email, etc.
        /// So you have to declare all of those as properties in this class.
        /// If you do not want to print this email and date of birth to the user, do not include those properties.
        /// In addition to that, you may have some additional properties which you want to calculate and
        /// display the same in the page. For example, let's say there is a page that displays the list of
        /// persons, and there you would like to automatically calculate and display the age of the person based
        /// on this existing date of birth. So you may have some additional property called age and you will
        /// write the calculation code of age in the service itself. So that the controller can receive the
        /// date of birth and age both and display whatever it wants, maybe both. 
        /// 
        ///  What do you want to store exactly is person class. But what do you want to display to the user
        ///  is called as person response class. That means the DTO class.
        /// 
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Country { get; set; } // We will get Country Name using the Country ID
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; } // We will get the Age using DOB in the Service.

        // Lets override the Equals method.
        /// <summary>
        /// Compares the current object data with the parameter object 
        /// </summary>
        /// <param name="obj">The PersonResponse object to compare </param>
        /// <returns>True or False indicating whether all person details are matched with the specified parameter object</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(PersonResponse))
                return false;

            PersonResponse person = (PersonResponse)obj;

            // this keyword below is optional.
            return 
                this.ID == person.ID && 
                this.Name == person.Name &&
                this.Email == person.Email &&
                this.DateOfBirth == person.DateOfBirth &&
                this.Gender == person.Gender &&
                this.CountryID == person.CountryID &&
                this.Address == person.Address &&
                this.ReceiveNewsLetters == person.ReceiveNewsLetters;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return @$"Person ID : {ID}, Person Name : {Name}, Person Email {Email}
                    Date Of Birth : {DateOfBirth?.ToString("dd MMM yyyy")}, 
                    Gender : {Gender}, Country ID : {CountryID}, Country Name : {Country},
                    Address : {Address}, Receive News Letters : {ReceiveNewsLetters}";
        }

        /// -------------------------------- Start of 188. Update Person - Creating DTO --------------------------------
        /// 
        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest()
            {
                ID = this.ID,
                Name = this.Name,
                Email = this.Email,
                DateOfBirth = this.DateOfBirth,
                Address = this.Address,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), this.Gender, true),
                CountryID = this.CountryID,
                ReceiveNewsLetters = this.ReceiveNewsLetters,
            };
        }
        /// -------------------------------- End of 188. Update Person - Creating DTO --------------------------------
    }

    public static class PersonExtensions
    {
        /// In order to easily convert an 
        /// object from the person class into the person response class, we have to create an extension
        /// method that converts the object from the person type into the PersonResponse type. Because for
        /// example, we are retrieving the list of persons and by default the data store stores the list
        /// of persons as objects of the person class. So there, for returning the list of persons,
        /// we have to convert each object from the person type into person response type.
        /// 
        /// <summary>
        /// An extension method to convert an object of Person class into PersonResponse 
        /// class.
        /// </summary>
        /// <param name="person">The person object to convert</param>
        /// <returns>Returns converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            // Instead of "this" we can use parameter called "person"
            // We are calculating the Age here, but it can also be done in service class.
            return new PersonResponse()
            {
                ID = person.ID,
                Name = person.Name,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Address = person.Address,
                CountryID = person.CountryID,
                Gender = person.Gender,
                Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null
            };
        }
    }

    /// -------------------------------- End of 175. Add Person - Model - 2 -----------------------------------
    ///
}
