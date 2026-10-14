/*

In this lecture, we are going to focus on how can you configure the environment name
in LaunchSettings.json file. By default, when you create a new ASP.NET Core web application,
it automatically creates a file called LaunchSettings.json.

So it contains the runtime profiles of the application,
so that either of them will be used for running the application.
We have already seen them in the beginning of the course.
But the point today is, we can configure the current environment name
under this environment variables property. Let me show that.


We added :
builder.Services.AddControllersWithViews();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

in this file.
Created the folder called wwwroot.
In that we created the css file and the code is added form  the teacher github.

Now in Properties folder, open json:

"profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5254",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7177;http://localhost:5254",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }

It has 3 profiles, One is for Kestrel server and other one is for IIS Express.
We have already discussed about the difference in the beginning lectures itself.
(Note: While creating the project I selected the Configure For Https option.
Thats why here, there are 3 profiles. Other wise it whould have been only 2.
And there would ben no https here.)

But the point is you can add one or more environment variables.
Particularly with a predefined name called ASPNETCORE_ENVIRONMENT

So you can configure the environment individually for every runtime profile.
That is for Kestrel server as well as IIS Express server.


By default, when you create new project, the environment is set as development.
But you can configure the same such as staging, production
or any other custom name whatever you want.


For example, let's say I would like to change the current working environment as staging.
Then you can simply change it here:

"http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5254",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Staging"
      }
    },

Now our application works with staging environment.
Since we are using Kestrel server.

Lets add a controller and a [Route("/")] inside it.
Right click on index method and select add view. Razor view empty.
View name will be same as the action name.

Lets add some default code inside it.

Lets add the layout view as well.
Right click on Views folder and add a new folder called: Shared
Add Razor Component in it -> Rezor layout -> Name : _Layout.cshtml

Add some code in it.

Lets apply the layout view for the view.

Right click on Views folder and add Razor Component -> Razor View Start -> _ViewStart.cshtml

Run the application ..it should run.

Changing the environment name doesn't make any difference in the output
or in the code execution order.
Then what will be the difference with this environment name?


Particularly in the program.cs file, you can check
if the current environment is developer,
you can enable the developer exception page.
But alternatively, in case if the current environment is production,
you can enable the custom error page,
which is user-friendly but not developer-friendly.

Means the developer error page may show the exception details,
which is useful for coding purposes.
And in case of production environment,
the exception page should show the minimum details to the user
hiding the code or application-specific details.

So in order to identify the current system,
the environment name will be useful for you.
That's the all purpose behind it.

So that We added :
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

Cause the error forcefully. In home controller add another action method again.
And add same route for both action methods which should not happen.

Run the code and you will get some big errors.

Now if you make your environment staging then you will not see this page.
In this case, i.e. if environment is staging then go to network tab,
you will see error 500. The response tab will also be empty in this case
And that is what the effect of environment.
So that is the reason,
at runtime, the users does not get
any developer-related exception details.

I have commented the action method which we added to see the error.

We have added environment name in:
ASPNETCORE_ENVIRONMENT
we can do same in 
DOTNET_ENVIRONMENT

But if you mention both, 2nd one will be used because it will override the before one.

Use ASPNETCORE_ENVIRONMENT in case of asp.net core applications.


The Environment in app.Environment.IsDevelopment() 
is returned as a type called IWebHostEnvironment.
It is one of the predefined services.

So using this IWebHostEnvironment object,
you can call the methods which we did.

It has a property called EnvironmentName which returns the current working environment.
and also it has a property called contentRootPath 
which returns the current working absolute path of the current working application folder.
By default, it is equivalent to the project location.

It has also method called IsProduction()

It has also a method called IsEnvironment(string envName) 
which is for other specific environment name which is the user defined name
which you have created yourself. 


*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// If you want UseDeveloperExceptionPage for staging also then you can do:
// app.Environment.IsDevelopment() || app.Environment.IsStaging()
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
