/*

Similar to the last lecture we are going to update the PersonServiceTest.

Once after every change is done, rebuild the solution.
You will see no errors, but if you run the test cases, then these test cases will fail.

It's because we cannot use the regular entity framework with SQL server for unit test.
We should require to enable another database mechanism
as alternative for the unit test.
We will exactly do that in the next section.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
