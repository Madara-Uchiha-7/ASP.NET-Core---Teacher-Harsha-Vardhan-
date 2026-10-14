/*
Goto the ICountiresService
add one method called GetCountryByCountryID();
Now in ContryService class add this method because this class implements that interface.

Lets write the unit test first before implementing the GetCountryByCountryID().

Goto CountryServiceTest and check the code and comments added.

In next lecture we will add the implementation.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
