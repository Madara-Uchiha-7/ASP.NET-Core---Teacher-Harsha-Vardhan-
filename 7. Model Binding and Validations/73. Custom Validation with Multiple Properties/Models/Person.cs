using _73._Custom_Validation_with_Multiple_Properties.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace _73._Custom_Validation_with_Multiple_Properties.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can not be empty or null.")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be in between {2} to {1} characters.")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabates, space and .")]
.
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address.")]
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

        public DateTime? FromDate {  get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public override string ToString()
        {
            return $"Person : {Name}"
            + $"{Environment.NewLine}Email : {Email}"
            + $"{Environment.NewLine}Phone : {Phone}"
            + $"{Environment.NewLine}Price : {Price}";
        }
    }
}