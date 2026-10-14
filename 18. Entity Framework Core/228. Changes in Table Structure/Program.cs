/*
(
Note:
The column which we have added in this lecture called TIN has been
renamed in the next lecture, so that you will not see as a TIN in the SQL Server Object Explorer.
)

Once the table has been created, how do you make changes to the existing database table?
Means, how do you change the table structure?

For example, you would like to rename the column or change the data type of the column
or add some constraint. That is what we are trying to perform in these further lectures.
Exactly in this lecture, let us try to learn how do you add or remove the columns.
For example, in the person table,
I would like to add an additional column called TIN
i.e. text identification number.

To write this, 
we need to first add the property in the Person.cs:
public string? TIN { get; set; }

We added the ? after string because we do not want this TIN to be not null.

Since we have added essential column directly in the model class,
these changes should be reflected in the actual database table.
For that in Package Manager console, in Entities project,
run :
Add-Migration TINColumn

So, any kind of stored procedure you would like to add,
or adding a column, removing the column,
or any kind of changes to the existing columns, such as adding the constraints,
changing the data type of the column, all the changes are made through the same migration system.

Now, in our latest Migration file:
Here in this up method, you can see the migration builder dot add column method.
This is the migration API.
So, here AddColumn<string>() means we are going to add a new column.
type:"nvarchar(max) is the actual SQL server data type.
And name:"TIN" is the name of the column
and table: "Persons"

In case if you want to rework the changes or undo the migration,
then this down method executes, there the column gets removed by DropColumn method.

Now, lets execute the up method using:
Update-Database

If you check the table now, 
you will see null values in the TIN column.
Optionally, you can add an SQL statement in order to add the default value in this TIN column.
You can do that by using a new migration.



Now, question is, how do you rename the column?
And how do you change the data type of an existing column?
And how do you add constraints to the existing columns?
For example, adding the unique constraint or not null constraint, etc.
We will try to perform that in the next lecture.


But when you run this application, as of now, we are going to get some error.
In our sp_GetAllPersons() this method will show the error:
The required column called TIN was not present in the results from SQL operation.

It's because in the stored procedure, we have not selected the TIN column, which is newly added now.
In order to address this issue, we have to create another stored procedure,
which includes with the TIN column.

You can fix this by creating the new migration and adding new stored procedure with this new column.
And then we will call this stored procedure in the PersonDbContext and this PersonDbContext method will
be called by the PersonService.

For now to avoid this error, we are going to comment the Line which calls our PersonDbContext stored procedure method.
I.e. inside the GetAllPersons() method,
we will keep the LINQ implementation instead of stored procedure call.

Similarly we are going to stay on Linq methods in AddPerson Method also instead of calling the stored procedure,
otherwise we will get error there also.

------------------------------------------------------------------------------------------------------
Q:
Hi Harsha,

For an example - Imagine we're working on a larger projects which has almost 100 tables & we're using Code 
First Approach.
Now for every single change like changing the datatype of an existing column, adding a new column, removing a column. 
every time we have to run this command "Add-Migration" & "Update-Database" in such case into the migration 
folder we have thousands or lacs of migrations file.

Can we delete unnecessary migration files or we should keep it as it is?

Ans:
hi,

You can also delete all migration files and start over by deleting the database and creating a new one. 
You can do this by deleting all migration files from the Migrations folder and then running the 
"Add-Migration" and then “Update-Database” commands. This will remove all tables from the database 
and create a new one based on your current model.

--------------------------------------------------------------------------------------------------------------








*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
