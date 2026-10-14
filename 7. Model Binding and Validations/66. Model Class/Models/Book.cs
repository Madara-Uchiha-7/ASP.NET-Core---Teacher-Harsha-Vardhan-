namespace _66._Model_Class.Models
{
    public class Book
    {
        public int? BookId { get; set; }
        public string? Auther { get; set; }

        // We can override the ToString() which is helpful whil printing the data as a part
        // of the request.

        public override string ToString()
        {
            return $"Book id is {BookId} and auther is {Auther}.";
        }
    }
}
