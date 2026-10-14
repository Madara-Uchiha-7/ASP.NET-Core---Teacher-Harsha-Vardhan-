/*
Sometimes, you would like to read the configuration
settings programmatically in the controller or in any
other services.

Then, you can inject IConfiguration interface as a
service in your controller class.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

public class ControllerName : Controller
{

    private readonly IConfiguration _configuration;
    
    public ControllerName(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}


Create a wwwroot folder.
Paste teachers .css file there.

Create a folder "Controllers"
Right click on it
add new controller
MVC Controller empty.
Name : HomeController.cs

Add a Route attribute for default path.
Right click on Index action method.
Select Razor view empty. 
Name: Index.cshtml
We added a code in this .cshtml
Check the code

Check the code in Controller also.

The configuration can be of hierarchical.
That means, for example, you can have a
master key under which you have another nested JSON object.
So, if you have a nested JSON object, how do you read your child key.

That's what we are going to try in
the next lecture.
*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();


// Q/A:
/*
Respected sir,

how can access the session variable in view or .cshtml file?

hi,

In ASP .NET Core, you can access session data both in controllers and views.



1. Configure the session in Program.cs:

In the ConfigureServices method of Program.cs, you need to add the session service and configure it. Here's an example of how to set up the session with default settings:

builder.Services.AddSession(options =>
    {
        // Set the desired session configuration options here if needed.
        options.Cookie.IsEssential = true; // If you want to make the session cookie essential.
        // You can also set other session-related options here.
    });
 
 
var app = builder.Build();
 
//Other middleware here..
app.UseSession(); // Add this middleware to enable session support


2. Access session data in a controller:

In your controller, you can use the HttpContext.Session property to access the session data.

e.g:

using Microsoft.AspNetCore.Mvc;
 
public class MyController : Controller
{
    public IActionResult SetSessionData()
    {
        HttpContext.Session.SetString("UserName", "JohnDoe");
        return RedirectToAction("Index");
    }
 
    public IActionResult GetSessionData()
    {
        var userName = HttpContext.Session.GetString("UserName");
        ViewBag.UserName = userName;
        return View();
    }
}


3. Access session data in a view:

To access the session data in a view, you can use the @HttpContext.Session object.

e.g:

<!-- Views/MyView.cshtml -->
<h1>Welcome, @HttpContext.Session.GetString("UserName")!</h1>
*/