/*
In this lecture We are going to write the Unit test case for GetPersonByPersonID.

Lets add this method in IPersonService_Copy.cs
Check the code and comments.

Then in PersonService_Copy, we have added GetPersonByPersonID method for class PersonService_Copy,
because it implements the IPersonService_Copy interface.
For now we have not added the implementation, we will be doing it in the future lectures.

Check the code and comments.

Goto PublicServiceTest_Copy.cs
Check the code and comments.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
