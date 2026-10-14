/*
ASP.NET Views can show additional content in
the specific environment.

E.g. in Development environment you can show a button for database migrations or opening the log.

Like this, you can show additional content or
hide the existing content in the particular environment.
Then you can use a predefined tag helper
called environment like :

<environment include = "Environment1, Environment2, ...">
    Html content here
</environment>

We have used include here, we can also use exclude here.

Our current environment is Development.
To show the button,
At first, you have to import the tag helpers.
For that purpose, in the views folder, create 
a file called view imports.

Right click on views folder, add "Razor Components",
select razor view imports.
File name is fixed i.e. _ViewImports.cshtml

In that file,
We added @addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
@ addTagHelperto directive is to import all the predefined tag helpers.
To import any predefined tag helpers, we have
to import the all tag helpers from this namespace.

Tag helpers are like the custom tags or custom attributes for existing HTML tags.
They provide some server side functionality.

Now switch to the view that is index.cshtml

Check the code in it.


This is rare thing to use, mostly seperate html page is created for development environment.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
