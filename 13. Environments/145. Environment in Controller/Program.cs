/*
Sometimes, in real-world cases, you have to
access the current working environment name programmatically, either
in the controller or in any other services.

So how can you do that?

using Microsoft.AspNetCore.MVC;

public class ControllerName : Controller 
{
    // Create a private readonly object
    private readonly IWebHostEnvironment _webHost;
    
    // Create the Constructor
    public ContollerName (IWebHostEnvironment webhost)
    {
        _webhost = webhost;
    }
}

To access the current working environment, you can
inject a predefined service called iWebHostEnvironment.
So that, using that service instance, you can
access the current working environment.
Just like app.environment in program.cs. For

Now, in action method you can do:

_webhost.isDevelopment();

All the properties and methods can be accessed in controller which we learned in the last 
lecture.

Lets add a code in our HomeController and show the Environment name in the HTML using 
ViewBag.

Make the environment Beta instead of Development in LaunchSettings.json

Run the code.

In general, you
can write some code in the controller.
For example, if the current working environment name
is development, then only inject additional services or
execute some additional logic such as calling some
service methods for fetching the data from database.

Otherwise, for example, you have to add additional
log messages only in the particular environment.
So for that case, you have to know
the current working environment name in the controller.
So in that situation, you can use this
technique by injecting this IWebHostEnvironment.

In the launch settings.json file, we have
set the environment demo of the Kestrel server profile.

Optionally, in case if you are using IIS
Express to run the application, by selecting it
in this drop down from top run option, then you
can set the ASP.NET core environment in IIS Express.


*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
