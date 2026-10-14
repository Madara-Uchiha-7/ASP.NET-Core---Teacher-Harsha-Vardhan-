/*
ASP.NET Core has a system called configuration settings to store the constant key-value pairs 
that can be read from anywhere from any file within the same application.


For example, in the real-world projects, you may want it to store the common artifacts that are accessible from different places,
means that are needed by different components such as controllers, views, or from middleware.

Otherwise, you would like to read from reusable services.
Like for example, you would like to store the connection strings,
the client ID or API keys that you register for REST API calls,
otherwise domain addresses, otherwise constant email addresses of the customer care.

So, you will set this type of values one time in the entire application and will be reusable across the application.

For example, we have registered the client ID in the Google API or in the OpenWeatherMap.com or from any third-party API server.
That means, with the provided client ID and client secret values, you can make REST API calls to that server.
So, you have to store the client ID and API keys in a specific location in the entire application,
and you can reuse the same across from different services in the same project.

For example, by default, there is a file called appsettings.json file in the project.
This gets created every time when you created a new project.
There you can store the key value pairs in the form of JSON,
which can be read from anywhere in the entire application,
like for example from the controller, services, or from program.cs as well.

It will have a Default code:

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Logging: These configuration settings are for logging middleware,
which we are not going to use in this lecture, even in this section.
In case, if you are using ASP.NET Core built-in logger middleware,
then these configuration settings are useful.
Here you can add any key with any value.


Lets add some key value in that file.
Lets read it from current file.


*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Using UseEndpoints, enable the endpoints in endpoints => {} lambda expression.
// We are going to create an endpoint by using the map method. And whenever I receive the request for this default URL,
// then I would like to execute async context => {} lambda expression.
// In this we will read the condiguration using "Configuration"
// There is a predefined property in this app(IApplicationBuilder) , i.e. that is Configuration.
// It is of IConfiguration type. It is exactly how do you read the configuration values
// from the configuration sources, such as appsettings.json. appsettings.json is not one and only sources.
// you may store the configuration settings either in the appsettings.json
// or environment variables or in the file configuration, means a custom file,
// maybe a JSON file or INA file or XML file. Even, if needed, you can store your configuration settings in a dictionary
// that is called in-memory configuration or secret manager to make it secure.
// For any of above mentioned configurations, Configuration property called app.Configuration can read the values.
// The key is not case  sensitive.
// Run the app.
// There is another way to read the value :
// There is a method called GetValue()
// GetValue<T>(string key, object defaultValue);
// In the place of T, you mention the data type of the value.
// 
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKey"]);

        // Another way without default value and GetValue method
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));

        // Another way with default value and GetValue method
        // Below line I got error because WriteAsync only accepts a string
        // await context.Response.WriteAsync(app.Configuration.GetValue<int>("ThisKeyDoesNotExist", 10));
        // Fixed using Chatgpts help:
        
        await context.Response.WriteAsync(app.Configuration.GetValue<int>("ThisKeyDoesNotExist", 10).ToString());
    });
});
app.MapControllers();

app.Run();
