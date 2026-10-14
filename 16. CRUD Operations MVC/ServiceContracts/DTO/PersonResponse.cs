using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as return type of most methods of Persons Service.
    /// </summary>
    public class PersonResponse
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; } 

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
    }

    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of Person class into PersonResponse 
        /// class.
        /// </summary>
        /// <param name="person">The person object to convert</param>
        /// <returns>Returns converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
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
}
