/*
We will be writing the service for the Person.

In Entities Project 
create a class called Person.
This is our domain model class.
Create a file called Person in this Project.

Check the code and comments in it.

Right click on the ServiceContracts project,
create a new folder,
give it a name -> Enums
In this "Enums" add a class called -> GenderOptions
We changed the class into Enum.
Check the code and commetns in it.

Now lets create a DTO (Data Transfer Objects)
PersonAddRequset  
We know that DTO acts as common data objects between the controller and the service.

In our DTO folder, create a class with name "PersonAddRequset"

Check the code and comments in this class.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
