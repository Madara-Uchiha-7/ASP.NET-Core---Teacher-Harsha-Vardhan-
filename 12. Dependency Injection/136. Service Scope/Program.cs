/*
Of course, by default, whenever application runs,
a root scope gets created automatically in ASP.NET Core.

And for each request, a new scope gets created in ASP.NET Core.
And you can call them as request scopes.

For example, there are 10 requests, so 10 request scopes will be created every time.
That means for each request, a new request scope gets created.

And it is possible that you can create child scopes within the same request scope.


Root Scope -> Request 1 -> Request Scope 1 ->  IServiceScopeFactory.CreateScope() -> Child Scope 1
           -> Request 2 -> Request Scope 2

But what is the scope exactly represents?
A scope represents the lifetime of the scoped service and also the transient services.
Even though the transient services get instantiated for each injection,
they get disposed at the end of the same scope.
But it is also possible that you can create one or more child scopes within the same request scope
by using CreateScope() method of the IServiceScopeFactory.

When should you create a child scope?
Let's say for example, you have created a disposable service.
That means it implements IDisposable interface.
For example, your service creates a database connection in the constructor
and closes that database connection in the dispose method.
So it must be short-lived, right?
The database connection should not be open till end of the request.
It should be opened and once your work is done, the database connection should be closed.
Means the service should be disposed as soon as possible.
So for that scenario, you will use this child scopes concept.

Lets see the example.

Lets create CititesService class in Services_3.
and make it implement ServiceContract_1

Lets go to CitiesService class.
Add IDisposable interface implementation and Dispose method.
Check the comments in Dispose method.

Now, lets make ServiceLifetime as a Scoped Service
Now we will create a child scope whenever needed.

In Home Controller, we will inject CitiesService.
Check the comments in Index().

In case of Entity Framework,
the service instance lifetime of the database services
will be automatically managed by Entity Framework itself.

The approach of the child scopes can be practiced only
when you are implementing non-Entity Framework.
*/

using ServiceContract_1;
using Services_3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Add
(
    new ServiceDescriptor
    (
        typeof(ICitiesService),
        typeof(CitiesService),
        ServiceLifetime.Scoped
    )
);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
