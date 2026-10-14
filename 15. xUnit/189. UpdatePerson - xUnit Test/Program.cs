/*
Lets write the test cases for "UpdatePerson"
Check the code and comments in IPersonService_Copy.cs and PersonService_Copy.cs and
and then PersonServiceTest_Copy.cs


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
