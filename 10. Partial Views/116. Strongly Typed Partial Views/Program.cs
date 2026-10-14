/*
There is another way that you to sent the Model Object to the view.

That is, you can make the view as a strongly tapered view.
That means, the partial view is tightly coupled with a specific model
class or list of the model class, so that it can receive
an object of the model class at runtime.

Already we made the normal views as strongly tapered views, but it
is also possible to make the partial view as a strongly type.

In this Project create a new folder -> Models 
In it add -> ListModel.cs

In it we will create the properties which we want to send to the view.

In the _ViewImports file we will import our Model.
Then in Index view, we will create the object of that model and use it.
We have used "model" attribute to send it to the Partial View.

In the Partial View, we have added "@model ListModel",
this made _ListPartialView as a strongly typed view.
Then we have used this Model in this file. e.g. @Model.ListTitle


What happens if we invoke the Partial View in the About view, but did not supply the model object?
We will get NullReference Exception.


*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
