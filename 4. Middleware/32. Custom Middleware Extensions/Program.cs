/*
Lets simplify the last lection 2nd middlware.

Syntax:
static class ClassName 
{
    public static IApplicationBuilder UseExtensionMethodName(this IApplicationBuilder app) 
    {
        return app.UseMiddleware<MiddlewareClassName>();
    }
}


In the same file where you create the custom middleware create another class
CustomMiddlewareExtension.
It should be a static class with static method.

Data type of our app variable is of WebApplication type.
This WebApplication is a clild of IApplicationBuilder
So if we can inject our extension into IApplicationBuilder then
eventually that gets added to WebApplication and which also means,
it gets added into our app variable.
This is why extension method is helpful.

As you can see, we can call the 2nd middleware like:
app.UseMyCustomMiddleware();

Earlier it was: 
app.UseMiddleware<MyCustomMiddleware>();

The above line will go into our extension method. 
*/
using _32._Custom_Middleware_Extensions.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await next(context);

});

app.UseMyCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h2>Hello Again</h2>");
});


app.Run();
