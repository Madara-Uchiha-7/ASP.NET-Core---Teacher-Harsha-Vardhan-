/*

Just like you can make the view or partial view as a strongly typed view that is bound to a
specific model class, you can also make the view component as a strongly typed view component.

That means the partial view of the view component will be strongly typed to a specific model
class so that the view component class can supply a model object to the corresponding partial view.

We will pass the Model Object from the GridViewComponent using "return View();"
insted of using the ViewData or ViewBag.

Now in Partial view i.e. default.cshtml
on top we mention the model class name. i.e. PersonGridModel in this case.
So, then, insted of writing the @ViewBag.Grid.GridTitle, we directly use "@Model.GridTitle"
Here Model in the "@Model.", is the model which we are supplying from the GridViewComponent.

So when it comes to strongly typed view component, when you have a specific model
object to supply to the partial view, then you can consider making the partial view of
the view component as a strongly typed view. So that you can access the model properties easily
without you manually typecast them while writing HTML code in the view component.


Alternatively, if you want to pass some loose data, for example, one or more string values or
numbers, then viewData or viewBag is better.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();