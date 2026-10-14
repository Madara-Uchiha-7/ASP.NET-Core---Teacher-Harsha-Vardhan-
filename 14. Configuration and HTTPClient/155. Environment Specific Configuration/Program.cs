/*
If you extend appsettings.json file, 
you will find another file in it : appsettings.Development.json

When you create a new project, by default this file gets created automatically.
So what's the purpose of that?
Which takes more precedence?
Which can override the values of which other?

This concept is called as environment-specific configuration.
In the last lecture, we have seen three
types of environments and how do you configure
them?

That is development, staging, and production.
So you can create different configuration files for
each environment.
For example,
appsettings.Development.json
appsettings.Staging.json
appsettings.Production.json

While reading the configuration from the sources, it
first reads the value from the appsettings.json.
For example, here there is a key value
pair like x equal to 1.
Then it reads the environment-specific, means either
of above files.

It depends on the current environment of your
LaunchSettings.json

For example, in this appsettings.Development.json, if
you have the same key, for example, x
equal to 2, it overwrites the previous value.

Then after that, it reads the value from
user secrets (Secrete Manager),
It takes more precedence.
That means, for example, in the user secrets,
you have mentioned x equal to 3.
Finally, x equal to 3 wins the race.

Like that, then environment variables and command-line
arguments takes precedence.
Whichever is loaded last, that value only be
accessible in the actual code.
But we will discuss about these user secrets,
environment variables, and command-line arguments later.

appsettings.json -> appsettings.Development.json -> User Sercrets (Secret Manager) -> Environment Variables -> Command Line Arguments 

Goto appsettings.Development.json
Add the same parent and child which we have added in appsettings.json into this file with different values but same keys.

If Your Environment appsettings.<EnvName>.json file does not exist then it will read only from the default file that is
appsettings.json.

We have added the the different values in the appsettings.Development.json
and the values are getting overridden, that is, this is working.

This helps when we have a different database connection names and passwords for each environment or 
for email addresses...etc.
*/
using _155._Environment_Specific_Configuration.WeatherApis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
