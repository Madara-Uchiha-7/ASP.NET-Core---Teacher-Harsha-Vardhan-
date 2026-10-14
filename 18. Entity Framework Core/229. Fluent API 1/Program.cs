/*
Okay, in the last lecture, we have added a new column called TIN in the persons table.
See, first we have added a property called TIN in this persons class,
and we run addMigration and updateDatabase commands in the PackageManager console,
so it generates the migration and added that column into the table, into this persons table.

So, if we can check this SQL Server Object Explorer and expand this databases, persons database,
and our table called persons, see it has the TIN column.
But we have a big complaint on this data type. It is n-varchar of max, that means it supports
the maximum number of characters allowed, that is up to 2 billion characters per one single string.
And moreover, it is n-varchar data type, means it supports unicode characters.
That means in this particular column, you can either store the alphabets, numerical characters,
and non-alphabets characters also, means all the characters that are supported by unicode
data type. That means you can store any character of any natural language that is supported by
unicode. It sounds good, but it has bad impact on the performance of the database,
because it dramatically increases the size of the database, because for each character,
it occupies two bytes, instead of one byte for ASCII. So, you should not use this n-varchar data
type unless it is strongly required. For example, in case of person name, you may require this
n-varchar, because the person name may contain non-alphanumeric characters,
means, for example, characters from other natural languages.
But in this example, this TIN number may contain alphabets or digits, that's all.

You can check the last lecture migration file, there you will see, in the Up method, TIN column has the 
data type nvarchar(max).


But from this Entity Framework, how can you take the control of the SQL Server data type?
How do you specify which data type should be applied for a particular column of the table
through Entity Framework? That is where the Fluent API comes into picture.

The Fluent API is a set of predefined methods in Entity Framework that allows you to specify
more details on the column data types that describes the table structure,
which may include the table name, column names, data types, and their constraints.
And you can use this Fluent API in the OnModelCreating method of the DbContext class.
Actually, we are already using this Totable to specify the table name that is mapped to the
specific model class. For example, go back to the PersonDbContext. Here in this OnModelCreating
method, we are saying Entity Country should be mapped to Countries table. So, "Countries" is the name
of the table that is mapped to the Country model class and in the same way Person model class.

Optionally, you can specify the schema name for the particular table.
e.g.
modelBuilder.Entity<ModelClass>().ToTable("table_name", schema: "schema_name");

We can also specify the View name (and Schema name optionally to be mapped to model class:
modelBuilder.Entity<ModelClass>().ToTable("view_name", schema: "schema_name");

Also, we can also specify the default schema name applicable for all the tables in the DbContext:
modelBuilder.HasDefaultSchema("schema_name");

In our case:
the table is already created, so it doesn't make sense to add the schema name
later after creating the table. OK. If the table is not created, you can add the schema name for
the table. So, under that particular specified schema, the table gets created initially.
We don't want to do that right now.


Now we can also add inside the OnModelCreating method:
modelBuilder.Entity<ModelClass>().Property(temp => temp.PropertyName)
    .HasColumnName("column_name")
    .HasColumnType("data_type")
    .HasDefaultValue("default_value")


Here, at first, you are trying to select entity of the particular
model class, for example, Person model class. And then you are selecting a specific property of the
model class, for example, TIN property. Then you can add the column name, column data type,
and optionally, the default value. You can use either of these(HasColumnName, HasColumnType and HasDefaultValue)
methods in any order. I would 
like to use it for TIN property here.


modelBuilder is a parameter of part of the onModelCreating method.
This will be given automatically by Entity Framework itself. 

So in our PersonDbContext we added :
modelBuilder.Entity<Person>().Property(temp => temp.TIN)
        .HasColumnName("TaxIdentificationNumber")
        .HasColumnType("varchar(8)")
        .HasDefaultValue("ABC12345");

TaxIdentificationNumber is the new column name we are giving to pre existing column called TIN.
ABC12345 : for all the columns, this will be the default value every
time when you insert a new row into the Persons table.
Now, since we have made some changes in
the DB context as well as model class, let me add a migration:
Add-Migration TIN_Updated

In the new migration file,
you will see the method called RenameColumn and AlterColumn.

Now run:
Update-Database


ABC12345: This will not be added to the older data because it is only applied to the new rows.


---------------------------------------------------------------------------------------------------------------
The OnModelCreating() method in Entity Framework Core is typically executed
only once when the DbContext is being initialized. It is called during the 
initialization of the application or when the DbContext is first accessed.

In the case of an ASP.NET Core application, the OnModelCreating() method is 
usually called when the DbContext is being configured during application startup. 
It is not executed per each request or per client. Instead, it is executed once during 
the initialization phase of the DbContext when the application starts or when the DbContext is first accessed.

After the OnModelCreating() method is called and the model is built, the configuration 
is cached by Entity Framework Core, and the model is reused for subsequent requests. This 
means that the OnModelCreating() method is not called again during each request or per client.

Once the DbContext is initialized and the model is built, it remains in memory and is
used throughout the application's lifetime, handling multiple requests from different 
clients without invoking the OnModelCreating() method again.

The OnModelCreating method is executes every time when a new instance 
of DbContext (scoped service - so per request) is created.

And yes, the OnModelCreating() method will be executed when running the "Add-Migration" 
command in Entity Framework Core. The "Add-Migration" command is used to scaffold a new 
migration based on the changes detected in your DbContext.

When you run the "Add-Migration" command, Entity Framework Core analyzes the changes made 
to your entity classes and the DbContext configuration. It then generates a new 
migration class that represents those changes.

---------------------------------------------------------------------------------------------------------------

Q:
Hi Sir,

For my Existing data(Seed data) also the default value has applied but 
in the video it didnt and said for the new record only default values will be applied

Ans:
That can happen based on how the migration was generated/applied.

If the migration added the column as NOT NULL with a default, 
SQL Server will backfill existing rows with that default while 
adding the column. In the video, the column/default was applied 
in a way where existing rows were already having a value (or the column existed), so you did not notice a backfill.

So rule of thumb: default constraint is for future inserts, 
but when you add a new non-null column with a default, 
the database can also fill old rows at the time the column is added.

---------------------------------------------------------------------------------------------------------------

Q:
can i modify it directly from the database without using fluent because it's faster and easier


Ans:
hi,

EF Core's Code First Approach doesn't gives you grip in database directly, because it is supposed to 
be ready to recreate the database any time, when needed.

As long as you are using EF Core, this is the way to configure your database constraints and related stuff.

---------------------------------------------------------------------------------------------------------------





*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
