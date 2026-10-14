namespace _33._Custom_Conventional_Middleware_Class.CustomMiddleware;

class HelloCustomMiddleware
{
    private readonly RequestDelegate _next;

    public HelloCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Logic before
        await context.Response.WriteAsync("<h4>Custom Conventional Middleware starts!!!</h4>");

        await _next(context);

        // Logic after
        await context.Response.WriteAsync("<h4>Custom Conventional Middleware ends!!!</h4>");
    }
}
public static class HelloCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseHelloCustomMiddleware
        (this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HelloCustomMiddleware>();
    }
}
