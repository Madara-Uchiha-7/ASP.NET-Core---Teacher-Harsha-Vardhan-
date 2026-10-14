/*
For this lecture lets create a new library called
ServiceContract_1. This will be a Library which will have a ICitiesService interface.

Lets also create a new Service Library called Services_2. It will have a CitiesService class.

Right click on Services_2 -> Add a project reference of ServiceContract_1.

Also add the reference of Services_2 and ServiceContract_1 in this project.

In order to identify the difference among service instances,
let's try to create a new GUID for each object.
Means, first in the ICitiesService, create a property called
ServiceInstanceId. Of course, the name can be anything.

When a new object of the Cities Service gets created, its constructor gets executed, right?
So there exactly we are creating a new GUID.
So implement the property of the interface, that is public GUID in CitiesService beacuse 
it is implementing the interface called ICitiesService.
Check the ICitiesService file and then check the CitiesService file.

Okay, now
we are creating a variable called "ServiceInstanceId" in the interface.
Since that interface has it, we have to use the variable in the CitiesService class.
Since our this file's builder.Service creates the CitiesService class object to give it to the
controller, we know that, in this process CitiesService constructor will get called.
So in the CitiesService class constructor we are creating the new GUID each time.

Now lets go back the controller class.
Lets inject the same CitiesService more than once.
Maybe three times for demonstration.

So, we created 3 readonly objects of interface.
Each one will hold 3 different CitiesService class object in HomeConstructor.
And we added the same in ViewBag inside the action method.

Lets go to index.cshtml
and print those ViewBag variables.

Now, if you run the code with : ServiceLifetime.Transient
you will see that you get 3 diff ids. e.g. t1, t2, t3
Because it's a transient service.
So since we have injected it three times in the same controller or maybe in different classes as well.
Every time when it is injected, the IOC container creates a new object of the Cities Service class.
If you refresh the browser i.e. you make another request, then you will get 3 different ids again. e.g. t4, t5, t6

Now go to the program.cs file.
Try to make this lifetime as scoped service.
Now since it is a scoped service.
And by default for one request, one scope gets created automatically.
So within the same request scope, we are getting one object. e.g. sco_1, sco_1, sco_1
Exactly, when we inject the first service in the constructor, a new object of the Cities Service gets created.
But when we are injecting the same service second time and third time, new objects will not be created.
The IOC container supplies the same existing service object.
That is why for the second time and third time, the constructor doesn't execute because new objects are not being created.
And this is what the exact meaning of scoped service.

But you have to understand one more feature of this scoped service.
By default, for every request, a new scope gets created.
So, if you refresh the browser i.e. you make another request, then
you will get a new Id again which will be repeated 3 times. e.g. sco_2, sco_2, sco_2
By default, for every request, a new scope gets created.
So for each request, a new scope.
For each scope, a new object.
This is how does the scoped service work.
In this case, no matter how many times the same service is injected and in how many classes.

Now let's try to change this lifetime as a singleton service.
Okay, by default at first time, it works equivalent to scoped service. e.g. sin_1, sin_1, sin_1
But if you refresh the browser, then still you will get sin_1, sin_1, sin_1
So when you refresh, that means when you make another request,
see there is no any kind of change in this service instance ID.
Because for each request or for each scope, a new service object will not be created,
but will be created only for the first time for the first request.
But this will continue its lifetime until the application shutdown.
i.e. if you close the browser the again the application, only then you will get a new id.


But when to use which one?
When you want to store some data temporarily, such as cache services,
that means common data for all the users and all the requests,
then singleton services are best.
The best example is in-memory collections as alternative to databases.
In real-world projects, before creating your actual database,
or for testing purpose, you would like to create in-memory collection as alternative to database.
For example, you would like to really maintain a database with 10 tables.
So instead, initially you will maintain the same data as in-memory collections.
So the same data should be shared or persisted for all the requests and all the users.
So for that scenario, singleton services are best.
And also, if you want to store the data temporarily as a cache service,
then also singleton services are best.

But alternatively, the database services, such as Entity Framework DB Context,
so those will be used as a scoped service.
Because the reason,
when a new browser request is received by the application,
a new database connection should be opened,
and that database connection should be closed at the end of the request.
So for each request, a new database connection.
That is why, for Entity Framework DB Context,
or for any kind of database connection for that matter,
the scoped services are best.

Then what about transient services?
When you want your service to be short-lived,
that means only for one time for one controller,
then transient services are best.
Let's say for example, there is a service that encrypts the data.
Suppose you don't want to share the encrypted data for other requests.
Or even for other service instances.
So you want to create a new service object for each invocation,
means each injection.
So for that cases, transient services are best.
For another example,
let's say there is a service that sends an email automatically.
So that service should be instantiated for each injection.
So for such services also, you will use transient services.

*/
using ServiceContract_1;
using Services_2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Add
(
    new ServiceDescriptor
    (
        typeof(ICitiesService),
        typeof(CitiesService),
        ServiceLifetime.Transient
    )
);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
