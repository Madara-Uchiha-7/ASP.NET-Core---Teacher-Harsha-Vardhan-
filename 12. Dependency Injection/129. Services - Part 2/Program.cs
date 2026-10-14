/*
Add a new folder first.
Name it : Controllers
Right click on it and add a new controller.
Select MVC Controller Empty.
Name it : HomeController.cs

Apply the Route for this:
[Route("/")]

Lets create a view.
Right click on Index()
Add View.
Razor View Empty.
Click on Add on Index.cshtml : We added only a Welcome Line here,
the code in this file is latter updated in this lecture.

Check the code in it.

Lets now create a layout view.
Right click on Views folder.
Add a new folder.
Name it : Shared
On Shared, right click -> Add -> Razor Component -> Select Razor Layout
File name : _Layout.cshtml

Right click on project.
Create a new folder called 
wwwroot

Now right click on wwwroot and add new Item -> StyleSheet.css
We addded a code in this .css from teachers code.

Lets add this .css link to _Layout.cshtml
We added a ~ before the path :
Because it represents the domain, that is localhost and then port number.
Then you can access any file from the www root folder.

Right click on Views folder.
Add -> Razor Component -> Select "Razor View Start" -> _ViewStart.cshtml (This is the fixed name)

Change  Layout = "_Layout"; TO Layout = "~/Views/Shared/_Layout.cshtml"
So, it applies the layout view commonly for all the views.
Also, optionally, try to create view imports file.
Right click on Views folder -> Add -> Razor Component -> Razor View Imports 
File name is fixed..that is use default file name.


Lets come back to home controller: i.e. HomeController.cs
Lets invoke the cities service.
We need to create the Object for that first.
Before than that, let me create a reference variable for that cities service.
So, we added :
private readonly CitiesService _citiesService;

In last lecture we created a service called : CitiesService
Lets connect this project to this.
So we need to add a reference for this.
The reference of the "Services" should be added in the "Services - Part 2" project.
Means, in the destination, you have to add the reference to the source.
Here the source is cities service, which is the part of the Services class library.

Right click on project -> add  -> Project reference -> Select Services and click on OK
OR
You can click on Dependencies -> Add Project Reference.

If Class Library Services is present somewhere else then there is a browse option also.

Once that is done, import the namespace in the HomeController.cs So that we can use this class.

Lets add a next code:
public HomeController(CitiesService citiesService) 
{
    _citiesService = citiesService;
}

Lets use _citiesService in our action method:
List<string> cities = _citiesService.GetCities();
Now, we are in the controller Without worrying about from where the actual list of cities are coming,
we can simply demand the service.
That means we can simply call the method.
So, it is the responsibility of the service. 
It may return some mock data or may return the data from in-memory collection or data from any database.
We don't care about that being from the controller perspective.
I just call the method plus I'm getting the list of cities.
The return type of this get cities method is list of string.

Then we give this to View() as a ModelObject so that the view can be the strongly typed view
can be bound to this list of string. So, finally it will be able to receive this actual data
that was sent by the controller.:
return View(cities);

Now, goto 
index.cshtml
check the code in this file...I have added the comments.

When you make a request i.e. when you run this app:
At first, the controller executes.
Always and always, the request is received by the controller.
Of course, after all the middlewares that are added in the program.cs file.
That means, actually it first executes all these middleware,
that is, use the static files, use routing
and when exactly it has reached to this MapControllers method,
then it starts executing the controller. 
At first, it automatically creates an object of the home controller class
and as a part of that, we have created the cities service class object
in the constructor of the Controller.
As we are creating an object of the cities service,
it invokes the corresponding constructor where we have just created a list of string of cities.
Once the constructor of the home controller has been completed.
As we have made request to the route path called slash, the index action method executes
and there exactly we are invoking the GetCities method of the service.
Now, you will return the list of string as model object to the view.
Now execution goes to the view.
In that view,
it iterates through each item in the model, means list of city and prints the same.

After completion of the loop, you will get to the rendered UI
and then actually it goes to the layout view of course.
So the content of the view i.e. all the rendered cities and its html
will be rendered in this place. i.e. @RenderBody() in _Layout.cshtml
Then whole "_Layout.cshtml" is sent to the browser as a response.
In _Layout.cshtml we are adding the path to css.
That request to CSS is done by:
app.UseStaticFiles();

Bad practice in this lecture is 
we created a object of the class CitiesService in the HomeController's constructor.

We need to use dependancy injection in this case.
*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();