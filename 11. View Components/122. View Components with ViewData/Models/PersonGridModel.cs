namespace _122._View_Components_with_ViewData.Models
{
    public class PersonGridModel
    {
        public string GridTitle { get; set; } = string.Empty;

        public List<Person> people { get; set; } = new List<Person>();
    }
}
