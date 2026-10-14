/*

It is possible to supply the ViewData object from the ViewComponent class into the ViewComponent PartialView.
But it is not possible to supply the ViewData object from the View to the ViewComponent class.

Lets send a model object from the ViewComponent class to the PartialView.

Right click on the Project and create a Models folder.
In that create a Model class i.e. Person.cs

We create one more Model PersonGrid model.
So we created a PersonGridModel.cs

We will access this in GridViewComponent.
We created the object and the data of Models in our component.
Then we will use this in our Partial View.
To use it we assign our model object to ViewBag or ViewData.
We have used ViewData:
ViewData["Grid"] = personGridModel;


The ViewComponent class and the corresponding PartialView 
has an individual ViewData. It should not be confused with the ViewData of the Controller and View.


For example, at runtime,
from the HomeController to the corresponding IndexView,
one ViewData object and between the GridViewComponent
and the corresponding PartialView, there is another ViewData object.
Both are independent objects.

Now, we have used this object which is in the ViewData in the partial view,
i.e. here its Default.cshtml

In default.cshtml 
why we commented:
<h3>@((PersonGridModel)ViewData["Grid"]).GridTitle</h3>

because its very hectic to get the value from the value from ViewData.
Same value we can get using the ViewBag with less efforts:
<h3>@ViewBag.Grid.GridTitle</h3>
In this we do not need to even typepcast the value like we need to do so in ViewData.

So overall, the execution sequence is
at first controller.
The controller calls the view that is index view.
And in the index view,
we are invoking a view component called grid.
Now it goes to the grid view component.
Here it automatically calls the invokeasync,
creates a model object,
adds the model object to the view data.
Then it invokes the default partial view.
default partial view uses the model object.
This whole default partial view html code is loaded into the area from where its called,
i.e. index and about views.


Is it possible to share any data from the view to view component?
And also another question is, is it possible to make the partial view
as a strongly typed partial view?

Answers are in the next lectures.


Quick Note about:
@foreach (Person person in ViewBag.Grid.people)
If you write "var" instead of "Person"
then in for loop if you use "person" object, the VS will not suggest/show the 
properties related to it which it does when you type the "." after the "person".

So temporary you can keep "Person" word till you are developing, 
after development you can move it to "var". Or its on you what to keep.
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();