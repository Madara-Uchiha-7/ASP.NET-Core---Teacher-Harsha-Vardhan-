/*
Assume that a developer has written an Entity Framework linq query or called the SaveChanges
method. How does it work internally in background? Exactly the linq query that you write will be
supplied to the Entity Framework Core Database Provider, either it is SQL Server or SQLite or
MySQL, whichever the database that you are using. An Entity Framework Core Database Provider acts
as a mediator between your data access layer code and the database. So, for example,
if you are using Microsoft.EntityFrameworkCore.SQLServer as database provider,
it converts your linq query into equivalent SQL statement that works well with the SQL server.
In case of SaveChanges method, it generates either Insert, Update or Delete statement
but in case of linq query, it will generate the SELECT statement.

Once the operation is done, in case of non-query operations such as Insert, Update, Delete,
it returns the number of rows affected. For example, if one row is inserted, it returns
a number like 1. Otherwise, if two rows is updated, it returns the number 2.

But in case of SELECT, it returns all the data and that is called ResultSet.
So, the ResultSet is the list of rows that was returned from the database.

Now, that simple and plain ResultSet will be converted into collection of model objects.
For example, if few or more rows are selected from the persons table, each row will be converted
into an object of the PersonModel class and overall, it becomes as a collection of model
objects. For example, from the persons database table, we have retrieved 10 person rows.
So, each person row becomes a person object. That means it internally reads all rows from
the ResultSet in a loop and generates the equivalent person objects.

Thus, you will get a list of persons and that list of persons will be returned by this
toList method. That's what the work behind it. So, this is the way how does the query and
non-query operations are executed in Entity Framework Core. 

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
