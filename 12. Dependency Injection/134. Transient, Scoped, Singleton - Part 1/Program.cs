/*
A service lifetime in dependency injection represents when that service object should be created
and when that object should be destroyed by IOC container.
In dependency injection, the IOC container or
DI container is responsible to create service objects and also to dispose them.
But when exactly the service objects will be created and when they get destroyed or disposed?
It depends on the service lifetime, either transient or scoped or singleton.

Lets talk about 
ServiceLifetime.Transient:
In case of transient, a new service object will be created for every time when the service is
injected. For example, we have injected the same transient service into three different controllers
or maybe three different other services. So every time when the transient service is injected,
a new object will be created for that service class.

For example, the same CitiesService in our example has injected three times. So
internally, three objects of the CitiesService gets created. 
That is why it is called per injection.

ServiceLifetime.Scoped:
Scope means for every scope, a new service object will be created.
But the scope lifetime in general is a browser request.
That means when the application encounters a new browser request,
automatically the IOC container creates a new scope.
At the end of the process in the browser, that means once the response is completed,
then it is end of the scope.
But however, within the same request itself, it is possible to create multiple scopes.
In that case, for every scope, a new service object will be created.

ServiceLifetime.Singleton:
when it is injected into any class for the first time.
But later, the same service object will be reused every time.
So new objects of the singleton service will not be created until the application shutdown.


For example, we have created three services. 
One is of transient type,
and scope type, and singleton. So we have three services.

When the first request has been received by the application,
assume we have injected these three services.
So for each service, a new object will be created.
So the first object here is being represented as one.
So transient service t_1, scoped service sco_1, and singleton service sin_1.

But maybe within the same request, in the same class, or maybe in another class,
we have injected again these three services, second time.
Then, for each invocation, the transient service should be instantiated.
So you will get another object of the transient service i.e. t_2,
but you will get the same object of the scoped service i.e. sco_1
Because by default, the entire request processing is rated as a single scope,
unless you create custom scopes.
So since you are injecting the same service second time in the same scope,
a new object of the scoped service will not be created.
But always singleton will have one and only object.
So undoubtedly, you will get the same object for second invocation as well i.e. sin_1

Now assume we have received the second request from the browser.
Again, we have injected all three services.
So as usual, you will get another object of the transient service for each injection i.e. t_3
Every time when you call the service, you will get a new object.
That's about transient service.
But for the second request, another new scope has been created.
And within this scope, you will get another object of this scoped service.
That is sco_2.
Always undoubtedly, for the singleton service, you will have single object
for all the requests and all the scopes, so it will have sin_1 again.


It is also possible that you can inject a service into another service.
For example, in our home controller, we have injected the Cities Service.
Maybe if needed, within this CitiesService i.e. in 
CitiesService class, you may inject another service.
And that service may inject one or more other services.

And internally, the ioc container will automatically maintain all these service relations
as service graph or dependency injection graph.

And it is also important when the service objects get destroyed.
In case of transient services, the transient service objects get created for every injection,
but they will not be destroyed when that class execution has been completed.
The transient service instances will be destroyed at the end of the scope,
not when they are completed.
For example, if you are injecting a transient service called CitiesService 
into the home controller,
at the end of the home controller execution, the Cities Service object will not be destroyed.
It will be destroyed when the scope ends.
That means the request processing has been completed.

But what about scoped services?
The scoped service objects get destroyed in the same time,
that is when the scope gets completed.
So even though the instantiation rules are different for transient and scoped service,
those instances get destroyed at the same time for both transient and scoped.

But what about singleton services?
The singleton services will be instantiated for the first time when they are requested,
and the same service object will be used for all the other scopes and all the injections
throughout the entire application lifetime for all the requests.
And those services will be destroyed only when the application is shut down.

That means when the console window that runs ASP.NET Core application closes,
exactly at that point of time, the singleton services get destroyed, that means disposed.

But I would like to prove all these points practically,
so we will try these service lifetimes practically in code in the next lecture.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
