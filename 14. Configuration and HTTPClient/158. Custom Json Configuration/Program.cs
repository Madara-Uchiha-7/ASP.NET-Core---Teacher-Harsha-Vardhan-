/*
Okay, in this context, assume that you would like to store the non-sensitive data as configuration
within the configuration files as a part of the source code.
For example, you would like to store some non-sensitive data in the appsettings.json file.

But if the number of settings increased, there can be too many configuration settings
written in the same file. In that way, it will be difficult to differentiate between
the configuration settings. As alternative, you can group the
common or related configuration settings as a separate JSON file.
Means, you will be creating another JSON file other than this app settings file.
Then you will store the related configuration settings in that JSON file.

So, you have a custom JSON file with key-value pairs as configuration,
and you can read those settings into your options class.

Create a new item in this project, 
Name can be any:
I gave : MyOwnConfig.json

Lets load our JSON here.
*/

using _158._Custom_Json_Configuration.WeatherApis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

// Load MyOwnConfig.json
// We are going to configure our application configuration source
// You have to create a lambda expression with two arguments, that is, hostngContext
// and config. Because this lambda expression will be called automatically at application startup
// at runtime. And here, you can call the config parameter.addJsonfile.

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    // So, this config parameter represents iConfigurationBuilder,
    // using which you can add custom configuration sources, such as your custom JSON file.
    // In case if it is present in a separate folder,
    // you have to mention the complete absolute path.
    config.AddJsonFile("MyOwnConfig.json", optional : true, reloadOnChange : true);

    // By mentioning optional parameter, you are trying to say
    // that this file is optional.So, even though 
    // at runtime, maybe for some reason, this file does not exist, it will not be an exception.
    // And also, optionally, you can add a parameter called reloadOnChange equal to true.
    // If you mention true here, and when you modify some value within this myownconfig file at runtime,
    // automatically application will restart. Of course, if you mention false there,
    // it will be opposite. 
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();


/*
You can see the clientId and
clientSecret values are loaded from myownconfig.json because we have 
added the configuration source
as myownconfig after all the default configuration sources.
So, our custom config file takes the highest priority because it is recently loaded after
loading all the default configuration settings.
*/