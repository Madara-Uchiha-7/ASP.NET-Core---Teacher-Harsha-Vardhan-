/*
    
All right, how to add the constraints to the database table through this Entity Framework
Fluent API? We will try that in this lecture. See, the first constraint is the primary key
constraint, but we have already mentioned the same by using the key 
attribute for the person id.
So this is your primary key, that means it is not null plus unique.

But to add the not null constraint, we will add a [Required] attribute.


But how to add the unique constraint
and check constraints? We can do that through Fluent API.

public class CustomDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Adds Database index for the specified column for faster searches
        modelBuilder.Entity<ModelClass>().HasIndex("column_name").IsUnique();

        // Adds check constraint for the specified column - that execute for insert and update
        modelBuilder.Entity<ModelClass>().HasCheckConstraint("constraint_name", "condition");
    }
}


So, In PersonDbContext, 
we added :
// modelBuilder.Entity<Person>().HasIndex(person => person.TaxIdentificationNumber).IsUnique();
Since this is just a demonstartion we added it in the comments.
This will create an index for this TIN column for first two searches
and also applies unique constraint for this TIN column.
That means no duplicate values allowed on this TIN column.


Similarly we added:
modelBuilder.Entity<Person>().HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8");
1st argument : CHK_TIN : This is the name of the constraint.
2nd argument : 
This condition will be checked automatically every time when insertion as well as updation
is happening on the particular table. In case if the user supplies a value which
doesn't follow this particular condition. That means if the given condition is false,
the insert or update will throw an exception. OK, in our case, assume the business requirement
is that the TIN column should contain exactly eight characters. 
That means the length of the TIN 
should be eight. Optionally, keep the column name in the square brackets
as per the rules of the SQL server. 

Since above line is deprecated in the latest version we are using:
modelBuilder.Entity<Person>().
    ToTable(
        "Persons", 
        t => t.HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8")
    );


Now, run the command for Entities project:
Add-Migration TIN_Updated_CHK

Now run :
Update-Database

In case you use older name for column "TaxIdentificationNumber" which was TIN before.
Then change it into PersonsDbContext and also in the Up method which is created after
the Add-Migration Command.

Now go to your SQL server object explorer. Expand your persons table. Right click on
constraints. Refresh. Now you can see our new constraint has been added. That is check
constraint on the TIN column. 
 
But how do you maintain the table relations, means how do you manage the foreign key columns?
We will explore through that in the next lecture.
 
 */


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
