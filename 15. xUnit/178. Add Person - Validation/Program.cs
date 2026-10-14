/*
In the AddPerson method of the PersonsService, here we are writing the validation code for PersonName.
But this if condition handles only one validation requirement.
But in real-world projects, in the domain model, if we have too many number of properties,
and each property may have multiple validation rules, such as required rule, range validation,
minimum, maximum, etc., writing individual if statements for each validation requirement
is cumbersome and lengthy and error-prone.

Exactly for this requirement only, model validations concept is introduced, right?
That means we can use data annotations as alternative to the simple if statements for
validation. Let's try that in this lecture.

I am creating the copy of PersonService.cs.
The name of the copy is:
PersonService_Copy.cs

So, what model class should be validated in PersonService_Copy.cs?
That is, we are validating this PersonAddRequest model.
We know this from the method Parameter of AddPerson method.
Its parameter type is PersonAddRequest.

I am creating the copy of PersonAddRequest.cs as PersonAddRequest_Copy.cs
In this PersonAddRequest_Copy, add data annotations for each property which you want to validate.
For annotations we have also imported the library in that file.
Check the code and comments in it.

And now, how do you validate these data annotations programmatically in the service?
Check the code and comments in "PersonService_Copy"


To test this, I am creating the "PersonsServiceTest_Copy.cs". This is the copy of PersonServiceTest 
Check the comments and code from it.
Also created IPersonService_Copy.

Run the tests to check the working.



*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
