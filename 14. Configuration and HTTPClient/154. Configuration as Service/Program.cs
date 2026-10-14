/*
Rather than creating a new object of last lecture
WeatherAPIOptions class, if we can inject
the same as a service in the constructor,
that will be more better, right?

Because you need not write an extra statement
in this action method.

Difference this time is:
You are going to inject the configuration as a service in your program.cs,
you have to write Configure method in the Services.
So then you can use dependency injection to
get the configuration options object.
Before you call the Build method, you can try this:

builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));


builder.Configuration.GetSection("WeatherApi"): 
This gets the section called weather API from out appsettings.json

Okay, so after adding the configuration as a
service, you can inject the same in any
controller or in any other service, just like
a normal dependency injection.

Now, in controller class, instead of IConfiguration, we use 
IOptions interface. We use "using Microsoft.Extensions.Options;" namesapce for this.

Then .Value which we have used on the Constructor parameter will give the object of the WeatherApiOptions class.
*/
using _154._Configuration_as_Service.WeatherApis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Supply an Object of WeatherApiOptions (with 'WeatherApi' Section) as a service.
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
