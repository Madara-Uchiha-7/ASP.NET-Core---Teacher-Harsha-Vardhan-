/*

decimal:
e.g. 49.99, -1, 0.01

long: Matches with long values.
e.g. 123456789, -123456789

guid: Requires the parameter value to be a valid GUID (Globally Unique Identifier).
It is the 128 bit hexadecimal number that is universally unique.
Because a Guid includes a timestamp and random or hardware based values like Mac address.
So this guid is almost unique.
To convert it using code lets see the e.g. in code.
To run that endpoint, goto tools -> create GUID in VS -> select 4th i.e. registry format file.
Then add it in url and test.

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

app.Map(
    "cities/{city:guid?}",
    async (HttpContext context) =>
    {
        Guid id = 
        Guid.Parse(Convert.ToString(context.Request.RouteValues["city"])!);

        await context.Response.WriteAsync($"The ID is : {id}");
    }
    );

app.MapFallback(async (context) =>
{
    string url = context.Request.GetDisplayUrl();
    await context.Response.WriteAsync($"You are at Default : {url}  Url.");
});

app.Run();
