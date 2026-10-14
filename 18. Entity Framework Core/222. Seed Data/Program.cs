/*
Okay, assume that we have created the persons and countries tables.
And by default, that tables will be empty,
But generally, we would like to add some
initial data into the table.
And that is called seed data here.

How to add the seed data in case of Entity Framework?
We have been provided with a method called HasData();
modelBuilder.Entity<ModelClass>().HasData(entityObject);


So if you can supply the entity object
for the same, that object, that means that
row will be inserted into the database table as soon as the database has been created
initially.


But it will not be reinserted if you delete.
Means, this data will not be maintained in the table in case if you make any
changes to the table.

These are the initial rows of the table that gets added to the table only when
it is created, not after that.



We are going to use OnModelCreating method in PersonDbContext class.
So after you map your model class to the table, we add this seed data changes.
One way is :
modelBuilder.Entity<Country>().HasData(
    new Country()
    {
        CountryID = Guid.NewGuid(),
        CountryName = "Bharat"
    },
    ...
);
In above approch we can add multiple objects to create the initial data.

Another better way is:
We create a JSON file, in that we add a data and read that json, then use it in HasData.
Teacher has already created JSON File.
We have pasted them in the CRUD Project.







*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
