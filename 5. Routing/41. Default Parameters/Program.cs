/*
What if you do not supply the values for the parameters.
Or you supplied for one and did not supply it for second one.

For e.g. in last e.g.
if we pass the file name as: names.
and did not pass the "txt", we will not get the error and 
app.MapFallback will run.

We can pass the default value like "txt" to the route parameter.
We have done it below in : {extensionName=txt}


*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map(
    "file/{fileName}.{extensionName=txt}",
    async (HttpContext context) =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? extensionName = Convert.ToString(context.Request.RouteValues["extensionName"]);

        await context.Response.WriteAsync($" In the file {fileName}.{extensionName}");
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
