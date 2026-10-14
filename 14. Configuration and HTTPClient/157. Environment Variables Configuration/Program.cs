/*
Last lecture's secret manager, we can not use with Production.
Because on the production server, you are not going to have the visual studio
or any other development related tools. You only have access to the terminal. So,
from your terminal window, you have to invoke your application on the production server.
In that case, you can store your sensitive data in the configuration as environment variables
in the production server. Because the environment variables that you set in the terminal window
are accessible within the same terminal window, but not from other terminal windows on the same
machine. In that way, it is one of the secured ways to store the configuration settings within
the environment variables. For this case, you have to use your regular windows PowerShell
or you can use developer PowerShell in Visual Studio.

So, in either of these windows, you can enter below commands :
$Env:ParentKey__ChildKey="Value"
dotnet run --no-launch-profile

$Env means environment.

Your key value pairs environment variables are not accessible from other PowerShell windows
even on the same machine. That is why these environment variables are called as process
level environments. Alternatively, you can also set environment variables on the control panel
through machine level settings. 
But this is better way.

*Make sure that you run that key value pair command from the inside of the Solution Folder. I.e. the folder
in which your Solution is present*

You can run your application regularly by using the normal command:dotnet run --no-launch-profile
"--no-launch-profile" flag disables the launch profile file.
So, it doesn't load the environment variables from the launch settings.json file. Now, run this.

*Make sure you run above command inside the project folder*
This will run the application/project and will give us the URL.
You can copy paste it into the browser.

You will see that the key value pair values will be loaded from environment variables instead of loading it from the local 
configuration files.

I have not addded the same code as last projects. But the code will work fine once you add it.


To update the value of same key 
use same $Env command.

So, when you want to run the application other than the development environment,
maybe for production server or staging environment,
you can set your configuration settings as environment variables as we have done in this lecture.

*/


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
