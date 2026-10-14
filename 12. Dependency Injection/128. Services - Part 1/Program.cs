/*

Well, exactly you have to write your business logic, either in the controller or view.
Neither of them.
The business logic should be in the service, that is also called as business model.

First, can you define what is the exact meaning of business logic?
It includes with business calculations, business validations, and invoking the data layer.
So, the logic which is related to the specific domain of the actual client business, 
that is called business logic.


For example, let's say you are developing an insurance web application.
Calculation of the premium amount for the insurance policies.
Otherwise calculating the amounts of the claims.
So, that is the actual core logic to perform the calculations.
And also you may have some conditions, like for example, 
It also includes with invoking the data layer.

The data layer is a separate layer or separate class, but you have to call it as a part of the service.
For example, in a simple web application, there is a registration form.
The user has entered the username, password, email address, all the essential details.
Then, when the user clicks on the submit button in the page in the browser,
the browser makes a POST request to the controller action method.
Then, the controller invokes or calls the service class.
So there, you will perform the actual calculations, such as calculation of the age 
based on the date of birth.
And generating the new ID for the new user.
And also checking whether the date of birth is eligible or not.
Otherwise, the phone number and email address are valid or not.
Once all this process is completed, then you will invoke the actual data layer in 
order to store the registration details in the database.

So, you are not supposed to write database related logic in the business model.
But, in between the presentation layer and data layer, whichever the process you would like to perform,
which is specific to the domain of the client business, that is called business logic.
And you will place the same in the service class.

So, by definition, the service is an abstraction layer between the data layer or domain to the presentation layer.

So, on the bottom side of the service, you have the data access or the actual domain, 
that means actual data access logic.
But, on the top of the business layer, you have the presentation layer, 
which includes with the controller, view and corresponding model.
In case if you write the business logic directly in the controller, it's a bad practice because
it will be quite difficult to test the controller.
And controller eventually contains huge amount of code, which is difficult to understand and difficult to debug.
And even difficult to share among multiple developers.
So, you should never write your business logic in the controller, but instead a separate class.
That is called service class.

So, if you write the business logic as a separate class as a service, it will be easy to unit test the same.
Means, independently a separate team can write the business logic.
And the same team can unit test their own code without involving anything in the presentation layer.
And always the business logic is invoked from the controller.

Lets start with an example:
Here the scenario is, at the time of opening or loading the view,
we have to display a list of cities that are retrieved from the business logic.
So, we are creating a new ASP.NET Core empty application.
In Program.cs
we add a controllers and views as services so that they can participate in the dependency injection:
builder.Services.AddControllersWithViews();
Now, enable the static files in order to serve the static content, such as images or CSS files:
app.UseStaticFiles();
Then enable the routing:
app.UseRouting();
Map all the controllers, So, we enable the routing for all the controllers:
app.MapControllers();
That's all. This is the common regular piece of the code that is present in every application.


Now, exactly always, you have to build the application from bottom to up.
That is, the service first, then only the controller.
Then, First controller and then view Or first view and then controller.
Or both in parallel by different teams or different persons. But the service should be come first.


Now,
Either you can place the service class within the same web application.
Or you can separate the same into a separate class library.
The second choice is better because a separate team can independently work with the services
in case if you place it in a separate class library.
In case if it is a part of the web application, architecture-wise, it's not good.
Because you are tightly coupling the service with the web application.
So that if you want in future, it will be difficult to reuse the same service class
in another web application or another client application such as mobile application.
So, always it's a good idea to separate the service into a new class library.
That is also developed with .NET Core.
So, in order to add a class library project to the same solution,
right-click on the solution,
add new project.
Here, select the language carefully C-sharp.
And then in the third drop-down list, select library.
So, now select the first option class library.
Make sure you have not selected class library .NET Framework.
Because .NET Framework class library cannot be referenced by ASP.NET Core.
So, select the first class library,
which says a project for creating the class library that targets .NET or .NET Standard.
Okay, anyways, we are using just .NET.
That means internally it is .NET Core.
Lets name it:
Services.
This name can be anything.
And carefully select exactly the same .NET version,
which was used while creating the ASP.NET Core application.
In case if it is different, you may get problems while adding the reference.
And then create.


Now, as usual, the class library project has been created.
So, any classes that are created in these services
can be referenced by the ASP.NET Core application.
By default, there is a file called class1.cs file.
We can rename the same:
CitiesService
Naming convension should be like this only:
e.g. For another example, CitiesService, EmployeesService, StudentsService.
I.e. a table name suffixed with the word service.

Lets add a bussiness logic in this class.


 */

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
