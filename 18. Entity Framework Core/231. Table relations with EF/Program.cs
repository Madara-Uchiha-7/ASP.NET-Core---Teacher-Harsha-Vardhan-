/*
SQL Server Referential Integrity specifies how do you separate the data between the primary table and detailed table.
In the primary table or master table, you will have the primary key, 
which contains all available values of the particular column.

For example, there are two tables like Categories and Products.
The CategoryId column of the Categories table contains all available categories.
So, these values are referenced in the foreign key property of the Products table.

But how do you configure the primary key and foreign key?
In the same way, how can you access the related table data in Entity Framework?
That's what we are trying to learn in this lecture.


In Entity Framework, you can make use of navigation properties instead of joins.
For example, in the Child model class, you can create a parent property that refers to parent record.
E.g.
Master Model class:
public class MasterModel
{
    public data_type PropertyName { get; set; }
    public virtual ICollection<ChildModel> ChildPropertyName { get; set; }
}

Child Model class:
public class ChildModel
{
    public data_type PropertyName { get; set; }
    public virtual ParentModel ParentPropertyName { get; set; }
}

ParentPropertyName will point to the MasterModel
and 
ChildPropertyName can also be added in Parent Class so that it will point to the Parent.
E.g.
In one country, how many people we have,
Since there can be more than one people, we have the data type : ICollection

In person.cs lets add a new Property:
public Country? Country { get; set; }
Its a nullable. So, it can have the null value.


Now, this Country property will have CountryID and CountryName inside it becuase its type is Conutry.


Unfortunately, by default, the navigation properties like this will not be loaded with LINQ queries.
By default, their values will be null.
I.e. here, right now, we are not trying to create this property as a column in the database.
Right now we just want to use it in our service class.
--------
Person class section from this lecture is yet to be noted:
This part is explaied bleow....(*)
--------

Similarly we have added the persons property in the Country.cs.
Since we do not need them, I have commented it. That property we have used it in the below Fluent API
example, since we are not going to use below Fluent API part, that is also commented.

There is another way to configure the table relations through Fluent API.
Though it is not required, but just for knowledge, let's learn that:

public class CustomDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChildModel>().
            .HasOne<ParentModel>(parent => parent.ParentReferencePropertyInChildModel)
            .WithMany(Child => child.ChildReferencePropertyInParentModel)
            .HasForeignKey(chil => child.ForeignKeyPropertyInChildModel);
    }
}

We have added the code for this in the DbContextClass.

Now, we do not need to do all this extra work....we will use below:
In the Persons class
the property which we have added, 
i.e. 
public Country? Country { get; set; }

We will add a attribute above it called ForeignKey.

Think of it like this:

Person
│
├── CountryID  ← Foreign Key
│
└── Country    ← Navigation Property

You're telling EF Core:

"Country navigation property uses CountryID as its foreign key."
[ForeignKey(...)] on the navigation property should refer to the foreign-key property in the same Person class.
So, we have added:
[ForeignKey(nameof(CountryID))]


Now, 
...(*) part:
In PersonService, in the method GetPersonByPersonID,
we want our LINQ query to fetch the country data using the foreign property also,  
by default, the _db.Persons will get the data but will keep the our foreign property null.
So, since we want our country name and id in our foreign property for the person,
we have to use the Include method:

Person? person = _db.Persons.Include(person => person.Country).FirstOrDefault(person => person.ID == personID);

so using person object we can now do:
string personCountry = person.Country.CountryName;


Similarly,
we have used Include in the GetAllPersons()
The Include used in the GetAllPersons() is the teachers way and the Include in GetPersonByPersonID()
method is chatgpts way.

Because now we can use this foreign property,
the PersonToPersonResponseWithCountry method will change.


Now, in addition to this, check "ToPersonResponse" method in the PersonResponse class, we have updated it 
and used it in the 
PersonService,
we replaced all the calls of ""
with 
"ToPersonResponse"


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
