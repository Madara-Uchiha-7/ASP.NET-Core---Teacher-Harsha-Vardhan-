/*
In order to really create the database along with the tables, we have to run the
code first migrations.


Migrations, also called as code first migrations, are the commands to the database either to create
the table or make changes to the existing table structure. For example, initially you would like
to create a table, so you will run a migration, then after that you would like to modify something
in the structure of the table, such as adding a new column here for example, and here changing
the data type of an existing column or some other change in the existing table. So every time you
would like to make some changes in the table structure, you will run a migration.

But fortunately you need not write any code for adding migrations, you will run just a small
command in the package manager console, so it generates the C-sharp code for the migration,
and in order to run that migration, you will run another command. Let me show that practically.

In order to work with the migrations, we have to use another package called
Microsoft.EntityFrameworkCore.Design
in the CRUD project because it has the main logic of controllers and etc where we will use the Entity Framework.
So, 1st right click on the project and make it a "set as a start up" project.
Now go to the tools menu, now goto package manager, and click on package manager console.
Make sure you are inside the CRUD project. 
You can also select it from console dropdown called "Default Project".
Run (It is a case sensitive command):
Install-Package Microsoft.EntityFrameworkCore.Design

This will install the given NuGet package in the CRUD project.

In order to work with the migrations, we have to use another package called 
Microsoft.EntityFrameworkCore.Tools
in the Entities project.

So go to the tools menu, now goto package manager, and click on package manager console.
Make sure you are inside the Entities project. 
You can also select it from console dropdown called "Default Project".
Entities project because this is where the dbset is present.

1st run (It is a case sensitive command):
Install-Package Microsoft.EntityFrameworkCore.Tools

This will install the given NuGet package in the Entitis project.


Then in our PersonDbContext class,
add a contructor because we are calling its constructor in the CRUD program.cs
If we dont then we will get the error below error when we will run Add-Migration Command"
"
An error occurred while accessing the Microsoft.Extensions.Hosting services. 
Continuing without the application service provider. 
Error: 'AddDbContext' was called with configuration, 
but the context type 'PersonsDbContext' only declares a 
parameterless constructor. This means that the configuration passed 
to 'AddDbContext' will never be used. If configuration is passed to 
'AddDbContext', then 'PersonsDbContext' should declare a constructor 
that accepts a DbContextOptions<PersonsDbContext> and must pass it to the base constructor for DbContext.
Unable to create a 'DbContext' of type ''. 
The exception 'No database provider has been configured for this DbContext. 
A provider can be configured by overriding the 'DbContext.OnConfiguring' 
method or by using 'AddDbContext' on the application service provider. 
If 'AddDbContext' is used, then also ensure that your DbContext type 
accepts a DbContextOptions<TContext> object in its constructor and 
passes it to the base constructor for DbContext.' was thrown while attempting to create an instance. 
For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
"

Constructor which we have added:
public PersonsDbContext(DbContextOptions options) : base(options) { }

So at runtime, what happens is that whatever the options that you have supplied in the Program.cs file,
including the database provider and connection string,
these options will be supplied to the constructor of the db-context class as options parameter.
And the same will be supplied to the parent class constructor through this base keyword.
So in that way, our EntityFrameworkDatabaseProvider will be recognized
along with the connection string as mentioned in this program.cs file.

Build the solution.

Now run the command called Add-Migration migrationName. It's a case-sensitive.
Generally, the first migration name will be initial. Of course, you can give it any other name.
So in our case it will be :
Add-Migration Initial

With this "Initial" name, a file will be created with C sharp code for the migration.


After this 
you will see a new folder "Migrations" in Entities project with some code files in it.
By default, it consists of two files.
One will be with Migration name which we gave i.e. *_Initial.cs
and 
See, in this file name, the first portion is the timestamp.
And the second one is the migration name that we have given.

And another file name is Persons-db-context-model-snapshot.
Means your db-context class name followed by model-snapshot.


Open up the first file first.
Class name of it will be our Migration name which we gave i.e. Initial
It contains two methods, that is up and down.
The up script or up method will be executed while creating the database
or while making the changes into the existing tables.
But in case if you roll back the migrations, the down method executes.
In general, it is rare.
So focus on this up method here.
That means a set of predefined methods to create the table.
To configure the primary key and foreign key.
And relations.
And many more.
See, for example, you can see a method called createTable.
It specifies the name of the table and the columns.
For example, countryId.
It is the unique identifier data type.
And it is not nullable.
etc.
And this table has a primary key called countryId.
Constraint name is pk underscore countries.
Like that you can see, most of the migration code is self-explanatory.
When you run this migration, this particular script or code executes.
So based on this only actual table gets created.
You can see the column name, corresponding data type, etc.

In general, it is not advisable to make direct changes in this migration code.
If you want to make any changes, you can make it as another migration.
And also see, after creating the table, you can see InsertData().
This is the data from our seed data.


The down method is opposite of the up.
Simply it will drop the table, drop both tables.


So as of now, we have just created a migration, but it is not run yet.
So go to the same package manager console.
Again, select same entities project always.
Run the second command: Update-Database -Verbose


So two commands always will be repeated for migrations, addMigration followed by updateDatabase.
So if you run this updateDatabase command, updateDatabase-verbose,
that means the actual SQL script will be shown in this package manager console.
So what about the latest migration that was created,
All that will be executed.
You can see all the SQL script generated and executed against the database.
For example, you can see the create commands, insert commands executed in console.

This is the plain SQL code that is generated based on the code of the Entities.Migrations 

So finally, as a result, the database along with the table,
along with the initial data has been created.
In case if you want to see that, go to the View menu, SQL Server Object Explorer.
Expand your local DB instance.
Expand your databases.
Now you can see our persons database has been created.
Expand that.
Tables, it has two tables, that is countries and persons.
The another system table called migrations history stores what migrations are executed so far.
You can see a right click on that table.
View data.
See as of now, as of this moment,
our initial migration is executed. So it is inserted as a row.
In this way, the entity framework knows what migrations are executed in the particular database.
In future, if you run another migration, that migration name will be added as another row.

Okay, now see our own tables,
For example, right click on persons.
you can see all the columns are generated as per the expected data types if you expand the columns.
And right click on persons.
View data.
You can see the initial sample data has been inserted here.


how can you fetch this database data into your actual country service or persons service?
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
