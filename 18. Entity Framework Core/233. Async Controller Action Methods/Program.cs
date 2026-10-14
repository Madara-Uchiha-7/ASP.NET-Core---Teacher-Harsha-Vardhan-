/*
We have changed the signature of the service methods.
So we have to update the code of the controller as well as the service test,
that wherever you call these service methods, we have to use await keyword.

So we have made a chane in PersonsController, ContryServiceTest

It is recommended to use the method as async return type for controller methods,
becuase you will be mostly performing the db operations most of the time.
Even if you do not use await in the controller method, even then its okay and
recommended to add the async keyword for the method.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
