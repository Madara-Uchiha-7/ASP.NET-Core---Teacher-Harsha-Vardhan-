/*
The partial view is just about rendering the UI, right?
That means you will place some reusable HTML code 
means presentation logic in the partial view and it can be invoked anytime.

But when you want to merge some additional programming logic 
along with the UI logic, then view component is your choice.

For example, you will create a view component class where you will place your programming logic.
You can write the programming logic for calculations 
or retrieving the data from any data source such as databases
and supplying the model data to the view.
So the partial view which is the part of the view component will render the UI.

And just like the partial view, you can invoke the view component
in any other view wherever you want by using this statement:
@await Component.InvokeAsync("view component Name");

Lets start.
We added basic code in this file.
Then we added our css file in wwwroot. CSS file code is of teacher's.
Then we created a controllers folder and added a MVC controller empty in it.

Then on index action method, we right clicked and then I did the add view -> razor view empty.
Similarly I created the About View.
Then created a Shared Folder.
Right clicked on the Shared Folder -> Razor Component -> Razor Layout -> _Layout.cshtml

Right click on the Views Folder -> Add -> Razor component -> Razor View Start -> Default name.
Add the path to layout view in it.
Add a link in the Layout view.
Add a ViewBag.Title in Index and About Views, so it will be used dynamically in the Layout view's title tag.

Add a link to CSS in the Layout View.

Add a new folder in the Controllers Folder : ViewComponents
In this add a new Item -> GridViewComponent.cs

Suffix "ViewComponent" is mandetory.

In that class,
to make it a view component, we inherit the class "ViewComponent".
Its present in Microsoft.ASPNetCore.MVC

The rule is,
Every view component class should be suffixed with the word ViewComponent which we 
have already done, Or it should have an attribute called [ViewComponent].
We have done both just to show.
And also.
It is optional to inherit from ViewComponent base class.
But if you don't do that, you will miss some useful methods such as return view.

Each View component must have the method called InvokeAsync()
Because this method gets called automatically by ASP.NET Core when you invoke the 
View Component from any one view.
Its return type is "Task<IViewComponentResult>". Because of this we can do "return View()".
This View() is a Partial View, not the regular View.
But the default location of the partial view is
Views/Shared/Components/Then a folder with the same name as the view component name without the suffix.
So the actual view component name is Grid.
So with the same name, there should be a subfolder under Components folder.
Then the actual view name is Default.cshtml.

It's too lengthy path, but it's the default preferred location.
Because the partial views of the view component should be separated from
the regular partial views.

Lets move to the next lecture.

*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
