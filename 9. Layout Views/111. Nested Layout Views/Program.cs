/*
The meaning of nested layout view is you will apply one layout 
view for another layout view.

A layout view that has another layout view is called as "Nested Layout View"

Lets say our goal is to apply the _ProductsLayout layout for the Views of the Product Controller.

Also for the _Layout and _ProductsLayout
we want to apply the Master layout.

On shared folder 
add -> Razor Component -> Razor Layout -> _MasterLayout.cshtml

We have added the link tag to css file and html code in it.
So, we do not need to add this link tag in to _Layout and _ProductsLayout layouts.
and _Layout and _ProductsLayout layouts code will come in the @RenderBody() of _MasterLayout

In _Layout and _ProductsLayout layouts, on top, we have added the parent layout for these 2.

In global _ViewStart file, we do not change the code, we keep the same as before.

In Products folder,
add -> Razor Component -> Razor View Empty -> _ViewStart.cshtml
Here we added a path to Product Layout.

Run the application and check the working.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();