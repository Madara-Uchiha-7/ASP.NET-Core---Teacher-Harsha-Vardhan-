using System.ComponentModel.DataAnnotations;

namespace _71._All_Model_Validations___Part_2.Models
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
        // We added *, so that we can accept more than 1 character.
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

        public override string ToString()
        {
            return $"Person : {Name}"
            + $"{Environment.NewLine}Email : {Email}"
            + $"{Environment.NewLine}Phone : {Phone}"
            + $"{Environment.NewLine}Price : {Price}";
        }
    }
}