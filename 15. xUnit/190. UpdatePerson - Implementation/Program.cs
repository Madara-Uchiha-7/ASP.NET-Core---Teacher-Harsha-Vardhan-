/*
We will add the implementation for UpdatePerson in PersonService_Copy.cs
Check the code and comments.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
