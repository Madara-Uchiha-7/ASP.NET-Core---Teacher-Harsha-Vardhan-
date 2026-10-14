// In ASP.NET Core, it is recommended to mention the return type of all the action methods as
// IActionResult. In this case, you can return any type of action result,
// such as ContentResult, JSONResult, FileResult, etc.
// Because the IActionResult is the parent interface for all the action results in ASP.NET Core.
// That is ContentResult, JSONResult, RedirectResult, FileResult. All these are children of IActionResult interface.
// In other words, all these action result classes implement that interface.
// Lets see its benefit practically with an example.
// Let's say we want to create an application where the URL is "book" and the user must be logged in.
// and also the user should supply the book id as query string parameter. 
// That means isLoggedIN must be true in this query string parameter
// And assume the validation is the book id should be between 1 to 1000.
// So this is our requirement. The book id should be a positive number
// and IsLoggedIN must be true. In case of invalid values supplied,
// then the application has to return appropriate error message.
// Let us see how does the IActionResult helps us to solve this problem.
// Go to controller class.
// Read and understand.
// Run the app and add "/book" in the url check the error.
// Try below:
// Use "/book?bookid=0
// Use "/book?bookid=1001
// Use "/book?bookid=10&isLoggedIn=false
// Use "/book?bookid=0&isLoggedIn=true     -> This should work but will not return anything because I have not added the sample.pdf

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
