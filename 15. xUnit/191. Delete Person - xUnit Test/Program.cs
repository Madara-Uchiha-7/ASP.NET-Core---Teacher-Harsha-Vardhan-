/*
We will write the test case for delete person.
Check the IPersonService_Copy.cs
then PersonService_Copy.cs
then PersonService_Test.cs


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
