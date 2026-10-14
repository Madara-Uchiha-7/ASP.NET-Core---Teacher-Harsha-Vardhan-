var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

///
///
/// The further four sections are going to be extremely hands-on.
/// We are going to create a web application with CRUD operations,
/// where you will implement create, retrieve, update, and delete operations practically.
/// At first, we will try to create unit tests and create the views and controllers,
/// and then we will integrate the same application with the database using Entity Framework.
/// In this way, we will have a chance to test all the knowledge that we gained from the
/// beginning of the course. 
/// 
/// We are going to implement the unit test functionality.
/// Because according to the test-driven development,
/// it will be good if we can create the unit test first before implementing any functionality.
/// And we are going to implement unit tests by using XUnit package.
/// We will get started with XUnit in the next lecture.
/// 
/// 
///