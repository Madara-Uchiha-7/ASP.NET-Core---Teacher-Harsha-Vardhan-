///
/// Create a new Project in VS.
/// Select C-Sharp in the Language drop-down list,
/// and in the third drop-down list in the Project Types, select Web.

/// The one that you have to really choose is ASP.NET Core-Empty.
/// You may also create application with ASP.NET Core web application,
/// but the problem is, by default it will create lot of files such as controllers, models, views, etc.,
/// which are unnecessary for both learning and real-world project development purpose as well.
/// It may be okay for showing the quick demo,
/// but it is not really good for real-world project development.

/// That is why always, both for learning and real-world project development purpose,
/// ASP.NET Core-Empty is better.
/// Click next.
/// We don't require to enable HTTPS at the beginning, at the very first application.
/// So untick it.

/// Click on create.
/// 
/// Now, open up your solution explorer. It will be on the right side tab.
/// And in here, you will be able to see all the list of projects and its files
/// of your current working solution.
/// 
/// See, it has only one C-sharp file.
/// That is Program.cs.
/// That is the entry point of the application.
/// That means the execution starts from Program.cs file.
/// 
/// We are on this file right now.
/// 
/// This is the four line of code at the start
/// These are the top level statements which are supported by C-sharp 9
/// That means your code doesn't require the static void main in C-sharp 9
/// You can straight away write any piece of the code that will be eventually compiled into a main method internally by the compiler itself.
/// OK, optionally, if you want, you can write a static void main:
/// 

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

///
/// The first statement that you can see here is createBuilder.
/// This will create a builder for web application.
/// And that is called WebApplicationBuilder.
/// So what this builder can do?
/// A WebApplicationBuilder loads the configuration, environment and default services.
/// But in brief, environment is your environment settings.
/// For example, API URLs or server names.
/// And configuration is your configuration settings such as connection strings, etc.
/// And services are your application services, both predefined and user-defined services.
/// 
/// So once the createBuilder is called, you will get an instance of WebApplicationBuilder.
/// Using builder variable, you can access the configuration as well as services.
/// Using code: 
// builder.Configuration. ;
// builder.Services. ;
// builder.Environment. ;
/// 
/// And then after configuring your builder, you require to call the build.
/// As a result of the build method, you will get an instance of WebApplication,
/// which is also referred by a variable called app.
/// So this app is a variable that refers to an instance of WebApplication object.
/// And through this app, you will be able to configure the middlewares of your application.
/// 
/// 
/// app.MapGet("/", () => "Hello World!"); 
/// It is saying that whenever we have received the request at the local host some port number,
/// then the response should be Hello World.
/// 
/// 
/// Of course, we have to call the run method in order to start the server.
/// In case if you don't call this run method, the server would not be started.
/// 
/// Run this project.
/// 
/// It starts the server internally.
/// That is Kestrel server and automatically opens up the browser
/// and runs the URL that is localhost some random port number here.
/// 
///