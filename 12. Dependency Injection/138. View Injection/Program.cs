/*
    In ASP.NET Core, the views are compiled as their classes.
That means when you create a view and when you compile it,
it will automatically generate a class that inherits from a predefined class called razor page.
So just like you can inject the services into controllers or any other service classes,
you can inject the services into the views as well.
It is possible by using the at inject directive within the view.

[IoC/DI Container: (Service: IService (Dependancy))]
The Above will Supplies an object of service class:

[View] :
@inject IService referenceVariable

@{
    referenceVariable.ServiceMethod();
}   


E.g. 
Lets say we need to inject the service in the index.cshtml
To do so, we need to import the namespace.
So goto viewimports.cshtml
We added : @using ServiceContract_1

now in index.cshtml:
@inject ICitiesService citiesServiceInView
...
@{
    List<string> cities =  citiesServiceInView.GetCities();
}
<ul class="list">
    @foreach (string city in cities)
    {
        <li>@city</li>
    }
</ul>
@* 
Old code:
<ul class="list">
    @foreach (string city in Model)
    {
        <li>@city</li>
    }
</ul> 
*@

So what is the benefit behind this?
Suppose you want a service within the view that is not provided by the controller.
So the views have an option of injecting any service whatever it wants,
which is not supplied by the controller.
But alternatively, most of the database and other related service will be injected by the controller.
But if there is any service which is specific to the view,
then you can inject such services in the view.

For example, the view wants to use the configuration that is provided by ASP.NET Core.
Then you can inject configuration related services within the view.

Both controllers and views run under the same request scope by default.
the service instance that is injected in the view also getting the same service instance id.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
