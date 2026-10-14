/*
If you want to perform multiple or complex database operations,
that means you would like to execute multiple SQL statements at a time with a single database call,
then creating a stored procedure in the database is the best choice.
Because with stored procedures, you will pack up, means you will group multiple SQL statements
as one stored procedure, and you will call the same from your application source code
with a single database call. So as opposed to the linq query, in case of linq query,
based on the linq query that you write in GetPersonByPersonID, for example, if you write:
_db.Persons.FirstOrDefault(person => person.ID == Id)
statement,
the equivalent single SQL statement will be generated and executed, of course, as you know.

But alternatively, you can write the SQL statement and store it as a stored procedure in the actual
database. Then from here, you will call that stored procedure so that that particular SQL
statement executes. There are multiple benefits of stored procedure, but how can you call the
stored procedure? In case if you want to perform insert, update, delete operations,
then you will use this:
int DbContext.Database.ExecuteSqlRaw(
    stirng sql,                   // E.g. "EXECUTE [dbo].[StoredProcName] @Param1 @Param2
    params object[] parameters    // A list of objects of SqlParameter type
)


Alternatively, in case if you want to retrieve
the data, means if your SQL has at least one select statement, then you will use from SQL
raw statement as alternative:
IQueryable<Model> DBSetName.FromSqlRaw(
    string sql,                     // E.g. "EXECUTE [dbo].[StoredProcName] @Param1 @Param2
    params object[] parameters      // A list of objects of SqlParameter type
)


Now, how to create the stored procedure in case of code first approach.
Means you cannot go to the SQL Server Management Studio and create a stored procedure. 
Even though you practically can do that,
it is not considered to be the correct way to create the stored procedure.

We changed the CountriesServiceTest contructor to:
_countryService = new CountriesService(
    new Entities.PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options)
);
So we are creating a new object of the DbContextOptionsBuilder,
So that DbContextOptionsBuilder will be received by PersonDbContext constructor.
DbContextOptionsBuilder<PersonsDbContext> creates a builder for your EF Core context.
Its .Options property gives you:
DbContextOptions<PersonsDbContext>

So, now, for any kind of changes to the database can be done through code first migrations.
So in order to do that, go to the Package Manager console.
Make sure that you are in the Entities Project.
We will do command called Add-Migration again because we are going to do the changes in the db again:
Add-Migration GetPersons_StoredProcedure

It is recommended to give the migration file name same name as the stored procedure name that you want to create.

We can use any other name in place of "GetPersons_StoredProcedure" as per our need.
This is the name of the migration and this becomes the migration file name.

In this case, since we have not made any changes to the model class,
it generates an empty migration file like this.
See in the entities project, wherever dbcontext is present,
In the migrations folder, you can see a new file 
with the file name of the timestamp, then your migration name that you gave.
In this case, it is get persons underscore stored procedure.
So with the same name, there is a GetPersons_StoredProcedure class in that file 
and it is inherited from the migration class.
That means GetPersons_StoredProcedure class is a migration file. 
It contains two methods up and down.
Whenever you run the update database command next time, this up method executes.
But in case in future when you want to roll back the migration, then this down method executes.
So mainly focus on this up method.
So, after our "Add-Migration GetPersons_StoredProcedure" command the method Up and Down will not have any code inside them
this time.

Here you can write any code that you want to make it executed to make changes to the database.
In this case, what is the change that you want to make?
Yes, you have to create a new stored procedure.
So, we will write a code inside it.

In order to execute SQL statement,
we have migration builder object,
We have a method called SQL and supply this string value that contains SQL statements.
So whenever this SQL statement executed, it creates a stored procedure in the database.
Means our Stored Procedure code gets stored in the database.

But sometimes you would like to revoke or undo the migrations.
So while undoing the migrations, this down method executes.
And there you would like to execute a statement called drop procedure.
We have added that code also in the Down method.

After you write the code in sql, build the solution again.

In order to execute our latest migration Up method,
In the package manager console again,
We have to run the command: Update-Database

So it checks whichever the migration is recently created.
That migration gets executed.

You will see Up method code getting executed and you will see your added Stored Procedure in the 
Package Manager Console when you will run "Update-Database" Command.

But in order to ensure the same,
Go to the SQL server object explorer (You can get it from the view menu)
Expand up the local DB that you are using.

And in the databases, you can see our database called persons database.
So then expand that.

Under tables, as usual, you can see your tables.
And in order to see your stored procedures.
Here you can see a folder called programmability.
And their stored procedures.
Here you can see your stored procedure got created.

In case if you want to see that code, 
Right click on your stored procedure,
And click on view code.

In our PersonsDbContext, we have to create a method to call that stored procedure:
public IQueryable<Person> sp_GetAllPersons()
{
    return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]");
}
or 
we can call the ToList() method So it eagerly executes that stored procedure immediately:
public List<Person> sp_GetAllPersons()
{
    return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
}

So this particular code executes the stored procedure.
So you will get the result set.
And that result set will be converted into.
An IQueryable of person class, Because we are using the persons DB set here.
and we have to return the same.

Then we have called  sp_GetAllPersons() from our Persons Service class. We have commented the older code.



--------------------------------------------------------------------------------------------------------
Q/A:


How to remove a stored procedure from the database?
Hi Harsha,

I understand that to add a stored procedure to the database I need to use 
the command Add-Database which will result in the execution of the Up() method in the migration file.

But what command I will need to use to execute the Down() method to remove 
the stored procedure from the migration file?

Ans:
hi,

If you want to remove an existing stored procedure (that was already created 
by another existing migration), without rolling back, you can create a new migration that 
explicitly removes the stored procedure.

In the Up() method of the new migration, you can execute a SQL command to 
drop the stored procedure.



e.g:

public partial class RemoveStoredProc : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP PROCEDURE [dbo].[YourProcedureName]");
    }
 
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("CREATE PROCEDURE [dbo].[YourProcedureName] ...");
    }
}
In this example, the Up() method removes the stored procedure using a SQL command, 
and the Down() method recreates the stored procedure using the original SQL script.



Question to above answer:

So does the Down() method only gets executed when we roll back a migration?

And how do I roll back a migration?

Thanks.

Ans:
hi,

So does the Down() method only gets executed when we roll back a migration?

Yes

how do I roll back a migration?

Update-Database -Migration <MigrationName>

It rolls back to the state before that migration is applied.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
