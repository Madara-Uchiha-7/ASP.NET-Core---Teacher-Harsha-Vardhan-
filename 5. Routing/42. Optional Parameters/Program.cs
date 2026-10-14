/*
Suppose your requirement is in case if the user doesn't supply the file name,
in this case, instead of assigning a default value into that parameter, you would like to take it
as null by default.
In case of null, we can check some condition and we can print some different message to the response.
In case if you try assigning file name equal to null, it doesn't work.

Alternatively, you have to make that parameter as optional parameter by suffixing that parameter name
with ?

So whenever you suffix question mark, that means that parameter is optional parameter.
That means the user may not supply the value for that.

If you try to convert Route parameter value which is null in this case
into the integer then int will convert the null into 0.

.RouteValues.ContainsKey("Route Parameter key name") 
will retrun false if we did not pass it from url and we are using route optional parameter.

*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map(
    "file/{fileName}.{extensionName?}",
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
