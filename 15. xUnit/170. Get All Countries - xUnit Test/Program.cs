///
/// In Continuation of older lectures.
/// In CRUDTests add a package reference of Services.
/// 
/// We will implement GetAllCountries() in next lecture and will add Unit tests to this in this lecture.
/// 
/// In the ICountryService add this method definition.
/// Read the comments also.
/// 
/// Now open up the CountriesService.cs
/// 
/// Add this method, check the code and comments.
/// 
/// Now Goto CountiesServiceTest.cs
/// Check the code and comments.
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