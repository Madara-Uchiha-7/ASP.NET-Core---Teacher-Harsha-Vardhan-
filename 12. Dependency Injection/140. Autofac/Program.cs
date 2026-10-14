/*

Autofac is another open source project which acts as a IoC container for ASP.NET Core.
Means it is alternative to the built-in ASP.NET Core IoC container which is called as
Microsoft.Extensions.DependencyInjectionIoCContainer. Yes, by default, ASP.NET Core has
built-in IoC container and that library is available at this 
namespace Microsoft.Extensions.DependencyInjection.
The previous lectures of this section explains about the dependency injection
using this built-in feature only. But the built-in IoC container has some limitations.
To overcome those limitations, otherwise to get some additional advanced features
which will be useful for real-world projects, some of the developers or
companies may prefer Autofac instead of the built-in IoC container.

So, what are the particular differences or the new features supported by Autofac?
The built-in dependency injection contains only three lifetimes i.e. transient,
scoped, and singleton. But Autofac has two more.
i.e. InstancePerDependency is equivalent to transient.
In the same way, InstancePerLifetimeScope is equivalent to scoped.
SingleInstance is equal to singleton. But we have two more additional lifetimes.
InstancePerOwned and InstancePerMatchingLifetimeScope.

The InstancePerOwned implements the lifetime of the services based on the relations between the
classes. That means you can build your own relationship among the classes and accordingly,
the instances of the services will be created. Means multiple instances for multiple relations.

And in the same way, the InstancePerMatchingLifetimeScope means
you can create a new service instance based on the matching name.
You can tag a particular name while adding the service to the
IoC container. And based on the matching name, the instance gets created.
Means different instances for different matching names.

So these two features are not supported by the built-in dependency injection IoC container.
Similarly, the metadata for services and decorators are not supported by the
built-in IoC container in .NET Core, but supported by the Autofac.

So in case if your project or your company needs these particular features,
you can use Autofac in your project.

If you want to learn more about the Autofac, you can go through this particular link:
https://autofac.readthedocs.io/en/latest/getting-started/index.html


In this lecture, we are going to see the basic use case of Autofac,
but not advanced features. To learn more about Autofac, go through this link.

Well, how do you enable Autofac in your project? 
Simply right-click on the dependencies folder in your project ->
Manage NuGet packages ->
A NuGet package consists of one or more DLL files.
Which provides essential libraries to implement particular feature in your application.

Generally, NuGet packages are provided by either Microsoft or by third party.
And under the installed, you can see the packages which are installed in this current
project. By default, no packages are installed. So it is not showing anything by default.
So here click on Browse.
And you can see lots of predefined packages from Microsoft and from third party vendors.
Now search for Autofac. Select the first package, which is saying Autofac by Autofac Contributors.
And select the version number 8.4.0, because if you are using other version of Autofac,
there may be some code related changes. So you may encounter some errors or some changes in the code.
So we suggest you to use the same exact version what we have used.

Alternatively, you can also run the command
install package package name in this package manager console, which can be opened in
Tools menu, NuGet Package Manager, and then Package Manager Console.

The additional package that is required is Autofac.Extensions.DependencyInjection.
Select 10.0.0

In order to enable the Autofac, switch to the Program.cs file.
At the most top, after creating your web application builder here, you have to call HeyBuilder.
You have to use Autofac instead of the built-in dependency injection container.
So use the ServiceProviderFactory.
That means we are using a custom or third-party ServiceProviderFactory.
A ServiceProviderFactory is the representation for IoC container.
So we have to create an object of Autofac.ServiceProviderFactory:

using Autofac.Extensions.DependencyInjection;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


But how can you add the services into Autofac instead of the built-in DI container?
// ContainerBuilder is a class from Autofac namespace.
// So while calling ConfigureContainer method, you have to pass a lambda expression
// which has a parameter called ContainerBuilder.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{

});


Check the code and comments below.


******Note:
It seems this autofac is also available for web api also.


*/
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Services_3;
using ServiceContract_1;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

// ContainerBuilder is a class from Autofac namespace.
// So while calling ConfigureContainer method, you have to pass a lambda expression
// which has a parameter called ContainerBuilder.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // This is the actual place where you can write the code for adding
    // the services into the IoC container. That is Autofac IoC container.
    // Here you have the methods like ContainerBuilder.RegisterType
    // It is the common method for all types of service lifetimes.
    // Say it is transient, scoped or singleton.
    // First you have to mention the service class name, not the service contract.
    // In out case it is : CitiesService
    // Continue by writing another extension method as.
    // Then you have to mention the service contract or you can say interface, that is ICityService.
    // Then you have to say InstancePerDependency.
    // Yes, now this is equivalent to add transient in regular DI container.
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();

    // Then how about add scoped:
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();

    // Singleton:
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();

    // Similarly, you have the other two types.
    // But in this lecture, we are not going to focus on them.

    // Now what about ServiceScopeFactory that we have used in HomeController?
    // In case of Autofac, instead of IServiceScopeFactory, alternatively,
    // you have to use ILifetimeScope. We have done changes in constructor and action method also.
    // Check the HomeController
    // In Using block, instead of :
    // _serviceScopeFactory.CreateScope()
    // we will use different code.
    // Also for
    // ICitiesService citiesService = scope_1.ServiceProvider.GetRequiredService<ICitiesService>();
    // We will use different code at the place of "ServiceProvider"

    // Check the HomeController code.
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
