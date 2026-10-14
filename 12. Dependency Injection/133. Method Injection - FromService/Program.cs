/*
In last lecture, you are injecting the service into the constructor.
But suppose if you feel that the service instance is required
only for a specific method, not for all the methods of the same class.
In that case, instead of injecting it into the constructor,
you can inject the service into a specific method, for example into Index method.
So that, that service instance is available only for the same
action method, but not for other methods in the same class.

We add the parameter as we added in the constructor and we will use 
[FromServices] attribute.
Check the controller class action method.
[FromServices] instructs the IOC container to give an object of the 
CitiesService class that implements
ICitiesService and supply that object as an argument so that we 
are receiving the same into index method parameter.
Also as you can see that we commented the older code.
In this case we do not need the readonly object of interface

Based on that same instance, we are calling the getCities method as usual,
so output should not be affected.

By the way, injecting the service object into the constructor is called as constructor injection.
This is what we did in the last lecture.
But injecting the service instance into a specific method is called as method injection.


*/
using ServiceContract;
using Services_1;

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
