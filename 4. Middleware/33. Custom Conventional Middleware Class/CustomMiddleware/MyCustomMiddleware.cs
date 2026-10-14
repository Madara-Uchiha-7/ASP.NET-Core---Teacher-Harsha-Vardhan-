
namespace _33._Custom_Conventional_Middleware_Class.CustomMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("<h2>Custom Middleware starts!!!</h2>");
        await next(context);
        // After completing the execution of next middleware,
        // controll will come here and will execute the below statement.
        await context.Response.WriteAsync("<h2>Custom Middleware ends!!!</h2>");
    }
}
public static class CustomMiddlewareExtension 
{
    // We will be able to access the 'this' object by using
    // any one variable such as 'app'.
    // So this 'app' parameter is equivalent to our variable 'app' object in Program.cs
    // It is a convention to prefix the method name with 'use'. 
    // Just like all the predefined extension methods or prefix with use.
    // E.g UseRouting, UseEndPoints, UseMiddleware
    // This way we will know that the method is related to the pipeline. 
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
    {
        return app.UseMiddleware<MyCustomMiddleware>();
    }
}

