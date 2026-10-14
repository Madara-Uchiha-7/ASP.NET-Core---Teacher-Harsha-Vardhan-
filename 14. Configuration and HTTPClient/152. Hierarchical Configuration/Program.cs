/*
Sometimes you would like to maintain this hierarchical configuration as well.
E.g.
{
    "MasterKey" :
    {
        "Key1" : "Value",
        "Key2" : "Value"
    }
}

We do :
Configuration["ParentKey:ChildKey"]
The : acts as a way to reach the child.

But there is another method or another way to read the hierarchical configuration.
GetSection(string key)
This is from IConfiguration interface.
It returns an object of the IConfiguration section object.

Check the HomeController Code.
*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();

// Better than current approach,
// For reading the part of the configuration instead of reading the entire configuration file.
// The options pattern is more recommended.
// Its in next lecture.