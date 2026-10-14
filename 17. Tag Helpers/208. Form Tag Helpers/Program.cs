/*
For the form tag and anchor tag in HTML, you can use two predefined tag helpers,
that is asp-controller and asp-action. In this asp-controller, you can specify the controller
name and in asp-action action name, so that it will generate the URL automatically and will be
kept in the action attribute. It first takes the controller name and then
slash action name.

Based on this pattern, it generates the URL automatically based on the mentioned
controller name and action name. Exactly in the same way, for the anchor tag,
if you mention the controller name and action name here in this ASP-controller and ASP-action,
that URL will be generated in the HREF attribute.

So even though you move the view from one controller to another controller,
it generates the appropriate URL.
And also, you may supply the controller name and action name programmatically by using some
variables. For example, if you supply the values from the controllers through view bag,
those values can be supplied at attributes in html. That is the benefit of using the tag helpers.


We will use this in the Index view of the persons controller. Same for Create View.
To use this tag helpers we have to import the package : 
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
