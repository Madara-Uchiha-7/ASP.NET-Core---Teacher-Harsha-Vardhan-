// Lets override the ASP.NET Model Binding priority approach.
// And lets force it to use the Query string Prarmeter instead of Route Data.
// To do this we will use FromQuery and FromRoute.
// Syntax:

// public IActionResult ActionMethodName([FromQuery] type parameter) { }
// public IActionResult ActionMethodName([FromRoute] type parameter) { }
// Lets do that in our HomeController

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

