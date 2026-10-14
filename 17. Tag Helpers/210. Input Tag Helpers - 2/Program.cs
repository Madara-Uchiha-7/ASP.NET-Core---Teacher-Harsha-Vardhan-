/*
In older sections, we were using foreach loop to show the country names on the create form.

We are going to tag healpers for this also.

For that in controller we have used : SelectListItem() {} 
in the persons controller which is present in the "using Microsoft.AspNetCore.Mvc.Rendering;"

SelectListItem() {} : in his contructor we can pass the following values:
Disabled, Groip, Selected, Text, Value.
Text is what user sees on the screen and
Value will be added in the value property. The Text and Value are used for <option> element.

Using the LINQ's .Select() we are creating one object of SelectListItem() {}
for each country.

Since value attribute takes string in the html, we have used .ToString for Value argument in the controller.

So overall this select method returns an enumerable collection of SelectListItem type.
We have added in ViewBag.
Which we have used in the Create View.

Check how we have only wrote the one option tag whcih is for default "Please Select" text.
Other option tags will be created automatically.

Then we have added the asp-for for all the label tags as will in the Create view.
The advantage of asp-for is it will show the error if you wrote the wrong proeprty name.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
