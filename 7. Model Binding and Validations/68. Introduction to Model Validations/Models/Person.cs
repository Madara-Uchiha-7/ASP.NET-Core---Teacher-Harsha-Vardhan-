using System.ComponentModel.DataAnnotations;

namespace _68._Introduction_to_Model_Validations.Models
{
    public class Person
    {
        [Required]
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

// All the atributes are classes.

// [Required]
// So this Required is a class called required attribute.
// ASP.NET has added the System.ComponentModel.DataAnnotations namespace for this attribute.
// The property is mandatory now It cannot be null or empty. At least it should contain a value.
// At least one character.
