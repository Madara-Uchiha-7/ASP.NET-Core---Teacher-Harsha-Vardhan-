/*
By default, a parameter accepts any value into that.
For example, if you supply an alphabetical value or numerical value, or even alpha numerical value,
or a date value, or a boolean value, by default all types of values are accepted by this parameter.

But generally you would like to restrict the type of values, right?

For example, I am wanting to accept only int values in id parameter.

So in order to specify restrictions on the parameters, there is a concept called constraints.

Basically, when an incoming request is received by the ASP.Net core application and it has been reached
to the routing middleware, it will verify whether that parameter value in the URL matches with the
constraint.
So the constraint has been stored as a part of the endpoint.
And that is being verified.
Here the constraint is nothing but a condition or a restriction.

So if that constraint is matched with the incoming URL, then it will execute the endpoint as usual.
Otherwise it will look for the next upcoming route.
Of course, if all the routes are not matched totally, it executes the final fallback route that is
present at the end of the application request pipeline.

To make it possible:
After your route parameter name 
give 
:typeName

Few data types are allowed such as int long, double decimal, bool, etc. but you cannot use all the
primitive data types here.

Constraints are different than data types.

products/details/{id:int?}"
Notice how we kept the ? also with type constraint.


ASP.NET Core provides a variety of built-in route constraints:

int: Requires the parameter value to be an integer.
matches with : 123456789, -123456789

bool: Requires the parameter value to be a boolean (true or false).
matches with :  true, false, TRUE, FALSE

datetime: Requires the parameter value to be a valid date and time string.
matches with : 2023-01-01%2011:59%20pm
Note: %20 is equal to space.
We can also pass only time or only date using above format.
 
*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map(
    "products/details/{id:int?}",
    async (HttpContext context) =>
    {
        string? id = Convert.ToString(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"The ID is : {id}");
    }
    );

app.MapFallback(async (context) =>
{
    string url = context.Request.GetDisplayUrl();
    await context.Response.WriteAsync($"You are at Default : {url}  Url.");
});

app.Run();
