/*
There is another possibility that you can create a custom middleware without
inheriting from this IMiddleware interface.

You can convert your plain simple class as a middleware.

class MiddlewareClassName
{
    private readonly RequestDelegate _next;

    public MiddlewareClassName(RequestDelegate next)
    {
        next = _next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Logic before
        await _next(context)
        // Logic after
    }
}

Also add the extension method for above class:
public static class MiddlewareClassNameExtensions
{
    public static IApplicationBuilder UseMiddlewareClassName
        (this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddlewareClassName>();
    }
}


You can simply and easily create conventional middleware by using an item template in the
solution explorer.
Right click on your folder, that is CustomMiddleware
and go to add -> new item ->
Select Middleware Class (C#)
HelloCustomMiddleware.cs

This is the new way people prefer to write the middlewares.
*/

using _33._Custom_Conventional_Middleware_Class.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await next(context);

});

app.UseHelloCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h2>Hello Again</h2>");
});


app.Run();
