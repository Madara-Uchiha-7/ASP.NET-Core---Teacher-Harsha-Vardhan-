/*
Let us actually create this persons/index.

It displays the list of persons in the table format, which is also called as grid format.

To get to the list of persons, already in the persons service, we have created a method called
getAllPersons and it is implemented in the persons service.

So we are going to inject the IPersons service into the controller.
At runtime, it has to instantiate the persons service.
Through this interface variable, we can call this getAllPersons
to fetch the data from datastore.

In CRUD,
add your persons service into the ioc container:
builder.Services.AddScoped<ICountryService, CountriesService>();
In <>, we have to give,
the interface type, and then the concrete implementation of the same.

Then in PersonsController, Create a private field to hold the reference of the PersonService:
private readonly IPersonService _personService;
Then create a constructor, so that it can receive the object created by IOC container.

Then we use _personService in out Index action method and will pass PersonResponse to the 
Person's Index View.
We also made this view as a strongly typed view:
@model IEnumerable<PersonResponse>﻿

Even though it is of list of person model,
it is recommended to make it as IEnumerable.
Because IEnumerable is the parent of list.
in future, even though you supply a different type of collection,
that will be automatically honored here
because most of the collections are children of IEnumerable type.

In index.cshtml we added :
@person.DateOfBirth?.ToString("dd MMM yyyy")

"?" will access the ToString only when Date of birth is not null. It is very important.

.ToString("dd MMM yyyy") will allow us to format the date as we want.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
