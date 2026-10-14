/*
While implementing dependency injection in your application, follow some of the best practices
and avoid some bad practices at the same time. So what are they?

When you want to store some global state in the singleton service, if the data is a simple and
smaller amount, then you can do that by storing the same in the singleton service,
but at the same time you have to take care about concurrency,
because the same singleton service may be accessible by multiple threads as a part of the
ASP.NET core while handling different requests. That is why instead of using simple list or
dictionary classes, alternatively you can use concurrent bag and concurrent dictionary
instead of list and dictionary respectively, because they better handles the concurrency
via multiple threads. That means they are thread safe. They can be accessible from multiple threads
which are used internally in ASP.NET core to handle various requests,
because you are not sure that the same request will be handled by the same thread.
Different requests may be handled by different threads internally by ASP.NET core.
It is internally managed. Alternatively, if you want to store larger amount of data,
then you can prefer using either distributed cache or Redis.

The next point is request state in services. You are not supposed to share the data from
the scoped service from one place to another place. That means from one class to another class.
If you want to share some data within the same request across multiple files or multiple classes,
you can use HTTP context.items and avoid using the service locator pattern
where you can inject the service via the constructor injection.

That means, for example, without creating the child scope, you are not supposed to call
getRequiredService method within Index() action method or else anywhere.
So if you create the child scope, then it is OK to call this getRequiredService or getService method.

The difference between getRequiredService and getService is that
the getRequiredService method throws an exception
if the service has not added to the service collection.
But when you are using getService instead, if that service is not added to the service container,
then it returns null. OK, you can use either of these only within the child scope,
but not directly inside the action method or anywhere.

In case if you are using the service locator pattern by using this getRequiredService method,
then it will be difficult to identify which class depends on which other service.
So it will be difficult to track the dependency graph.
That is why avoid using the service locator pattern without creating the child scope.
Of course, you will create the child scope only when you need, not as a habit.
That is exactly when you want to use disposable services within the same scope.

But however, in case if you are using entity framework for database connections,
that will be automatically disposed at the end of the request.
So in that case, you need not use these child scopes also.

And in the next point, you are not supposed to call the dispose method manually
or keep it in the using block yourself.

Because disposing the services is the responsibility of the IOC container,
you are not supposed to do that yourself.

Generally, at the end of the scope,
all the transient and scoped services get disposed automatically.

Avoid using the captive dependencies.
Means, injecting scoped services or transient services in the singleton services.
Because in that case, that transient or scoped service act as a singleton
as long as the singleton instance is alive in memory.
For example, there is a singleton service called service A
and a transient service called service B.
The instance of the service B is supposed to be disposed at the end of the scope, right?
But in case if you have injected into the singleton service that is service A,
it will not be disposed.
It will live in memory as long as service A instance is alive.
That is why, avoid injecting transient or scoped services into the singleton services.
This problem is called as captive dependencies.

In case if you want to really do that,
consider making the scoped or transient service as a singleton service
or consider making the singleton service as a scoped service.
Because it is okay to inject scoped service into scoped service
or transient service into scoped service.

Basically, this is the chart you can follow.

Transient -> Transient -> Good
Transient -> Scoped -> Good
Transient -> Singleton -> Good

Scoped -> Transient -> Good
Scoped -> Scoped -> Good
Scoped -> Singleton -> Good

Singleton -> Transient -> Bad
Singleton -> Scoped -> Bad
Singleton -> Singleton -> Good

Alright, the next and last point is
you are not supposed to store the reference of the service instance
and use it somewhere else.
For example, we have injected a service into the constructor of the home controller
and we have stored it into a _cititesService1.
But suppose in case if you make that field as a public field
and use the public field of this particular home controller somewhere else in some other class,
it is anti-pattern.
It causes issues.

Because by the time of executing that code where you are calling this field,
this Cities Service might have been disposed.
Each class, that means each controller and services
should inject any other services in its own through its own constructor.

The behavior you described occurs because of the way the DI container manages the 
lifetime of objects.

Transient Services: These services are created each time they are requested. 
When you inject a transient service into a singleton service, a new instance 
of the transient service is created every time the singleton service is resolved. 
However, since the singleton service holds a reference to the transient service, 
it may appear as if the transient service behaves like a singleton within the 
singleton service's lifetime.

Scoped Services: Scoped services are created once per request (or per scope) 
in the context of a web application. When a scoped service is injected into a 
singleton service, it behaves like a singleton within the context of that request 
or scope. This is because the scoped service instance remains the same throughout 
the lifetime of the singleton service, which is effectively the lifetime of the 
application in the case of a singleton.



While both transient and scoped services are disposed of at the end of their 
scope, this disposal doesn't affect the behavior when they are injected into 
a singleton service. The key point is that the DI container manages the 
lifetimes of these services according to their registration and the lifetime 
of the consuming service.



While scoped and transient services are technically disposed of at the 
end of their scope, when injected into a singleton service, their behavior 
appears to mimic that of a singleton because the DI container ensures that 
the same instance is used throughout the lifetime of the singleton service.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
