/*
We will check Map methods.
*/
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

app.Run();

// When you will run this app, you will get 404 error, you need to add
// /map1 in the url and hit enter.