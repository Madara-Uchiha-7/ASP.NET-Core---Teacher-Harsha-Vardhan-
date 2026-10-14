/*
Lets implement the test case for GetAllPersons method. This method is present in Person.cs
Check the code and comments in in PersonServiceTest_Copy.cs

Run tests.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
