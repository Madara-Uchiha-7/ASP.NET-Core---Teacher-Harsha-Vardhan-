using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Country
    {
        [Key]
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        // public virtual ICollection<Person>? persons { get; set; }
        // Above line has beed added in "231. Table Relations with EF"
        // as a demonstration, we do not need it so commented it.
    }
}
