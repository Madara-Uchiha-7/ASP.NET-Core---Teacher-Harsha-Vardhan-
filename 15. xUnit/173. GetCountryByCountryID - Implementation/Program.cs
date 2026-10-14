/*
Check the CountryService's GetCountryByCountryID() method implementation.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
