/*
In the countryservice we were using the list to store the data.
Here we will now inject the dbcontext.
So, we added a parameter in the constructor.
And assigned it to our private PersonsDbContext type variable.

Here the built-in IOC container creates an object of the persons db context class
because in the program.cs, we have added our db context as a service.
So you can inject the persons db context in any class wherever you want.
So just like that in the service, we are injecting the db context class.

Then after that, you can use this underscore db as a db context variable
wherever you would like to access the database.

When you want to retrieve the data means query operations are done with LINQ query.

When you want to apply the where means where condition,
you can use the where method of linq just like how we have used earlier.

Similarly, when you want to sort the data, you can use this order by method.

And in case if you want to do any calculations in the result data, you can use the select.
For example, you would like to calculate something automatically 
or you would like to convert each object into another type.
For example, converting from the persons data into persons response.
So when you want to execute a lambda expression for each object,
you can use this select optionally.

That is why when you write these linq methods against a DB set of entity framework core,
that is called linq to entities.

So, for e.g. check the GetAllCountries() method in the CountriesService:
_db.Countries.Select(country => country.ToCountryResponse()).ToList();

At runtime, this expression will be converted into equivalent select statements.
For example, select all the columns from the countries.
So that select statement will be internally executed through ADO.NET.

Similarly you can check other methods also.
E.g.:
Country? countryResponseFromContries = _db.Countries.FirstOrDefault(country =>

    country.CountryID == countryID
);

Will be converted into:
Select col1,col2
from tablename
i.e.
select countryid, countryname
from countries
where countryid = our given id.

    
Now in the AddCountry method that is in the insert operation:
We cheked the count first:
_db.Countries.Count(temp => temp.CountryName == countryAddRequest.CountryName) > 0
Then:
_db.Countries.Add(country);
We have added the country object into the DB set.
Then to make them save in the database we called:
_db.SaveChanges();

What this save changes method will do is that exactly?
It will verify what are the objects that are added into the DB set using "_db.Countries.Add(country);"
Internally for each entity object, it maintains the entity state.
So for this newly inserted object using "_db.Countries.Add(country);"
the entity state by default will be "added".
So for all the added entity states, it will generate the insert statement in SQL
and that will be executed against the database internally by using ADO.NET.
In that way, this country will be inserted.

Similarly we have done the changes in the PersonsService.

_db.SaveChanges():
This method is common for all the insert, update, delete operations.
For example, when you want to insert,
add the entity object into the DB set and then call the saveChanges.
So it generates the equivalent insert statement
and executes the same against the database.
Similarly, when you want to delete the row,
you will have to call the remove method and then call the saveChanges.
Similarly, when you want to perform the updation operation,
you can overwrite the values of the entity object directly
and then call saveChanges.
When you modify the value of at least one particular property,
its state will be automatically changed as entityState dot modified.
So when you call the saveChanges, for those updated objects,
the update statement gets generated and executed.
If you do not modify anything and call SaveChanges
then it will not generate anything.


Our services Persons and Contries 
have the default scope.
That scope is "Scoped" Service.

Services are by default designed as scoped service.

It is not advisable or possible to inject
scoped service in the singleton service.

But in our code:
builder.Services.AddSingleton<ICountryService, CountriesService>();
builder.Services.AddSingleton<IPersonService, PersonService>();

We are doing it that is injecting the scoped into the singlton service.

So we will get error here.
To fix it,
So, we have to change our Countries Service from singleton service into scoped service.
So, here in the program.cs file, instead of add singleton, call add scoped.

Our personsdbContext is also by default scoped service.


It is not possible to call
your own code or your own method as a part of the linq to Entities expression.

I.e. in the persons service we used :
return _db.Persons.Select(person => PersonToPersonResponseWithCountry(person)).ToList();

But we can not call "PersonToPersonResponseWithCountry"
as this is our own method and we are performing the operation on the Entity using Linq.

So, we changed it to:

return _db.Persons.ToList().Select(person => PersonToPersonResponseWithCountry(person)).ToList();

To fix this issue, first you try calling toList method here.
It indicates that you are eagerly, that means immediately executing 
"_db.Persons.ToList()"
linq to entities expression.


----------------------------------------------------------------------------

Very Important Configuration on EF Core
16 upvotes
Hamed · Lecture 224 · 3 years ago
Hi everyone,

There is a very important configuration in SQL databases as "Cascade Delete".

I asked dear Harsha how it should be done in EF Core, so here I will post his answer, since it's very useful:



You can easily configure it in OnModelCreating() method.

Eg:

Suppose you have two entities, Order and OrderItem, where each order can have multiple order items. You want to enable cascade delete so that when an order is deleted, all of its associated order items are also deleted.

protected override void OnModelCreating(ModelBuilder modelBuilder){    
    modelBuilder.Entity<Order>().HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order).OnDelete(DeleteBehavior.Cascade);
}


----------------------------------------------------------------------------------

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
