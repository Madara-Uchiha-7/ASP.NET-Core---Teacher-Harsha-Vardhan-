// In last section lecture we created one endpoint for each URL. 
// and we are writing the corresponding code in the same middleware.
// But think of real-world projects. Can you follow this existing approach in the real-world projects?
// That means you will be having thousands of URLs with corresponding large amount of code,
// writing all the endpoints in the same file.

// So, There is a concept of grouping the middlewares based on the logical purpose.
// And that is exactly the controllers.

// A controller is a class that contains a set of action methods.
// In this case, each action method acts as an endpoint, which can be requested based on a specific URL.
// For example, if you send a request to URL1, the action 1 will execute,
// and for url 2, action 2 will be executed.
// So these actions are grouped up into a controller class. 
// That means there should be some logical connection between action 1 and action 2.
// For example, let's say action 1 represents the user registration process,
// action 2 represents the sign-in process.
// So both of these are related to user account maintenance, right?
// So that is the logical connection between them.
// Each action performs a specific operation based on the inputs that are supplied to it.
// For example, if you supply username, password, confirm password, date of birth, etc. details,
// the first action method creates a registration process,
// and the second one may be for login process based on the email and password.

// This is ASP.NET Core empty project. Like always.
// We create a folder with name Controllers which is a convension, we create it in the project.
// Because we want to place the controller classes inside of that.
// Alternatively, you can create a folder with any other different name.
// Right click on contoller, select Add->Controller. If this option is not available, then go for 
// Add -> New Item->MVC Contoller - Empty.
// For me I have a option called Controller.
// So, Add->Controller->(Installed(Common(MVC)))Controller->select Controller with MVC Controller empty.
// The other two options will generate some sample code automatically, which may work for demo projects,
// but not for real world projects.
// Give the name HomeController.cs
// Go to that file now. 



using _51._Creating_Controllers.Controllers;

var builder = WebApplication.CreateBuilder(args);

// In the larger projects, you might be having so many controllers.
// Hundreds of or thousands of controllers. For example, one controller for user account maintenance.
// One more for products maintenance. And like that, you will be having lots of controllers.
// Generally, one controller for one database table. 
// So instead of manually adding each controller like this with this AddTransient method:
// builder.Services.AddTransient<HomeController>
// The shortcut way is AddControllers()
// So ASP.NET Core automatically detects what are the controllers present in the application.
// That means what are all the classes that are suffixed with the word controller.
// And it will collect all of those controllers and adds all of them at a time by using this addControllers method.
builder.Services.AddControllers();

var app = builder.Build();


// So after adding your controller classes as services,
// the second step is to enable the routing.
// But if you need to repeat the same statement for each action method of all the controllers,
// it's really insane. So to overcome this problem, in ASP.NET Core,
// we have mapControllers method:
app.MapControllers();
// It will detect all the controllers of your entire project.
// And it will pick up all the action methods.
// And for all the action methods, the routing will be added at a time by this single statement.
// The next step is to define the route template for your action method.


// We added comment to below line because it is not required.
// app.MapGet("/", () => "Hello World!");

// Below is needed to start the application.
app.Run();
