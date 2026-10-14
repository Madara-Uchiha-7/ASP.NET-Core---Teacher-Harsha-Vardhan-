/*
We will be implementing the Add Person here.
Goto  the PersonService.cs
and check the code and comments.

The actual practical problem that you face is
whenever there are too many fields such as personName, phoneNumber,
email, securityCode, etc.
For each field, you may have a lot of validation roles.
Writing the if statements for each validation makes it cumbersome and lengthy process.
But instead of writing these simple if statements for validation,
you can use the model level validations that we have learned in the last lectures.
There was a separate section called model validations with model binding.
We have already experienced how the model validations defined,
how they work, and how do you apply the custom validations too.
We can really use that knowledge of model validations.
That means we can validate the domain models also
with that model validations concept.

We will be doing this in next lecture.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
