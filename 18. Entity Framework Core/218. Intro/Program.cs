/*
Entity Framework Core. 
It is one of the most commonly used database framework with ASP.NET Core applications.

It is the lightweight, extensible, cross-platform framework for connecting to databases 
as a part of the .NET Core applications.

So, why should you require the database connections in your projects?
See, whatever the information that you are maintaining currently, 
for example persons information or countries, all that is temporary.
So, there should be a way that you can store the data permanently.

Every real-world application requires the database and also it requires a database 
framework in order to connect with the databases from your code.

So, Entity Framework Core is the tool or the framework which helps you to connect with the databases.

Particularly here, as per the Entity Framework Core, 
you have to maintain your model classes sync with your actual database tables.

In general, the table contains the columns.
So, the model class coupled with the table and each property name is mapped to the corresponding column.

Actually, by convention, the property names should be same as the column names, but they are not necessary.

You may have different names if required, but you can map them to the particular column by using data annotations.

However, having the property name same name as the column name is common practice.
You have to create one model class for one table.

In your database, if you have 30 tables, for example, you have to create 30 model classes.

Benifits:
When you compare with the traditional database connections such as ADO.NET,
With Entity Framework Core, as a developer, you will be writing shorter amount of code.
You will be quickly creating the DB context object and write a link query against that so that it performs the query operation.

In case if you call the save changes, it performs the updation or insertion or deletion based on the changes that you made.

But alternatively, in the traditional ADO.NET code, 
you will be creating numerous number of objects such as SQL connection, 
SQL data adapter, and command, data reader, and much more.

So, one of the attractions with Entity Framework Core is simplified code and shorter amount of code.

And another benefit is that the data values are strongly typed.
In ADO.NET, you have to write your column names in the double quotes.
For example, you are retrieving the value from a data reader object.
You have to retrieve the value based on the column name written in double quotes as a string.
It is not only error prone, but also you have to typecast the values after retrieving.
For example, if you retrieve the person name through the ADO.NET data reader, you have to manually convert the same into string.
It will not be happen automatically.

But in case of Entity Framework Core, since you declare a property of string person name, 
for example, automatically your value will be typecasted into string type and is ready in the person name property.

But the only drawback of Entity Framework Core is, it offers slower performance than ADO.NET.
Because internally, Entity Framework Core uses ADO.NET.

So, even though in these days Entity Framework Core is highly optimized, but still it cannot perform faster than ADO.NET.
Because it is the abstraction layer over ADO.NET internally.
That is why Entity Framework Core is recommended for smaller applications, otherwise good for prototype level applications, 
that means in the initial days of the development.

But if your application is data intensive application, means if it is a larger application or having higher traffic, 
then Entity Framework Core is not recommended because it offers slower performance.

Then you can try the alternatives such as ADO.NET itself or other third party frameworks such as Daper.

However, from the learning perspective, it is must to know to use Entity Framework Core.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
