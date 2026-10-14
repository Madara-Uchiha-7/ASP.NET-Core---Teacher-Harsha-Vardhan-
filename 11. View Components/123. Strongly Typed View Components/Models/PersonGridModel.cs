namespace _123._Strongly_Typed_View_Components.Models
{
    public class PersonGridModel
    {
        public string GridTitle { get; set; } = string.Empty;

        public List<Person> people { get; set; } = new List<Person>();
    }
}
