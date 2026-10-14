/*
In the home Controller right click on the Index action method and add view -> Razor View Empty -> again Razor View Empty.
Name of the view shold be same as the action method.
This will add a view in our Views folder. This will create the folder called Home and it will add a View called Index.cshtml
in that Home folder.

Every view has a property called "Layout". Its default value is null i.e. Layout = null. This null means the view has no layout view.
So we have added a "Layout" property in our Index view, to connect it to our Layout view.
We have added a path in it of layout view. 
~ represents the domain address, that islocalhost and then port number.
Then after that, you have to give the path of the layout view.
This also means that, after the completion of this view, go and execute the layout view.

Now, what ever we will add in our index view, will be added at the @RenderBody()

In view, we can add a breakpoint only in the area in which we have added our c# code.
i.e. inside the @{...}


When you run the application,
Code will search for the Route in controller.
Once it find the Route, it tries to find the view realted to that Route,
then it executes that view and then goes to Layout view and runs the code in it.

Run the application,
goto network tab,
find localhost,
click on it,
Goto its response, you will see whole html page.


If you do not add "@RenderBody()" in the Layout view, then you will get the error.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
