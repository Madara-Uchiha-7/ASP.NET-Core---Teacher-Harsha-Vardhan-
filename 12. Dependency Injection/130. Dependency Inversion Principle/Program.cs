/*
Lets fix the mistake that we did in last lecture. I.e. lets add a dependancy injection.
Lets first understand why creating the service object is wrong in the Controller's constructor.
There are two reasons. First of all, since you are creating an object of the existing class
that indicates that at first this class must be created and then only you can create object
for this class. For example, let's say in your real world project, the developer of this cities
service has not developed this. So there is no cities service class. So in this case, how can you
create object of the cities service class here? Not possible, right? 
So the developer of the controller
should wait until the service development gets completed. So this is the problem. The controller
depends on the service. The controller developer should wait until the service development gets
completed. The second problem is, in case if you want to use a different class instead of this city
service, let's say there is another service class called cities service 2 that gets the data from
database. So instead of this cities service, you have to use that other service. Then you have to
change the class name at "private readonly CitiesService _citiesService and
"new CitiesService", wherever you are accessing or using that service. Maybe for example,
in the real world project, you are using the same service class in over 100 controllers. So in all
those controllers, wherever you are creating object for the service class, you have to change the class
name. So changing or upgrading the services will be problematic in future.
This also makes Service and controller tightly coupled. The Higher-level module(class) i.e. in 
this case Controller is the higher level module, is dependent on the lower level module 
i.e. service class.
Another problem is any changes made in the lower
level module directly affects the higher level module.
e.g. if you change the return type or argumanets or method name of GetCities() method
then this will directly impact all the controllers.
Next problem is when you want to use an alternative service in the controller
instead of the existing service, then it requires huge changes in the controller itself.
For example, you would like to use another service that directly connects with the database.
So you have to change the class name in contoller and while creating object in constructor.
And if new service has different set of method signatures, 
calling methods in Controller will also will affect.
So this is the problem. Interchanging the services will be a problematic thing.
And also it is quite difficult to unit test the controller because it is tightly coupled
with the service. Fundamentally, this is the problem. The controller is tightly coupled
with the service. We have to make them loosely coupled. Then all these problems can be solved
by
dependency inversion principle, DIP.
It is just a design principle,
means it is the guideline, but doesn't provide any predefined library or functionality
or even doesn't tell you how do you implement this principle. So the principle is just a guideline
that tells you the set of rules, but doesn't tell you how do you implement it.
In order to implement this, you have to use inversion of control. We will learn that
inversion of control in the next lecture, so hold it. First try to understand this
dependency inversion principle. It says the higher level modules should not depend on
lower level modules, but both should depend on the abstractions. So what does it mean?

Abstraction means it is possible that you can create an interface or abstract class, but in most of
the cases, you will use interfaces. Because interfaces are flexible, even it supports
multiple inheritance as well. 

For example, let's say imagine a story. There are two developers like developer A and
developer B. I am the developer A and you are the developer B. Me as a developer B,
I am developing the controller and you as developer A, you are developing the service.
So both of us should depend on an interface, but that interface should be created by me.
That means the developer of the client should create the interface.
That is the principle called dependency inversion principle.

Let me show that. So we are going to create another interface
in the solution in seperate class library project.
Right click on solution -> Add -> New Project -> from 3rd dropdown select library -> Class Library
So we are creating a new class library, but not class library dotnet framework. 
Give name : ServiceContract
Then select the same .NET version.

Generally interface acts as a contract between two classes.
That's why we are going to call it as ServiceContract. It's a preferred name. You can
give other name also.

While connecting projects to each other, we have to always make sure that we need
to use same .NET version otherwise we get erros while compile time.

Now, in ServiceContract, rename the default file to:
ICitiesService
It is the preferred naming convention that
you will prefix I for all the interfaces, though it is optional, strongly recommended.

Goto the interface and see the added code.
We only added a method which will be compulsory to the class which will implement it.
Right click on our current project and use this Library using add project reference option.

So the service contracts compiled file means the DLL file of the service contract
will be the dependency for this. Now in the home controller,

I cannot use this cities service at all because we are assuming that this cities service is not yet
created. So instead, we have to import the service contracts and create a variable of the interface
type and don't create object of the cities service. 
Check the controller class code.

Once you check the code,
create a new Services_1 library with same CitiesService.cs class,
because we need our service class also to use the interface.
Check its code.
Add a ServiceContract library as a project reference in this new library.
So, now we have our service and controller both using one abstraction.

So far, we created a object of interface in our Controller class.
How do we assign the Service class object to this interface object is the next question.
The inversion of control takes the responsibility of 
creating the Service object and adding that object into this 
reference variable (interface object which we created in controller using readonly.) 
is the responsibility of dependency injection. 
We will learn both of these concepts in further lectures..

*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
