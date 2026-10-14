/*
Create a New Project called CRUD.
In it we will add the code.

In that we added the Views, stylesheet.

In goole we search:
cdnjs font awesome.
Link:
https://cdnjs.com/libraries/font-awesome

It is one of the third party tools which offers the icons which can be inserted
in the buttons as well as menu items.

We selected 6.1.1:
Then on
"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/fontawesome.min.css"
We click on </>

Then we used this link in our application _Layout.cshtml
Then we added _ViewStart and _ViewImports.

Then we added controllers.


*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
