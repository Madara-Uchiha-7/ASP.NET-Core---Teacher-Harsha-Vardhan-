///
/// We now know that we can use reverse proxy server called IIS express.
/// To enable it, 
/// Goto 
/// Properties -> launchSettings.json
/// Open it.
/// There are 3 profiles.
/// http, https and IIS Express
/// I think https is there because we tick the box of https while creating the project.
/// If we look at https (because we tick the box of https while creating the project, whenever
/// I am running this project it is using the url https://localhost:7218 which is mentioned in the https.)
/// there is a url which will be used when we run this project.
/// There are many key value pairs in the https. These are nothing but a configuration settings for our current project.
/// We can change the name of the key https to Kestrel, because we know that we are using the kestrel server for this link.
/// Or you can name : MyProjectName.Kestrel
/// This name will be shown green run button on the toolbar which is on the top.
/// If you click the dropdown there, you will other profile names too which are in the launchSettings.json
///
/// Now lets go through the key value pair inside the https profile.
// "commandName": "Project"
/// The first setting is commandName and its value is Project. That means we are enabling the kestrel server.
/// 
// "dotnetRunMessages": true,
/// There is dotnet CLI that is dotnet and then some commands.
/// For example you can create the application and add the files etc by using dotnet api. means you can use the
/// dotnet commands on the terminal just like angular cli in case of angular framework.
/// In case if you run any dotnet command, you would like to show relevant messages or updates in the kestrel in the
/// terminal. If you want to do that you will enable the same by using true otherwise false.
/// That means while the kestrel server is up and running and if somebody has used dot net commands somewhere in the terminal
/// the relevant messages will be shown in the kestrel window.
/// 
// "launchBrowser": true,
/// If true, when you try to use that kestrel automatically the browser gets opened.
/// Default browser in the windows will be used.
/// 
// "applicationUrl": "https://localhost:7218;http://localhost:5006",
/// localhost is the server name. This indicates the local machine.
/// Then :7218 is the port number.
/// You have created thousands of applications in the same machine, there should be a different
/// identification numbers for each project, so port number is used.
/// This number is randomly generated when you create the project in VS.
/// You can change this number to any number you want which is greater than 1024 and less than 65536.
/// because all the port numbers that are less than 1024 or reserved by the windows operating system.
/// 
// "environmentVariables": {
//     "ASPNETCORE_ENVIRONMENT": "Development"
// }
/// The environment variables are the artifacts that contains the global values that are available across the entire application.
/// You can choose the environment to run the application either of development production or staging or you can enable any environment
/// variables such as api keys or server names or redirectional urls etc. which are global and common that can be
/// accessible anywhere in the code.
/// 
/// These are the default settings that are available in your kestrel server.
/// 
/// If you want to use IIS express that we know that there is another profile in the same file,
/// from dropdown on the button using which you run the code, select ISS Express.
/// This profile can also be changed.
/// 
// "commandName": "IISExpress",
/// The command name is the fixed name that is IISExpress.
/// So there are two options for command name.
/// the command name: Project means it is the kestrel and
/// the command name: IISExpress means it IIS express itself.
/// 
/// IIS: internet information services
/// 
/// As a continuation of this IISExpress profile
/// you have additional settings here for the same IIS express.
// "iisSettings": {
//     "windowsAuthentication": false,
//     "anonymousAuthentication": true,
//     "iisExpress": {
//         "applicationUrl": "http://localhost:28902",
//         "sslPort": 44338
//     }
//   },
/// 
/// windowsAuthentication : IISExpress can support windows authentication.
/// 
/// "applicationUrl": "http://localhost:28902", 
/// This is the port number for IISExpress.
/// 
/// You can enable to SSL that is https protocol by changing the port number at "sslPort": 44338
/// Check more about sslPort and anonymousAuthentication on net.
/// 
/// What are the benefits of IIS express.
/// IIS express is the lightweight version of the actual server that is IIS.
/// Both IIS express and IIS also support additional features which are not supported by kestrel.
/// For example http access logs, port sharing, windows authentication, process activation, configuration api etc.
/// 
/// In most of the real word cases as per the teacher knows 
/// the developers prefer linux over windows for servers.
/// So in case of linux you can use any one such as nginx or apache of course nginx is one of the most popular for reverse proxy.
/// So there most of the features that are supported by IIS are actually available in nginx or equivalent.
/// 
/// 
///


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
