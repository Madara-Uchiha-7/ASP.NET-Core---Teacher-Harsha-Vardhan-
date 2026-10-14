/*

Currently, we are adding the services into the service collection'
by using add method by creating a new object of the service descriptor class.
i.e. builder.Services.Add(new ServiceDescriptor(...))

Hover over Services from "builder.Services.Add", you will see:
IServiceCollection WebApplicationBuilder.Services { get; }

So, In this IServiceCollection, there are more shorthand methods to add the service into the
service collection. That is, addTransient, addScoped and addSingleton respectively.

Transient :
builder.Services.AddTransient<IService, Service> ();
Scoped:
builder.Services.AddScoped<IService, Service> ();
Singleton:
builder.Services.AddSingleton<IService, Service> ();

Using these generic parameters, you can supply the interface type and then service
class name type in the same order. That means, instead of you write this :
builder.Services.Add
(
    new ServiceDescriptor
    (
        typeof(ICitiesService),
        typeof(CitiesService),
        ServiceLifetime.Transient
    )
);
lengthy code,
the shorthand version of the same is:
builder.Services.AddTransient<ICitiesService, CitiesService>();


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
