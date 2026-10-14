/*
Original namespace name is namespace _31._Custom_Middleware_Class
we can change it to .Foldername
*/
namespace _31._Custom_Middleware_Class.CustomMiddleware;

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

