/*
Let's say, for example, our application requires two URLs.
That means two types of requests.

If you send request to /files/ some file name, then it has to provide the corresponding file content.

If you send request to employee/profile/ some employee name, it has
to provide the corresponding employee profile.

In each URL
there are some parts that are fixed and some parts can vary.

/files/ is fixed. So this particular segment means this particular portion is literal.
Means fixed value.

But the other value can be vary, right?
It can be any file name and any file extension.
So whichever the parts of the URL can be vary, those are called Route parameters.
So we can write :
{fileName}.{extensionName}
fileName and extensionName will vary and will be received at run time
so called as parameters
and the dot in between them is literal.

We can read these parameters in the middleware using
context.Request.RouteValues
It is a dictionary. It will have the key with the same name as the Route parameter name.
By default it returns the data in the form of system.Object class.
So use, Convert.ToString() because we need it in a string format.
In case of number, use Convert.Int32.

Route parameter names and literals are case in sesitive.
So, if Route parameter name is firstName and in middleware 
you are writing:
context.Request.RouteValues["filename"];
Then still it will work.
*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Since first / is optional, I am skipping it.
app.Map(
    "file/{fileName}.{extensionName}",
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
