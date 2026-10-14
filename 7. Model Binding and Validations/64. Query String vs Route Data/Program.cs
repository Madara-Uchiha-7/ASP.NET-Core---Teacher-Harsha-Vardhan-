// Lets focus on "Route Data and Query String Parameters" from Model Binding.
// The route data is nothing but the route parameters that we have learned in the routing section.
// So you can represent the route parameters in the form of curly braces while creating the routes,
// So at runtime, as a part of the URL, you can supply any values for those route parameters
// and that is technically called as route data in this model binding.
// Here query string means the query string parameters that are a part of the URL in the get
// request.
// E.g. in the last lecture, we passed ?bookId=1&isLoggedIn=true as a query string parameters.
// And we are taking those values from Request.Query[""] or ControllerContext.HttpContext.Request.Query[""]
// This is error prone and lengthy.
// Lets use model binding for that.
// Go to controller for that.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

