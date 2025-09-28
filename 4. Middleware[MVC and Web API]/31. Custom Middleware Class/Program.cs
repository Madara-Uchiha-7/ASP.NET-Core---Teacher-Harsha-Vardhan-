/*
Your middleware has to execute some large amount of code.
So it has larger responsibility, in that case it would doesn't make sense
to write all of that code inside the same file.
It would be better to separate the same as a separate class and keeping it in a
separate file and that is exactly called as custom middleware class.

By default the middleware class has to implement an interface called IMiddleware
in order to register that, this class is a middleware and this IMiddleware interface forces
us to write invoke async method which will be executed when the request reaches to that particular middleware.
Here just like the lambda expression, it receives two arguments that is 'context' and 'next'.

So you can access the properties such as 'request' and 'response' by using this 'context' object.

class MiddlewareClassName : IMiddleware
{
    public async Task InvokeAsync (HttpContext context, RequestDelegate next)
    {
        // before logic
        await next(context);
        // after logic
    }
}

Lets seperate middleware 2 in seperate class.
Right click on the project,
add -> new item -> select class -> 
give file name : MyCustomMiddleware.cs

We can also place it in seperate folder.
Right click on the project,
add -> New Folder -> and add the class file in this folder.

We have created the folder : CustomMiddleware
In that we have added our middleware class file.

We have successfully created the custom middleware.
Now we have to register this custom middleware class as a service.
In order to do so, on the top, before the .Build() add :
builder.Services.AddTransient<MyCustomMiddleware>();

Services is of IServiceCollection type which can hold the list of services that
can participate in the dependency injection.
We add our custom middleware service by using .AddTransient()
There are different types of services lifecycle.
For example add transient add singleton etc.

So we have added our custom middleware as a service by using this AddTransient
method, so that we can acquire an object of the same by using dependency injection,
that means that class is ready to be instantiated whenever needed.


Now we call the second middleware after the 1st using :
app.UseMiddleware<MyCustomMiddleware>();

If you move this line on top, then this will become the 1st middleware.

Writing this 'use middleware' and then mentioning the class name
is a bit lengthy code. We can simplify the same by creating an extension method 
and we will try that in the next lecture.
*/
using _31._Custom_Middleware_Class.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await next(context);

});

app.UseMiddleware<MyCustomMiddleware>();

app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h2>Hello Again</h2>");
});


app.Run();
