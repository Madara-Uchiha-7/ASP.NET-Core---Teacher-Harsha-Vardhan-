using Microsoft.AspNetCore.Mvc;

// When the file is created,
// we will have a predefined base class that is Controller i.e. Microsoft.AspNetCore.Mvccontroller
// Remove your generated class HomeController.
// Namespace is nothing but the name of the project.folderName
// We cam change it.
// 
namespace _51._Creating_Controllers.Controllers
{
    // Class name can be any. To make it a controller, you have to suffix it with "Controller"
    // Like we did after the word home.
    // This will be now automatically identified by ASP.NET Core application compiler.
    // Automatically that entire class becomes as a controller class.
    // So by default, it can receive the requests.
    // But after receiving the request, there should be a method, right?
    // So when the request is received, that method could execute.
    // So let's create a method.
    // The method return type anything.
    // But in general, you have to return IActionResult.
    // But we will talk about action results in further lectures in the same section.
    // For time being, you can return any type of value.
    // Can be a void, string or int or else anything.
    // Even though it is not preferred, it is possible.
    // For example, we are going to mention the return type as a string.
    // Now, we need to our class as a service class. 
    // So that it can participate in the dependency injection.
    // And the second one is, you require to enable the routing for this method.
    // So, in Program.cs, before you call .Build() method,
    // we can add a service classes.
    // Generally, a service class means a reusable class.
    // A class which performs a specific functionality, Without having direct relationship with UI.
    // In ASP.NET Core, the controllers are also treated as services.
    // Generally, in the larger projects, we create services for business logic. So that's a different matter.
    // We will learn about the architectures later.
    // But the fundamental point is the controllers also must be treated as services.
    // And you require to add all the services in this application builder.
    // So, we can use our builder object.
    // Lets add that in the Program.cs  (We added AddControllers and MapControllers)

    // The next step is to define the route template for your action method.
    // But what is the URL template for that?
    // You are required to define.
    // And you have to do it just above the method
    // as an attribute by using these square brackets. 
    // Since you are creating the route template as an attribute, this approach is called attribute routing.
    // Because just above the method within the attribute, you are writing your route template.
    // So route is an attribute. And you can supply the route template as argument.
    // Whenever the URL is sayhello, this particular action method executes.
    // It is as simple as for this URL, execute this action method.
    // But in order to enable the routing for controller action methods,
    // you are required to call map controllers.
    // And before then that, you are required to add the controllers as services which we already did,
    // so that internally ASP.NET Core can create object for the controller class whenever needed.
    // Means exactly at runtime, whenever the URL matches with this say hello, 
    // then automatically ASP.NET Core will create object for this home controller class 
    // because it has been added as a service by AddController();  statement. And then through that object,
    // method1 action method will be executed.

    // And also you are required to convert HomeController class as a public class.
    // Then only it can be instantiated by ASP.NET Core internally.

    // Run the application and add the url /sayhello
    public class HomeController
    {
        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method1";
        }
    }
}
