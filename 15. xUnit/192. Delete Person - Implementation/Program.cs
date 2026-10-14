/*
Lets implement the DeletePerson.
Check the code and comments in the PersonService_Copy.cs

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
