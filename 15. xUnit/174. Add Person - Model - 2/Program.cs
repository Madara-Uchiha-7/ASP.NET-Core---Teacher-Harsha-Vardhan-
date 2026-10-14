///
/// 
/// Goto PersonAddRequest class, check the code and comments.
/// Lets create a one more DTO
/// PersonResponse
/// 
/// Check the code and comments in it.
/// 
///

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
