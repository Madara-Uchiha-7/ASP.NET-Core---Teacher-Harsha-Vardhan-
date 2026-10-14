/*

Now the big question is, who will create object of this CitiesService class 
in HomeController() constructor.

It will be created indirectly by implementing Inversion of Control.

So what is the exact meaning of Inversion of Control, IOC?
It is a design pattern, that means it's a reusable solution for common problem in design.
It guides you how do you implement dependency inversion principle.

So in the last lecture, we have implemented dependency inversion principle, right?
That means we have created an interface, and it was created by the developer of the controller.
But in order to fulfill that, means in order to implement dependency inversion principle,
IOC container is one of the ways.

It inverses the control by shifting the control into the IOC container.
Means, instead of the developer creates an object of the CitiesService class in
controllers constructor, instead of doing this, the Inversion of Control container
takes the responsibility of creating an object of the Service class.
In that way, we will implement dependency inversion principle.
It's a pattern of don't call us, but we will call you.

The controller should not call the CitiesService directly,
but alternatively, the IOC container creates an object of the CitiesService class
and supplies that object to this Home controller.
Actually, this IOC container can be implemented by different other design patterns
such as Service Locator, Events or even Dependency Injection.
But however, Dependency Injection design pattern is the most popular one
and the same we are going to learn in this section.

At runtime, the controller says,
Hey IOC container, please give me a service.
The service is already present as a part of the IOC container.
So the IOC container creates and returns an object of the service
and supplies the same to the controller.
So the controller will catch it up
and call the essential methods whatever it wants.

But before than that, we have to add the service class particularly to the IOC container.
And this is the statement for that:
builder.Services.Add(
    new ServiceDescriptor(
        typeof(Interface),
        typeof(Service),
        ServiceLifeTime.LifeTime // Transient, Scoped, Singleton (these 3 options we can use here)
    )
);

Transient,Scoped, Singleton will be tought in the next lecures.

In this program.cs file, by default there is IOC container
which is of IServiceCollection type. That is builder.Services
So this builder.Services is your IOC container.

Make sure you have added the project reference of ServiceContract and Services_1
Lets import the namespaces which are needed for IOC container.

Check the below code.

Okay, so far we have just added our service into the IOC container.

Now, how that object can be received into this home controller?
And that's where you require the concept of dependency injection.


Lecture: 132. Dependency Injection:
Dependency Injection is a design pattern that implements inversion of control.
So the dependency injection is one of the ways to implement inversion of control.
It is a technique to receive the dependency object into the client.
In other words, it is a technique to receive the object of the Cities Service into the home
controller in our example. 
According to the dependency injection concept, the service object can be either received as
a constructor or through a method parameter. That means, at runtime, the controller asks
the IoC container, which is inbuilt in ASP.NET Core.
Hey, ASP.NET Core IoC container, please supply me an object that implements the
particular interface, for example, ICitiesService. The IoC container, which is also
called as DI container, already knows which service implements which interface.
So since the controller doesn't specify specific class name, but just asks for the interface,
then based on the interface name, it picks up the corresponding service class name.
For example, whenever the controller asks for ICitiesService,
then IoC container picks up the CitiesService class.
So it creates an object of that service class, which is also called as dependency class.
So that object of the CitiesService will be supplied to the controller at runtime.
Then, the client or the controller can receive the same,
either as a parameter in the constructor or as a parameter in the method.

Lets add a code in HomeController.
Now our constructor is :
public HomeController(ICitiesService citiesService) 
{
    _citiesService = citiesService;
}



So when you made a request in the browser,
first the home controller constructor executes. The IoC container has supplied an object of the
CitiesService class. So constructor parameter receives an object, 
that is, an object of the CitiesService
class. And if you check this parameter value while debugging you will see,
it has private field, that is,  _cities. Also, it has a method called
GetCities, of course. 

Generally, one service handles one database table.
For example, you have three tables like cities,
countries, and persons. So three services will be created. You will add all of them into this
IoC container. Then from any service, you can access any other service, not only from the
controller. For example, the controller requires the service A, but as a part of the service A,
it may require service B and C, and service C requires service D.
But for injecting any other service that a service wants, this is the way. 
Simply receive a parameter
of the interface type in the constructor, and assign the same into the field (inside constructor).
So you can use the field to access the service object, 
to call the service methods. The same pattern is repeated
everywhere. This is all the concept of dependency injection. But there are few more advanced
concepts in the dependency injection. We are going to learn them in further lectures in the same
section.
*/

using ServiceContract;
using Services_1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Add
(
    new ServiceDescriptor
    (
        typeof(ICitiesService), // 1. Whenever any some class asks for ICitiesService object,
        typeof(CitiesService), // 2. create and supply an object of the CitiesService to that.
        ServiceLifetime.Transient
    )
);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
