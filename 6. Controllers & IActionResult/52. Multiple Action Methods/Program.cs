// Lets define the route for the default URL.
// That is for when we run the application.
// It is defined in HomeController.cs

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
