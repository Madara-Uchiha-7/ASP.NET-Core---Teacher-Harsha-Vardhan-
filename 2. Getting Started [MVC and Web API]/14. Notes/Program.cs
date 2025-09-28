/*

var builder = WebApplication.CreateBuilder(args);

Purpose: Initializes a new instance of the WebApplicationBuilder class.

Details:

WebApplication.CreateBuilder(args):

CreateBuilder is a static method that initializes a WebApplicationBuilder instance.

args represents command-line arguments passed to the application.

The builder sets up the default configuration, logging, and dependency injection (DI) services.

Configuration:

Reads configuration settings from various sources (e.g., appsettings.json, environment variables).

Logging:

Configures default logging services.

Dependency Injection:

Registers services to be used by the application via DI.



var app = builder.Build();

Purpose: Builds the WebApplication instance.

Details:

builder.Build():

Finalizes the app's configuration and prepares it for running.

Compiles all middleware components added during the build process.

Creates the WebApplication object that will handle HTTP requests.



app.MapGet("/", () => "Hello World!");

Purpose: Sets up a route that maps HTTP GET requests to a specific path (in this case, the root URL).

Details:

app.MapGet:

A convenience method to define a route that matches GET requests.

"/" specifies the root URL path.

() => "Hello World!" is a lambda expression that defines the response to be returned when the route is accessed.

The lambda returns a plain string "Hello World!" which is sent as the HTTP response body.



app.Run();

Purpose: Runs the application.

Details:

app.Run():

Starts the Kestrel web server (or the configured server) and begins listening for incoming HTTP requests.

This is a blocking call that keeps the application running until it is manually stopped (e.g., via Ctrl+C in the console).

The application is now live and will respond to requests based on the configured routes and middleware.


-----------------------------------------------------------------------------------------------------------------------------

WebApplication.CreateBuilder(args) sets up the application with default settings.

builder.Build() finalizes the configuration and prepares the application.

app.MapGet("/", () => "Hello World!") maps a GET request to the root URL and returns "Hello World!" as a response.

app.Run() starts the web server and runs the application, ready to handle incoming requests.


-----------------------------------------------------------------------------------------------------------------------------
Kestrel Server
Overview:

Kestrel is the cross-platform web server for ASP.NET Core.

It is lightweight and suitable for serving dynamic content.

Responsibilities:

HTTP Requests Handling: Handles incoming HTTP requests and responses.

Hosting: Hosts the ASP.NET Core application.

Configuration: Supports various configurations such as HTTP/2, HTTPS, etc.

Use Case:

Ideal for development and internal networks.

Typically used in conjunction with a reverse proxy for production environments.



Reverse Proxy Servers
Overview:

A reverse proxy server forwards client requests to backend servers and returns the responses to the clients.

Common reverse proxy servers include Nginx, Apache, and IIS.

Responsibilities:

Load Balancing: Distributes incoming requests across multiple servers.

SSL Termination: Handles SSL/TLS encryption and decryption.

Caching: Caches responses to improve performance.

Security: Provides additional security features like request filtering, IP whitelisting, and rate limiting.

Use Case:

Used in front of Kestrel to enhance security, load balancing, and other enterprise-level requirements.





Responsibilities of Kestrel and Reverse Proxy Servers
Kestrel:

Serves HTTP requests directly.

Provides efficient request processing.

Should be used behind a reverse proxy for additional security and stability.

Reverse Proxy:

Acts as an intermediary between clients and Kestrel.

Provides SSL termination, load balancing, and security features.

Enhances the overall performance and security of the application.


-----------------------------------------------------------------------------------------------------------------------------

Explanation of ASP.NET Core Logs
1. Application Start Log: Listening on Port
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5117
Category: Microsoft.Hosting.Lifetime

Event ID: 14

Message: Now listening on: http://localhost:5117

Explanation:

Indicates that the Kestrel server is now running and ready to accept HTTP requests on the specified URL and port (http://localhost:5117).

This log is crucial for knowing where your application is accessible.



2. Application Started Log
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
Category: Microsoft.Hosting.Lifetime

Event ID: 0

Message: Application started. Press Ctrl+C to shut down.

Explanation:

Confirms that the ASP.NET Core application has successfully started.

Provides instructions for gracefully shutting down the application by pressing Ctrl+C in the terminal or command prompt where the application is running.



3. Hosting Environment Log
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
Category: Microsoft.Hosting.Lifetime

Event ID: 0

Message: Hosting environment: Development

Explanation:

Specifies the current hosting environment of the application (in this case, Development).

The hosting environment can be Development, Staging, or Production, which affects how the application behaves, particularly in terms of logging, error handling, and configuration settings.



4. Content Root Path Log
info: Microsoft.Hosting.Lifetime[0]
      Content root path: c:\code\temp\MyFirstApp\MyFirstApp
Category: Microsoft.Hosting.Lifetime

Event ID: 0

Message: Content root path: c:\code\temp\MyFirstApp\MyFirstApp

Explanation:

Indicates the content root path of the application, which is the base path where the application’s content files are located.

This path is used to locate static files, views, and other content.

It helps in understanding where the application’s files are located in the file system.

Summary
Now listening on: Informs you where the application is accessible.

Application started: Confirms the successful start of the application and how to shut it down.

Hosting environment: Indicates the environment (Development, Staging, Production) the application is running in.

Content root path: Shows the base path for the application's content files.

------------------------------------------------------------------------------------------------------------------------------------
Detailed Notes for launchSettings.json
launchSettings.json is a configuration file in ASP.NET Core projects used to define settings for how the application is launched during development. This includes settings for different environments, URLs, and other debugging options.



Structure of launchSettings.json
$schema

Specifies the schema URL for launchSettings.json, which helps with validation and IntelliSense support in IDEs like Visual Studio.

"$schema": "http://json.schemastore.org/launchsettings.json"

sslPort: The port number for HTTPS. If 0, HTTPS is disabled.


http profile:

commandName: Specifies how the application should be launched. Project means it will use dotnet run.
 
*/





var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
