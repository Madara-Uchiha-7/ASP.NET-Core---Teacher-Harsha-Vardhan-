namespace _55._JsonResult.Models
{
    // Here we are going to create the properties such as ID.
    // You can make use of int or long data type for ID, but GUID or guide is better
    // because the int and long data type can hold only limited number of numbers because there is minimum
    // and maximum value for int and long.
    // But this GUID or guide value can be unlimited because it is hexadecimal number and it can be
    // generated dynamically based on the current timestamp. So it is universally unique, almost
    // impossible to duplicate.
    // We added ? after string keyword because we are saying that we are going to accept the null values in
    // our string variable.
    // Lets go back to controller class.
    public class Person
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int Age { get; set; }
    }
}
