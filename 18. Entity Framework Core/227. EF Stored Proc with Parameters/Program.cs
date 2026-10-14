/*
How can you pass parameters to this stored procedure?

The second argument can be an object array of parameters.
Each object is an object of SqlParameter type.

This is the class from ADO.NET, 
which contains the parameter name, value, and the direction optionally.
You can supply the list of parameters in both i.e. in FromSqlRaw as well as ExecuteSqlRaw.

In case if you want to retrieve the rows from the table,
then use "FromSqlRaw" which returns each element as an object of the model class.
For example, the rows from the persons table will be returned as IQueryable of person.
But in case if you want to perform non-query operations like insert, update, delete,
then you can use this execute SqlRaw,
which can receive the parameters but returns only the number of rows updated or inserted or deleted.

So, lets go to package manager, make sure you are in the Entities Project.
Use command:
Add-Migration InsertPerson_StoredProcedure

In the Migrations folder, go to that file and we will add the code there for our stored procedure.
In our Stored Procedure you will see keyword "uniqueidentifier" that is nothing but the data type of GUID in sql.
You can see the data type for each one if you expand, PersonDatabase -> Tables -> dbo.Persons -> Columns

Run the build to make sure that there are no compilation errors.
Now, we will call below command, so that our SP gets created and Up method is executed:
Update-Database

Now, in our PersonDbContext class we will add the method which will call our stored procedure.
In that we have used SqlParamter which is present in "Microsoft.Data.SqlClient"
We are using the "ExecuteSqlRaw" method which retuens the number of rows affected.

Then we are going to call the method from our PerdonDbContext from Person Service.

-----------------------------------------------------------------------------------------------------
The C# null value is not accepted by SQL Server.

Try to supply DBNull instead of null for each parameter (when the value is null).

e.g:
new SqlParameter("@DateOfBirth", person.DateOfBirth ?? DBNull.Value);
If we do not do like above and do not pass the date of birth from UI, then we will get error in sql.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
