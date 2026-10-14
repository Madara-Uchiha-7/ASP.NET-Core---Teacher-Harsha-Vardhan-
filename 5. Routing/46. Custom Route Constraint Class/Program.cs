/*
Suppose particular regular expression constraint has to be applied in more than one place in your
whole application. So instead of manually repeating the same regular expression in everywhere, you can also convert the
same as a custom constraint.

Means you will create a class only for the constraint.
The custom constraint works equivalent to a normal constraint, but instead of a simple constraint,
it would be a class.

That means upon receiving the request while verifying the route, it will check that custom constraint
means it executes the custom constraint class.

It checks whether the incoming request value matches with this custom constraint or not by executing
a method called match.

So if it matches, it executes the end point.

Otherwise it will go to the next route to check the incoming request.


The custom constraint class looks like this:

public class ConstraintClassName : IRouteConstraint
{
    // So this particular match method will be executed in order to verify whether the incoming request matches
    // with this constraint or not.
    public bool Match(HttpContext? httpContext, IRouter? route,
        string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        // Code
    }
}

---------
Use it using:
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("name", typeof(ClassName)); // "name" is our custom constraint name.
};
--------------------
So in our application, let us convert (month:regex(^(apr|jul|oct|jan)$) regular expression as a custom constraint.

Optionally, you can place all of your constraints in a separate folder.

*/

using _46._Custom_Route_Constraint_Class.CustomConstraints;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    // "months" : This name can be anything. Here "months" is our user defined constraint name.
    // We will use this custom constraint name anywhere.
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraints));
});

var app = builder.Build();

app.Map(
    "sales-report/{year:int:min(1900)}/{month:months}",
    async (HttpContext context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($" In the {month}.{year}");
    }
    );

app.MapFallback(async (context) =>
{
    string url = context.Request.Path;
    if (url.Contains("file"))
    {
        await context.Response.WriteAsync($"Wrong file name.");
    }
    else
    {
        url = context.Request.GetDisplayUrl();
        await context.Response.WriteAsync($"You are at Default : {url}  Url.");
    }
});

app.Run();


/*
Qustion:

Does custom constraints have a possibility of accepting parameters ?

Teacher ans:
Yes, custom constraints can accept parameters through the constructor.



You can create a parameterized custom constraint like this:

public class MinimumValueConstraint : IRouteConstraint
{
    private readonly int _minimumValue;
 
    public MinimumValueConstraint(int minimumValue)
    {
        _minimumValue = minimumValue;
    }
 
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!values.ContainsKey(routeKey))
            return false;
 
        if (int.TryParse(values[routeKey].ToString(), out int value))
        {
            return value >= _minimumValue;
        }
        return false;
    }
}


Then register it with parameters:

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("min", typeof(MinimumValueConstraint));
});


Use it in routes like: {id:min(18)} and the framework will pass 18 to the constructor automatically.
*/