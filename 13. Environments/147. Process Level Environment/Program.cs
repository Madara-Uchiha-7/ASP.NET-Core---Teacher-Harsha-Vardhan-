/*
Remember that this launchSettings.json file is only for developer machine.
In case of staging server or production server,
you will not deploy this launchSettings.json file.
Then, here the question is, in other than development machine,
maybe in the staging server or in the production server,
how can you set these environment variables, 
particularly how do you set this ASP.NET Core environment
on other than developer machine.
That's exactly we will learn in this lecture.


Imagine that you are going to run your ASP.NET Core application
other than in development machine.
There, you have already installed .NET.
That means the framework is available on that staging server or production server,
but the Visual Studio will not be available on those servers.

In that case, you have to deploy the application in a specific folder
and you have to start running your application through command prompt,
maybe through Windows PowerShell.

In that case, exactly, there is a possibility of setting up the environment variables
through the command prompt window itself.

So, you will write a command in the command prompt or in the Windows PowerShell
to set up the environment variable.
Then, you will start the application by using .NET run command.

Let me show that practically.

Assume that current machine is staging/production environment.
We have the compiled source code with you,
but you don't have this launch settings.json.
In that case, you have to open an inbuilt Windows application called Terminal.
Press Windows key and type Terminal.
Open the Application which is called Terminal.
Once open, on top it should have the text "Windows Powershell"

Now, in this powershell, go to the folder where application is available.
Goto the folder in which your project is present.
You need to go inside the project folder where your program.cs is present.
You can also find the path using VisualStudio,
right click on the project and click on Open with Visual Studio.

Run:
dotnet run --no-launch-profile

This way, The URLs and environment variables that are set in the launch settings were not loaded.
Because you mentioned that no launch profile.
That means it disables the launchprofile.json file.
Now ASP.NET Core by default takes the environment as production.

For staging or custom environment:
$Evn:ASPNETCORE_ENVIRONMENT="Staging"

Press Enter. This will save the environment variable.

So this will be equivalent to setting up the environment variables.
But this will be saved only for the same command prompt.
That means the same PowerShell tab.
In case if you open up a different tab,
the environment variables of the other tab cannot be read from this.
So it is secured.

Now you can use the same command:
dotnet run --no-launch-profile

Since we mentioned the environment variable,
then this environment variable will be respected.
instead of the default that is production.

If you are using another command prompt, then do :
set ASPNETCORE_ENVIRONMENT="Staging"

ASPNETCORE_ENVIRONMENT is the key which we use to set the environment in the .json also.


*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
