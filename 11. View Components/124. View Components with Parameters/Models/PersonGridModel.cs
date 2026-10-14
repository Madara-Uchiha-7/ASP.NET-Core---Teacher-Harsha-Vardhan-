namespace _124._View_Components_with_Parameters.Models
{
    public class PersonGridModel
    {
        public string GridTitle { get; set; } = string.Empty;

        public List<Person> people { get; set; } = new List<Person>();
    }
}
