/*
Goto PersonService_copy and check the code and comments that we have added.

Run the tests.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
