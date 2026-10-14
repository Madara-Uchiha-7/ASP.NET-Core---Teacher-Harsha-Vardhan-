/*
In order to begin with the Entity Framework Core, you require to know DbContext and DbSet.

The dbContext is binded to a specific SQL database and dbSet is binded to a specific table.

Custom DbContext class:
public class CustomDBContext : DbContext ----------------------------------------> SQL Database
{
    public DbSet<ModelClass1> DbSet1 { get; set; }-------------------------------> Table 1
    public DbSet<ModelClass2> DbSet2 { get; set; }-------------------------------> Table 2
}

For each table we will create 1 DbSet.
The dbSet is of generic class, so you require to pass the generic parameter 
and that is your model class. 
So for each table, you will be creating a model class, right? So that model class will be
mentioned here : <ModelClass>. 

For example, we want two tables like countries and persons and the model class
names will be singular, that is country and person respectively. 
So you will be creating dbSet of
country and dbSet of person. 
And it is a convention to name the dbSet as plural, means the dbSet's
names will be respectively countries and persons, plural. 

i.e. 
public DbSet<Country> countries { get; set; }
public DbSet<Person> persons { get; set; }

Here, your dbContext class name can be
anything, but it must be inherited from a predefined class called 
dbContext from Microsoft.EntityFrameworkCore
namespace. And in the same way, in the same namespace, you have dbSet class as well.

Lets add a code in Country.cs in Entities.
In this we used the Attribute called Key which is persent in the 
"using System.ComponentModel.DataAnnotations;"
It will consider the CountryID as a primary key in the countries table.

In the model class i.e. Country.cs for now, an important matter in the data types is
if it is nullable, you must have the question mark after the data type. In case if you don't
have this question mark after your data type, then it means it is mandatory field. 
Means non-null column. Then you have to initialize this property either in 
inline or in a constructor.
Our CountryName is nullable so we have added the ? after the "string"

Same way we have adde the primary key in the Person class.

[StringLength(40)] will create a NVARCHAR of 40 characters.


Right click on the Entities project and click on Manage Nuget Packages.
Search for 
Microsoft.EntityFrameworkCore.SqlServer in the browse tab.
Version I am downloading is "9.0.8"

To check if its installed or not, 
Right click on the Entities project and click on Manage Nuget Packages,
then search it in Installed tab.
OR
Expand the Dependencies in the Entities and then expand the Package.


To install this package from command line, use below :
click on Tools -> NuGetPackage Manager -> Package Manager Console -> 
Select Entities from default Project.
and type command : Install-Package "name of package"


In Entities project add the class "PersonsDbContext.cs"
Suffix of DbContext is optional.
Add "using Microsoft.EntityFrameworkCore;"
So that we can inherit the DbContext class.

You have to bind these dbSets to corresponding 
tables(In this case tables are Countries and Persons).

For that we have overriden the OnModelCreating()
You can configure the tables and corresponding indexes or primary keys or relations
or any seed data using the object modelBuilder which is present as the parameter in the 
OnModelCreating().

Entity() :->
method will get the country type of DbSet that is countries and similary for persons.

ToTable():->
You give the table name to your DbSet, you can give any name.

After this, you have to add your DbSet as a service in your program.cs file(CRUD Project).
Because Entity Framework Core by default uses dependency injection.
For this we are going to use "builder.Services.AddDbContext<>()"
AddDbContext is present in the "using Microsoft.EntityFrameworkCore"
So, to use this, expand this project (and also next projects too which will use this)
Right click on dependencies -> Manage NuGet Packages
And install the same package which we did above for Entities. 
Version I am downloading is "9.0.8".
I.e. for CRUD project we will have to intall it.

Alright, now your DbContext PersonsDbContext class is added as a service.
You can inject this DbContext in anywhere,
either in the controller or in any other service. 
For example, in the Persons service, you can inject this Persons DbContext
and then you can access any DbSet to write the link queries against the database.
And also you have to mention that to use the SQL Server
because the concept of DbContext is common for all types of databases
such as MySQL or SQLite, etc.

So in order to mention that we are using SQL Server,
we have added "dbName.UseSqlServer();" in the lambda expression.

In case if you want other than SQL Server,
you can try using other options such as for MySQL or SQLite.
But in our course, we are going to demonstrate only SQL Server
because it is mostly used with ASP.NET Core.

We dont inject the DbContext in the controller,
because we want the separation between the DbContext and controller.
So what we do practically is that
instead of accessing the DbContext directly in the controller,
we have to do the same in the service.

Now,
We have to add the connection string in the configuration.
We will try that in the next lecture.
*/

using Services;
using ServiceContracts;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Addition of services into IOC container.
builder.Services.AddSingleton<ICountryService, CountriesService>();
builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddDbContext<PersonsDbContext>(dbName =>
{
    dbName.UseSqlServer();
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
