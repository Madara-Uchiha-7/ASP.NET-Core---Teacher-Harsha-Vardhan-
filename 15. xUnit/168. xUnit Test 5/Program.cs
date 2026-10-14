///
/// In Continuation of older lectures.
/// In CRUDTests add a package reference of Services.
/// 
/// Now go to the CountriesServiceTest.cs
/// Check the comments and read the code.
/// 
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
