/*
We will write a test cases for GetSortedPerson.
We will implement this method in next lecture. 
Check the code in PersonService_Copy.cs
PersonServiceTest_Copy.cs
and 
IPersonService_Copy.cs

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
