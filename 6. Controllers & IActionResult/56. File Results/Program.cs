// Sometimes when you open some webpages, it gives you a file as download.
// Maybe for example, you are trying to download a software from internet. Otherwise, you are opening some coarse
// material as PDF file or even a movie..etc. So, in all these cases, there is a requirement of server gives
// the file to the browser. So, what if you would like to do the same in your own application?
// Then you will use this file result. In that case, the file content will be the response body and
// the type of the content of the file will be the content type. For example, text by plain, text
// by HTML or application by PDF or the content type depending on the type of the file.
// You have three types of file results.
// Virtual file result, physical file result and file content result. Lets see when to use which one.
// Lets check the controller actions. I am ending those action names with File. It is not the convesion.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
