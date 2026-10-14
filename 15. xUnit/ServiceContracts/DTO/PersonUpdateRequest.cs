using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// -------------------------------- Start of 188. Update Person - Creating DTO --------------------------------
namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents the DTO class that contains the Person details to update.
    /// </summary>
    // Lets make it public
    public class PersonUpdateRequest
    {
        // Lets add the properties which we want to update for Person type.

        [Required(ErrorMessage = "Person ID can not be blank")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Person name can not be blank")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Person email can not be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a valid email")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the current object of PersonAddRequest_Copy into a new object of Person Type.
        /// </summary>
        /// <returns>Person Object</returns>
        public Person ToPerson()
        {
            return new Person()
            {
                ID = Guid.NewGuid(),
                Name = Name,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                Address = Address,
                CountryID = CountryID,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
/// -------------------------------- End of 188. Update Person - Creating DTO --------------------------------