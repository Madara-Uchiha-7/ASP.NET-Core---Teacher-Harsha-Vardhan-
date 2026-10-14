/*

In ASP.NET Core, the view is a web page that is responsible to contain the design logic or presentation logic.
The presentation logic can be either in the form of HTML or C-sharp.
HTML code is called as client-side code and C-sharp code is called as server-side code.
That means, at first, at server-side, the C-sharp code executes,
and after that, the result of the view will be sent to the browser as response,
then on the browser, the HTML code executes.

The view will be invoked by the controller.
The main responsibility of the controller is that, it sends the ViewModel object to the view.
At first, the controller creates an object of the ViewModel or a collection,
then it fills up all the values that are essential to print the output.
But controller doesn't generate any real output.
Controller just passes the ViewModel object to the view.
Then, the view directly accesses the properties of the ViewModel.

Controller (Action method) -> 1) View Model (Properties)
                                ^
                               /|\   
                                |   3) View
                                |
                           -> 2) Presenatation Logic 


Controller decides which view to run.
For example, there is a route parameter called displayMode.
It has two options, that is either summary or detailed.
So if the route parameter value equal to summary, it invokes one view.
If it is equal to detailed, it invokes another view.
So based on the route parameter or based on the data from database,
the controller is able to decide which view should be executed based on the requirement or situation.
Or maybe based on the user requirement.
Then ViewModel object is given the View.
Then the view reads the data from that ViewModel. 
For example, the EmployeeView reads the data from EmployeeViewModel that is supplied by the controller.
Then as a part of the presentation logic, the actual details of the employee will be populated in the respective place
wherever that ViewModel properties are accessed.
In that way, the view result executes and you will get the plain HTML code
and that will be the response that is sent to the browser.

Lets add code in program.cs:
builder.Services.AddControllersWithViews();
app.UseStaticFiles();
app.MapControllers();

Create a wwwroot folder
It is used to place the static files such as images, icons or any other static content.
Creating another folder.
That is Controllers.
And now right click on the controllers. Add new controller -> MVC controller empty -> HomeController.cs

We have Index() action method. We can change the name if intreseted.
Lets add Routing for this.
[Route("/home")]
So if the user sends a request to home,
this action method will be executed.
In that action method, we are returning return View();
This means, this view method creates and returns an object of the view result class.
You can also do the same manually, isn't it?
i.e. return new ViewResult() { ViewName =  "abc" };
So, when application runs, this will code will search for abc view where the file extension is
.cshtml
Here .cs indicates C sharp and html indicates html.
Because you can write both C sharp and html together intermingled in the same file.
Of course, this is the lengthy way to create the view result,
which is not being used in the real world projects.
So we will use default code i.e. return View();

The controller base class provides a predefined method called view, which does the same.
It creates an object of the ViewResult class. And in this case, the view name is automatically taken as
the current working action method name, that is index.
In case if you want to specifically mention other, you can specify optionally.
e.g.
return View("abc");
In case of : return View();
the view name will be taken as Index.cshtml

Rule is, all the views should be in the Views folder,
plus in a subfolder with the same name as the controller name.

That means the view is searched and expected to be inside the Views/Home/Index.cshtml
If you run application without this then you will get error."The View 'Index' was not found."
It will search it in :
/Views/Home/Index.cshtml or /Views/Shared/Index.cshtml

Lets create a Views folder in this project.
In Views right click and add new folder called "Home". Notice how we emitted the Controller postfix.
In this, add -> View -> Razor Views Empty ->  Index.cshtml in it. 
If you gave the different name then you need to add that name 
in View() method.
cshtml is the default file extension for all the views in ASP.NET Core.
Of course, in that case, that views are called as razor views.

And a view is basically HTML page.
So you can type your default HTML code.
Check that .cshtml file code.
Run the application and type url : http://localhost:5086/home

If you go into a network tab, and click on "Home" in "Name" tab.
Then in "Headers" tab, you will see content type is set to "text/html"
and in response you will see the html code which we have added in .cshtml
In the response you will see addition code lines which you have not added in the .cshtml file.
This is because :
Visual Studio has an advanced feature called browser link,
which refreshes the page as soon as you type something in the view at your development time.
That is for developer convenience. 
So because of that feature, this type of script tag gets added automatically.
It will not be in the production mode.
It is only for development mode.

So you can consider that the same content that we have written in the view
has been given as response to the browser.


*/
var builder = WebApplication.CreateBuilder(args);

// This time you have to add the controllers as well as views as services in the application.
// We are saying :
// Hey services, add all the controllers and also all the views at a time as services.
// So they will be instantiated whenever you send a request. 
// For example, if you send a request to the controller1, that controller1 class will be invoked.
// That means at runtime, it automatically creates an object of the controller class.
// In the same way, every view also gets compiled as a class internally.
// So whenever the view is invoked, that view related class will be instantiated.
// Means an object will be created for the view class.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers(); // Enabled the routing for controllers

app.Run();

