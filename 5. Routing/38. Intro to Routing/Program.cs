/*
In ASP.NET Core routing is a process of matching the incoming HTTP requests by checking HTTP method and
the URL, and if they match, invoking corresponding endpoints.

Here endpoint is the terminology, but it is actually a middleware.

So invoking the corresponding endpoint based on the HTTP method and URL is called as routing.

In older versions of ASP.Net core, we used to accomplish this with two individual methods.
That is use routing and use endpoints.

But starting from dotnet six onwards, routing is automatically enabled.
And we don't need to explicitly call the user routing method anymore.

The framework automatically handles the routing configuration for us behind the scenes.

In older version they used to write: app.UseRouting()
So when we write the builder dot build method, routing is already configured for us.

Now how do we define the endpoints?
We define the endpoints directly on the app object using app.Map methods.

You can add your endpoints with map store methods:
app.Map(), app.MapGet() or app.MapPost()

So all the methods that begin with map are called as map methods.

*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
