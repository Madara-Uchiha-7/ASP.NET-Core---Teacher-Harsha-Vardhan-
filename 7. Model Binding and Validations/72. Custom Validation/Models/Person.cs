using _72._Custom_Validation.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace _72._Custom_Validation.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can not be empty or null.")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be in between {2} to {1} characters.")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabates, space and .")]
        // RegularExpression starts and ends with ^ and $
        // Since we want to access A to Z and a to z and space and . we have given it in RegularExpression()
        // If any other character comes in the request then the error message is generated.
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address.")]
        // EmailAddress by default contains the reqular expression.
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "{0} should be a valid number.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can not be empty.")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [Compare("Password", ErrorMessage = "{1} and {0} should be same.")] // {1} will be the Password string.
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be in between ${1} and ${2}")]
        public double? Price { get; set; }

        [MinimumYearValidation(2005, ErrorMessage = "Date of birth should not be less than Jan 1,{0}")]
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Person : {Name}"
            + $"{Environment.NewLine}Email : {Email}"
            + $"{Environment.NewLine}Phone : {Phone}"
            + $"{Environment.NewLine}Price : {Price}";
        }
        // [MinimumYearValidation] : We can do
        // [MinimumYearValidation(ErrorMessage="")]
        // This works because, notice this property called error message
        // is already predefined in the parent class called validation attribute.
        // If we are passing ErrorMessage here in attribute then in our Attribute class,
        // we have to change the line from:
        // return new ValidationResult("Birth Year can not be less than 2000");
        // To:
        // return new ValidationResult(ErrorMessage);
    }
}