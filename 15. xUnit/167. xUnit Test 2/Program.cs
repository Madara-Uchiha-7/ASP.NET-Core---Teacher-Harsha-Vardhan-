///
/// In Continuation of older lectures.
/// 
/// Lets create one more DTO.
/// Name the class : CountryResponse
/// Because the return type of the AddCountry method is CountryResponse.
/// And all the inputs are request type.
/// For example, in case of updation,
/// you will say CountryUpdateRequest and CountryResponse.
/// CountryUpdateRequest is the argument and CountryResponse is the return type.
/// 
/// 
/// Make it public.
/// Because it must be accessible by the other project that is in the ASP.NET Core project.
/// Import the Entities namespace.
/// 
/// Check the comments and code in it.
/// 
/// Lets add a code in ICountryService
/// Check the comments and code in it.
/// 
/// As per the TDD, that is Test Driven Development,
/// we are not going to implement this interface method first. But we will test it first.
/// Let the unit test fail first.
/// In TDD, That is the functionality follows the requirement.
/// This is one of the best practices.
/// That means the implementation should follow the unit test.
/// But the unit test should not follow the implementation.
/// 
/// Now, let's create a unit test method for this AddCountry.
/// 
/// Right-click on CRUDTests.
/// Add new Item -> class -> CountriesServiceTest.cs
/// 
/// Make it public.
/// 
/// We will use "_countryService" in this, so add the reference of "ServiceContracts" into "CRUDTests"
/// Also add Entities.
/// 
/// Check the code and comments in it.
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
