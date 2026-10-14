using System.ComponentModel.DataAnnotations;

namespace _69._Model_State.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Person name can not be empty or null.")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
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