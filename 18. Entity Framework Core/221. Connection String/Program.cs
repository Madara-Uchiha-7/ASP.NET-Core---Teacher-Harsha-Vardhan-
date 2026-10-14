/*
A connection string is a string value that specifies the details of the database that
you would like to connect. In the initial stages of the development, it is recommended to use the
local db. That means your sql server database file will be created as part of the same
developer machine. So if there are multiple developers, each developer would have their
own database in their own machine, so that there will be no conflicts between databases
of multiple developers. In order to create a new database, go to the view menu,
click on sql server object explorer. Here you can see your local db instances.

A sql server mainly supports two types of database instances. One is the standard
sql server database instance, which will be connected based on the server name or IP address,
and other one is local db. That means this local db database file will be created as a part of the
same developer machine. For staging and production environments, maintaining a dedicated centralized
database server is recommended, but for development scenarios, it is recommended to use the local db.

When you install visual studio, by default, it installs the local db called mssql local db.
It is name of the local db server instance. So in this sql server object explorer,
expand the local db and then click on databases. You can see the list of existing databases.
I would like to create a new one. So right click on databases, click on add new database,
and here specify the name of the new database. For example, PersonsDatabase. You can give it any name
and specify the path where exactly that database file should be stored on your device. By default,
it is present under app data folder of your user.
I have kept the same path as it is.

So we would like to connect to this particular database,
but we have to mention the connection details as connection string. But instead of you write
your own connection string yourself manually, there is an easy way to generate the connection
string automatically. Simply right click on the required database, that is PersonsDatabase in
our case, and click on properties below. So it opens up the properties window.
One of the properties that you can find here is connection string. It contains the complete
details of the connection string, including the SQL server instance name, database name, etc.
So just click there, manually select the entire text up to ending. You can use the keyboard
shortcut shift right arrow to select the entire text, or you can press control shift right arrow.
Once the entire text is selected, you can copy this. Make sure the entire text is selected properly.
And now come back to your code. Then, in program.cs file, paste it in comments.
We are going to need it.


For e.g. in our case it is:

Data Source=(localdb)\ProjectModels;Initial Catalog=PersonsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30

Here:
Data Source=(localdb)\ProjectModels:
The data source parameter specifies name of the SQL server instance. 
In this case,
we are connecting to local DB instance. 

Initial Catalog=PersonsDatabase:
Initial catalog specifies the name of the database,

Integrated Security=True;
Integrated security equal to true. That means we are using Windows
authentication in SQL server. That means you need not mention a separate user ID and password
to connect with the database. But alternatively for the production scenarios,
you may be preferring to use a SQL server authentication, where you have to mention
the user ID and password, which is the secret value may not be revealed to all developers.


Now, we add this string in:
appsettings.json file.
In that file we will add our section called
ConnectionStrings.
Actually, you can give any other name, but this is the common preferred name.
In this section,
you can add a key, for example, default, or you can say DefaultConnection,
whatever the name you prefer, not a problem. Then the value is your connection string.
You have to access the same and mention the same while adding the DB context as a service.

So, in our program.cs,
in options.UseSqlServer("here")
we can add that connection string directly but its not recommened.
because you are mixing the configuration settings along with your source code. 
It is a bad practice.
Alternatively, we have to place the same connection string in the configuration file
and we have to access the same because as a benefit of doing this approach,
you will be able to configure the connection string at runtime in different environments.
For example, you can configure another connection string for production server,
another for staging server, and you may supply the connection string through
process level environment variables. Like that, while deploying your application
in different environments, you can supply the connection strings via configuration.
That is why the connection string must be in the configuration only.

So thats why we will access our configuration inside the:
options.UseSqlServer("here")
i.e.:
builder.Services.AddDbContext<PersonsDbContext>(dbName =>
{
    dbName.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
});

But you may also write the same in shortcut way, that is,

you could have used a predefined method called getConnectionString:
dbName.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

So this method points to the connection string's key automatically, 
so no need to mention query string.
Simply, we have to mention the name of the connection string key.





*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
