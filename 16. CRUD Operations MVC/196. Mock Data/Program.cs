/*
Lets add some sample data.

In CountresService.cs
we are going to add a boolean parameter to  
CountriesService() constructor:
CountriesService(bool initialize = true)

Its true by default.

In CountriesServiceTest
We pass false in "new CountriesService();"
because you don't want to initialize the mock data in the countries, let's supply false.
Similarly we passed false in ther PersonsServiceTtests.cs
Because our fundamental goal is that while performing the unit test cases,
the countries collection should be empty.
That means this initialization should not work.

But while invoking the countries service or persons service from the controller
through dependency injection,
this initialize will be by default true.
So there we can add the mock data.

Lets generate sample GUID values.
Create GUID.
Select Registry Format.
Then New GUID.
In result you will get a new value.

In the CountriesService() constructor, we will use this to add a dummy data.

To Convert the string into GuId we use Guid.Parse()


Similarly all this we do for PersonService.cs and its tests.

To generate the mock data except the Guid, you can use 3rd party website.
Goto to 
www.mockaroo.com

Field Name                      Type               

Name                            First Name
    
Email                           Email Address

DateOfBirth                     Datetime

Gender                          Gender

Address                         Street Address

ReceiveNewsLetters              Boolean

Click on Preview -> Raw -> Copy the values without headers.

And use it in our PersonService.cs

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
