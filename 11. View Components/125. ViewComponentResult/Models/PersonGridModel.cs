namespace _125._ViewComponentResult.Models
{
    public class PersonGridModel
    {
        public string GridTitle { get; set; } = string.Empty;

        public List<Person> people { get; set; } = new List<Person>();
    }
}
