/*
In the previous lecture, we have created GetAllPersons_AddFewPersons() unit test for the
get-all persons. But there is a small problem here. Let us find the solution for that problem.
Here the problem is, whenever the test case is passed, it will not show any actual value or
expected value when you click on successfull unit test in the test explorer.

But when you want to see the expected or actual values when the
test case is passed or failed, you can use a predefined service called ITestOutputHelper.
It is similar to Console.WriteLine();

ITestOutputHelper is present in "Xunit.Abstractions";

Check the code and comments in PersonServiceTest_Copy.


In PersonResponse.cs we are overriding the method called ToString()

This method will help us to see the class details which we are printing using ITestOutputHelper.

Run the tests and check the data by clicking on the GetAllPersons_AddFewPersons test in Test Explorer.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
