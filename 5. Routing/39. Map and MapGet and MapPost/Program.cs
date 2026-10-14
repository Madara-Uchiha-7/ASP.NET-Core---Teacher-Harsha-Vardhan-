/*
We will check Map methods.
*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1st argument is URL.
// In this 1st argument "/" is optional.
// 2nd argument :  
// If the incoming request URL exactly matches with this URL, then we are going to provide a 
// RequestDelegate means a middleware that can receive the context as argument. 
//
app.Map("/map1", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from Map 1");
});

// Run the app.
// When you will run this app, you will get 404 error, you need to add
// /map1 in the url and hit enter.

// If no url matches the it gives 404 error.
// To avoid this use:
app.MapFallback(async (context) =>
{
    string url = context.Request.GetDisplayUrl();
    url += "map1";
    await context.Response.WriteAsync($"Please use : {url} to get the map1 middleware.");
});
// It will execute if the incoming request URL doesn't match with any of the routes mentioned above.
// This endpoint middleware is always placed at the end of the middleware pipeline by the framework.
// You cannot place middleware after the endpoints even if you write app.Use method after your map
// methods, it still gets executed earlier in the pipeline.
// The endpoint middleware is a terminal middleware, and once a route is matched and the corresponding
// handler runs, the pipeline ends there.
// Any middleware you define using app dot use method will always run before the routing
// and endpoint execution.
// 

// That is the order in which you register endpoints using MapGet, MapPost, etc. all doesn't matter.

// The Map() endpoint/method
// executes any reuest method i.e. get, post or any other HTTP method.

// But suppose your requirement is that you would like to execute your endpoint only for get request for
// this URL, but not for any other type of HTTP method.
// Then we have the method that is MapGet();
// Similarly for post you have a MapPost();

// Using Postman you can check this.

app.Run();