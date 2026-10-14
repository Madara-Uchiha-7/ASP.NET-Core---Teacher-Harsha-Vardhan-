/*
Lets create a DTO class called PersonUpdateRequest.cs

Check the code and comments in it.

Check the PersonResponse.cs code and comments
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
