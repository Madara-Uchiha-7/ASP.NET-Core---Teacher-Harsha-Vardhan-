// Lets see how to return the data in JSON(JavaScript Object Notation) format.
// You can go to HomeController.cs

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
