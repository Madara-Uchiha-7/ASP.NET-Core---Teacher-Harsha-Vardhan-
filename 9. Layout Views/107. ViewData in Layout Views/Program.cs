/*
There is Something called as the ViewData.
This ViewData can be passed to our Controller Action method's view or Layout View
using the order we saw in the last lecture's end area.

In our Home Controller's Index View
we are setting the View Data for title which we have accessed in the layout view.
Similarly we are passing the Title from our About view to Layoute view.
So, now, title changes dynamically depending on our selection of view.
Similarly, we have done same for all other views.

View data is the key value pair.
The key cannot be null and cannot be duplicate, but value can.

Run the project and click on different views and then check the browser tab's
text for each oh the view.

Thr purpose of the 
_ViewImports is to import the namespaces.
It should not do anything extra than this.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
