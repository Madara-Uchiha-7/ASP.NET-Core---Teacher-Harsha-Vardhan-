using System.ComponentModel.DataAnnotations;

namespace _70._All_Model_Validations___Part_1.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can not be empty or null.")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be in between {2} to {1} characters.")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
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