using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Person
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(40)]
        public string? Name { get; set; }

        [StringLength(40)]
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        public Guid? CountryID { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public bool ReceiveNewsLetters { get; set; }

        public string? TIN { get; set; }

        [ForeignKey(nameof(CountryID))]
        public virtual Country? Country { get; set; }
        // We made this Country foreign key virtual, its not compulsory but a convension.
    }
}
