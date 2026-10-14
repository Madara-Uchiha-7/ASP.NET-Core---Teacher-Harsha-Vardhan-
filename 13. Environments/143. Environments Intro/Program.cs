/*

An environment represents a system in which the application is currently running.
For example, today you have created an ASP .NET Core application and that mission which is
used for development is called as development environment.

So while developing the application, the environment should
be set as development so that you can get code-related error messages, such as details
of exception.

But tomorrow you have uploaded the same application
into a server where the other developers and 
quality controllers can access the application through that server.
Then that environment should be set as staging
environment.

And later, the same application has been uploaded
into the production server, means the real server
from which the users, means the end users
can access your application.

Then the exception details should be hidden.
The users should not be able to see
the exception or any other code-related errors.
In case if the end users encountered someruntime errors, they can report you by other
ways, for example via email.

So these are the three built-in environments
supported by ASP.NET Core.

Alternatively, based on the need, you can configure
your own environment with other names.

For example, you can configure your own environments
such as unit testing environment, integration testing environment,
beta environment, or any other custom-owned names.

It is necessary that every ASP.NET Core
developer should know how do you configure the
environment name in ASP.NET Core.

You should be able to change the environment
based on the current working machine, for example
enabling development environment on the developer machine, staging
environment on the staging server, production environment on
production server.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
