///
///
/// 
/// We Added basic starting lines using builder and app variables.
/// Then we created the wwwroot folder with stylesheet code. CSS code is of teacher's.
/// 
/// XUnit is one of the third-party packages for unit testing the controllers, services,
/// or any other classes in ASP.NET Core.
/// 
/// It is one of the most popular and most used unit testing framework.
/// 
/// Actually, you already have MSUnitTest, which is inbuilt provided by .NET.
/// But XUnit offers much more extensibility and easy and lesser learning curve
/// and it is well matched with the mocking framework called MOQ, M O Q.
/// 
/// The reason why XUnit is most popular in .NET unit testing is it is extensible.
/// So you can mould or extend the XUnit to any complex requirements.
/// 
/// Right click on the Solution.
/// Add a new Project.
/// Select language C#
/// And from 3rd dropdown select Select Test.
/// The in main window select XUnit Test Project.
/// 
/// Name it CRUDTests
/// Click on next. Make sure the version is same as your application.
/// Then Create.
/// 
/// So it has created a new test project along with the dependencies with importantly two packages.
/// One is XUnit package itself and also XUnitRunner.VisualStudio. You can see them in packages of that project's Dependencies.
/// 
/// 
/// These two packages are required for writing and executing the XUnit test cases.
/// 
/// ASP.NET Core fundamentally implements a pattern called clean separation of concerns.
/// So in that way, almost everything is independently unit testable in ASP.NET Core.
/// 
/// We will have a sample file called UnitTest1.cs.
/// It has a method with attribute [Fact] 
/// How can you say it's a test method? :-> The test methods are decorated with the attribute called fact.
/// That means this method is going to be unit testing.
/// That means you are going to write one or more unit tests within this method.
/// 
/// And there are three steps for every unit test.
/// Arrange, Act, and Assert.
/// 
/// 
/// Arrange means the declaration of variables and collecting the inputs.
/// Act means calling the method. Which method you would like to test?
/// And the meaning of Assert is comparing the expected value with actual value.
/// If expected value and actual value both are same,
/// then the test case is pass, otherwise fail.
/// 
/// Lets create a sample class.
/// In CRUDTests project.
/// Since it is the demo project, we are going to add the class within the same project i.e. CRUDTests.
/// 
/// Generally, it would be a part of the other class library such as services.
/// So just for demo purpose, let's add the service class within the same CRUDTests project.
/// 
/// We added "MyMath.cs"
/// 
/// We added a method in it called "Add()"
/// 
/// Then we come back to our UnitTest1.cs
/// Check the code and comments.
/// 
/// Now
/// goto View -> Test Explorer -> You can move the window which will open after by clickin on Test Explorer.
/// I have kept that window under solution explorer.
/// 
/// It will automatically show our project which we are going to test.
/// 
/// Expant it till you see our class name which is going to be our Unit test class in which 
/// we are doing "Arrange, Act, and Assert."
/// 
/// Expand it also and it will have our unit test method.
/// 
/// If you see exclamation mark on it, it means it did not run at least once.
/// 
/// Select it click on green play/run symbol which says Run All Tests in View
/// 
/// It will call Test1 method in this UnitTest1 class.
/// 
/// For every possible input, you will be creating one unit test.
/// 
/// If you supply some argument values where there is a possibility of exception,
/// then that is implemented as another unit test.
/// Like this, for each possible input, you will create one unit test.
/// In this way, you will ensure that all the methods work correctly in all types of inputs
/// and it is extremely useful when the application scale increases.
/// 
/// 
/// 
///


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
