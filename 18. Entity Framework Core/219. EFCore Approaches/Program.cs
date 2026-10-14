/*
Your Entity Framework Core can be used in two approaches, or in other words, two ways.
That is database-first approach and code-first approach as you can see.

The difference is, while writing your code, that means at 
the initial stage of writing the code,
if you generate Entity Model classes based on an existing database,
then it is called DB-first approach.

But alternatively, if you create the Entity Model classes first,
and then the database will be created automatically by applying some commands,
then it is called as code-first approach.

And another difference is the changes made in the database tables.
For example, you would like to add an additional column or delete existing column,
otherwise change something in the column, such as changing the column name,
or changing the data type, or adding some constraints, etc.
In case of DB-first approach, the database is independent.
So you have to directly deal with the database,
means you have to use your SQL commands to make changes to the database table structure,
such as adding or removing the columns.
Then again, you have to make changes to the model classes yourself
in order to make them sync with the database changes.

But in case of code-first approach,
if you want to make any kind of changes in the database,
such as adding or removing columns, or modifying the structure of existing columns,
all changes are made in the Entity Model classes first.
Then you will apply code-first migrations, means some commands,
to make them reflected on the database.
At least theoretically, the developer need not care about the actual database
in case of code-first approach.

See here, the code-first approach is suitable and preferred
for newer databases and newer applications.

But when particularly you prefer using DB-first approach?
In case if you have an existing database,
or you are migrating from existing application into a new application.
Or otherwise, if you have the database designed by the DBA team,
and the database is being developed separately by DBA team,
in these cases, DB-first approach is better.


How can you perform updates or changes in the database after creating one?
In case of code-first approach, almost you don't have any kind of grip on database.
Because always the database will be created automatically by Entity Framework Core
by using a technique called code-first migrations.
So if you want to make any changes in the database schema directly through SQL, 
almost it is discouraged.
Or even you make changes, the changes that you make will probably lost.
Because at least, when you are migrating your application from one machine to another machine,
for example, into production server,
the changes that you make on database will not be ported automatically.
In that case, you are responsible to port the database changes on the other machine.

But in case of DB-first approach, you will be writing the SQL script without hesitation.
So any kind of small or big changes on database can be done independently.
For example, let's say you would like to add indexes on database
or add the unique keys or primary keys or normalization
or any kind of objects such as processors, triggers, functions.
All of these database objects are created independently on database itself by using the TSQL.
Your application source code is not responsible for all of those database-specific changes.
So simply the database become independent in case of DB-first approach.
In case if you want to create the stored processors in case of code-first approach,
you have to write them as a part of the C-sharp source code.
By using code-first migrations, you can port them into the database.
But in case of DB-first approach, as we told already, since the database is independent,
freely you can create any kind of database objects such as stored processors, indexes, triggers, anything.

So overall, as a summary, for smaller applications or for the applications at prototype level,
means before the client approval level, the code-first approach can be preferred.
But as long as the application size increases,
or if your application is a larger application or data-intensive application,means if the user traffic is higher, 
in these cases database-first approach is better.






*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
