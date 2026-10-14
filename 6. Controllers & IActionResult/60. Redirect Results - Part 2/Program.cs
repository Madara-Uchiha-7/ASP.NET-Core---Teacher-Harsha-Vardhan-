// In this lecture, let us find the other type of redirections, that
// is, return new LocalRedirectResult("local_url", permanent) and return new RedirectResult("url", permenant);
// Lets go to our HomeController.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

