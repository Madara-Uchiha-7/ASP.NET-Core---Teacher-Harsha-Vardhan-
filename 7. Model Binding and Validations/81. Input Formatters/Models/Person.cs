using _81._Input_Formatters.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace _81._Input_Formatters.Models
{
    public class Person : IValidatableObject
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

        public int? Age { get; set; }
        public override string ToString()
        {
            return $"Person : {Name}"
            + $"{Environment.NewLine}Email : {Email}"
            + $"{Environment.NewLine}Phone : {Phone}"
            + $"{Environment.NewLine}Price : {Price}";
        }

        public List<string?> Tags { get; set; } = new List<string?>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Date Of Birth and Age, both can not be null.", 
                    new[]
                    {
                        nameof(Age),
                        nameof(DateOfBirth),
                    });
            }
            if (DateOfBirth.HasValue == false)
            {
                yield return new ValidationResult("Come on!! Don't be shy!! Give the birth date also.",
                    new[]
                    {
                        nameof(Age),
                        nameof(DateOfBirth),
                    });
            }
        }
    }
}