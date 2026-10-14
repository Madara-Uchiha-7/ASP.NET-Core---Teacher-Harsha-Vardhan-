/*
When Partial View is invoked, it receives the Copy of the parent View's ViewData Object.
So, any changes made in the ViewData in the Partial View, do not effect the ViewData of the 
parent View.
For example, in the view data object of the view, there are five items.
So automatically, at runtime, ASP.NET Core creates another copy of the
view data object with the same items and that view data copy
will be sent to the partial view.
So, if partial View updates the ViewData, it does not impact the View's ViewData.

                                                           copy             
Controller(Action Method's ViewData) -> View (ViewData) ---------> Partial View(ViewData)

In the HomeController'a Index action method,
We write the ViewData. Its a key value pair.

Then we access them in the _ListPartialView.

We are using the ViewData in it, to access the value using the key.
We used "@ViewData["ListTitle"]" statement. You can also use @ViewBag.ListTitle here, even though
you are using the ViewData in the action method.

The ViewData in the action method will be sent to the Index view, then in the partial view,
its copy is sent.

So, we added the ViewData in Index action method,
that is sent to the Index view.
So, "@await Html.PartialAsync("_ListPartialView")" statement will print the 
Countries in the View data from the Index action method,
Then we updated the View Data in the Index view,
so "<partial name="_ListPartialView"></partial>" prints the updated Countries.
Because the partial view will use the ViewData of the Index view.

We have used ViewData or ViewBag, both are same.


Moreover, there is a possibility
that you can supply a specific view data object either in renderPartialAsync or in the
PartialTagHelper.

That means you are going to create another view data object and
that is being sent to the partial view instead of sending the complete view data object to the.
partial view.

This is shown in the About Views.
If you want to supply the new view data in the <partial> tag then use attribute
view-data="new-view-data-object-name" i.e. the object of "ViewDataDictionary"

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
