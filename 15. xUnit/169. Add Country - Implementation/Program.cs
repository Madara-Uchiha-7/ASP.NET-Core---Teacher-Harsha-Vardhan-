///
/// In Continuation of older lectures.
/// In CRUDTests add a package reference of Services.
/// 
/// Goto CountriesService and check the code and comments.
/// 
/// 


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();