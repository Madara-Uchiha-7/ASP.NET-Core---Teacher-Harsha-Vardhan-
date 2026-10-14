///
/// In Continuation of older lectures.
/// Let us write implementation for the GetAllCountries.
/// 
/// Goto CountriesService.cs
/// Check the code and comments.
/// 
/// Once that is done, check the end of file comments from CountriesServiceTetst.cs.
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