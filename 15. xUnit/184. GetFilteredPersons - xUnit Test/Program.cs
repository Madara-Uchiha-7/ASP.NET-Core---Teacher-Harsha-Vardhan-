/*
Lets write a test cases for a method which will perform the search operations on the Person.

Lets create a method in the IPersonService_Copy.
Check the code in it.

Then we add the code in PersonService_Copy.cs and PersonServiceTest_Copy.cs.
Check the code and comments.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
