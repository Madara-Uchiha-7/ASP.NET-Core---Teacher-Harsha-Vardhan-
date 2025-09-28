/*
Lets use app.Use() instead of app.Run()
The app.Use can create a middleware that can either forward the request to 
the subsequent middleware or can also short-circuit the same.

For .Use() lambda must receive the 2 arguments instead of one.
We need to pass RequestDelegate as additional parameter.
Second parameter represents the next middleware whichever is present
below the current .Use().

We will call that next middleware using next(), we will also give it our current context object.
Our app.Run() will receive this context.

Once 2nd middleware finishes its work then the control will again go back to the 
middleware 1 i.e. the middleware which called the current middleware.
This happens so that the code after the next() should be also completed.

Once main middleware finishes its execuation, final response will be given back to the browser.

We can skip the next() method and not use it, if we do not want to call the next middleware.

We can place this next() in condition statement, i.e. 
goto next middleware only of certain condition is matched.

Right click on app.Run and app.Use and check their definitions.
You can see the 'run' method is an extension method which is added into the
IApplicationBuilder that is 'app' and it requires only one argument over there. that is 'RequestDelegate'.

Right click on 'RequestDelegate' and go to definition.  
You can see it contains only one argument that is HttpContext.
Thats why in the lambda expression we are writing only 1 argument and it is HttpContext.

'use' method is an extension method which will be injected into IApplicationBuilder that is 'app' 
and it has only one argument:
Func<HttpContext, Func<Task>, Task> middleware
but it should contain two types of arguments.
One is the 'http context' and second one is 'request delegate'.

It is optional to write the data types in the lambda parameters, because in the predefined library itself
it is already written.
If you decide to not to write the data type names then you can not skip the next() method call.
Other wise you will get the compile time errors.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await next(context);

});
app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h2>Hello Again</h2>");
});


app.Run();

///
/// Why chrome sends the 2 requests for the first time when we run the app.
/// Additional request is for the Fevicon icon. This is the icon or image which chrome is asking 
/// to use to show it on the tab with our tab name.
///