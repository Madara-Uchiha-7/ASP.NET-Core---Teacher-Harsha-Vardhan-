namespace _67._form_urlencoded_and_form_data.Models
{
    public class Book
    {
        public int? BookId { get; set; }
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"Book id is {BookId} and auther is {Author}.";
        }
    }
}
