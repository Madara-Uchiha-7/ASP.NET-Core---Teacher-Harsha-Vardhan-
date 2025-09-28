/*
Just like the predefined method called Use.

We have another method for middleware that is UseWhen both Use and UseWhen.
are used to attach the middlewares to the application request pipeline, but particularly the 
UseWhen  is used to execute a branch of middleware when a specific condition is true.

For example, we have made a request to some path.
Then the first middleware in the request pipeline executes.
After that, we are going to check the UseWhen condition.

You can write any condition which may check any details in the request such as,
we can check the header values of the request or request, query string or request method, or else
anything in the request.
For example, we are checking If the authorization token is present in the request headers.
If the condition is true, we are going to execute a branch of the middleware.
Means a set of Middlewares.
But alternatively, in case if that condition itself is false, we are not going to touch that middleware
branch, but we continue with the regular middleware main chain.
Here, the meaning of main chain is the actual collection of Middlewares that should be executed commonly
for all the requests.


Request to /path
-----------------> Middleware1 - in main chain
                            |
                           \|/
                            |
                        Use When                                            Middleware Branches:
                            |                                          --------------------------         
                            ------------> If condition satisfies -->  |     Middleware Branch 1  |
                            |                                         |             |            |
               If condition does not satisfies                        |             |            |
                            |                                         |             |            |
                           \|/                                        |            \|/           |
                            |                                         |             |            |
                        Middleware 2 - in main chain                  |     Middleware Branch 2  |
                                                                       __________________________  







UseWhen()
We pass 2 arguments, the lambda expression which returns a boolean value that contains the condition.
Second lambda expression is executed only when the 1st lambda expressionn is true.
The app parameter here means the Applicationbuilder with which you can write your 
use statements regularly.

If condition is false then below app.Use / app.Run will be executed.

Run the app and add:
?username=chinmay 
in the url and then press enter.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Condition true.");
            
            // This next() will call the below app.Run() which will get called also
            // if UseWhen condition is false.
            // If condition is true and if we skip below next() then below 
            // app.Run() will not get called.
            await next();
        });
    });
app.Run(async context =>
{
    await context.Response.WriteAsync("Condition false.");
});

// Adding an empty app.Run() statement is more of a convention as defined by Microsoft,
// in order to define end of request pipeline.
app.Run();
