/*
Lets add the code in PersonsController to return the filtered result.

If our search string is empty then "GetFilteredPerson()" will return 
all persons.

Also after filter search data is returned to the view,
we are retaining the values which user entered on the html page.
For this we have used ViewBag and value and selected attributes.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
