/*
An ASP.Net core web application may contain static files or static content such as images, text files,
PDF files, and JavaScript files, CSS files, etc. generally, while working with views, you require
to use all these type of files, but by default these files cannot be served by ASP.Net core.

You require to enable it by using Use Static Files middleware, which enables the ASP.Net core application
to serve the static files if the URL contains the file path.

For example, we have send a request to sample.jpg and if that file exists in the application, we have to
serve it as response to the browser so that the browser can receive that file content and display the
same in the page.
So in order to serve the static files such as images and text files, etc., you are required
to enable UseStaticFiles().

By default, ASP.Net core recommends you to place all the static files, such as images and JavaScript
files, in the web root folder, and the default name of the web root folder is wwwroot.
It is not a fixed name you can configure means you can change it.
You can even enable multiple wwwroot folders also.

The whole idea of this application is to serve the static files based on the incoming URL.
But the practical use of this is with views only.
We are going to learn how to create the views later.

Create a folder called
wwwroot
It is the default preferred name as per the convention, but it is not a fixed name.
By default it will be having an icon of the web icon.
It is just a convention in Visual Studio to apply the icon.
In case if you create a folder with a different name, this icon will not be applied.

Copy some 2-3 files and keep it in this folder.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lets unable the wwwroot folder.
// This is the predefined middleware.
// Any of the files and subdirectories of this wwwroot should be directly accessible through browser requests.
// Actually, in earlier versions of ASP.Net, by default, all the files that are present in the entire
// project are accessible through browser by mentioning the appropriate file path.
// But over the time, what happens is it offers less security because some of the malicious sites can
// access the code files of your application, it may contain sensitive code or sensitive information.
// To avoid that, ASP.Net core recommends you to create a wwwroot folder that can contain the static files
// so it offers better security because only the contents of this wwwroot is accessible through the browser,
// but not any other files that are present in the main or root directory of your application.
// The meaning of use static files is that if the request URL contains a specific file path, for example
// /Anime.jpg then since this file exists in the wwwroot folder, automatically the file content will be given.
// Try it.
// 
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();

// In case if the file is not present in the root folder but present outside of it, then that file
// should not be accessible.

// If you want to change the folder name from wwwroot to something else then
// you need to configure the new name in Web Application Builder.
// Instead of:
// var builder = WebApplication.CreateBuilder(args);
//  You will have to write
/*
var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{ WebRootPath = "nameOtherThan_wwwroot_WhichYouWantToGive"});
*/
// Using WebApplicationOptions
// you can configure some of the default settings.

// Note even if you want to use your custom name instead of wwwroot,
// you still need to create the folder with name wwwroot.
// Because if this folder is not present it shows exception while calling this create builder.

// Can we configure more than one folder.
// Yes, it is possible there is an alternative way.
// To make it possible,
// you need to make one more call to UseStaticFiles()

// Lets take the e.g.
// If the names you want to use are
// WebFilesJs and WebFilesCSS
// Then code will will become:

/*

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{ WebRootPath = "WebFilesJs"});

app.UseStaticFiles();  // This will work for "WebFilesJs"

app.UseStaticFiles(new StaticFileOptions() 
{
    FileProvider = new PhysicalFileProvider(
        builder.Environment.ContentRootPath + @"\WebFilesCSS"
    )
}); 
// This class PhysicalFileProvider exists in a namespace that is Microsoft.Extensions.FileProviders;
// builder.Environment.ContentRootPath will by default represent
// the current working folder path.
// In our case it will be :
// D:\Code\Udemy\ASP .NET Core - Harsha Vardhan\5. Routing [MVC and Web API]\48. WebRoot and UseStaticFiles
// So we are using concatination.   
// And instead of concatenation you can also write this as 
// Path.Combine(builder.Environment.ContentRootPath, @"\WebFilesCSS")

Files will be first checked in 
WebFilesJs
then will be checked in
WebFilesCSS
*/