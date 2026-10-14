/*
This is Program.cs and here is where you can configure the application middleware by default.

After calling your build method (builder.Build();) you will get an application builder object.

So this application builder object that means app object is used to enable or create middleware.
You can create the middleware in the same order as you want to execute them.

One of the methods to create middleware is run method.
In this run method, you will define a lambda expression that you want to execute upon receiving the
request.
This lambda expression does not get executed after starting the application.
It will be executed only after receiving the request only.

This lambda expression will receive an argument that is called context.
Optionally, you can specify its data type. .Run((context) => {}) or .Run((HttpContext context) => {})

The meaning of context here is that it is an object that contains the properties such as request, response,
session, and all the properties that are essential to provide the response and to process the data.

When you write await in .Run(), then next statements in that Run() method will have to wait
till await statement finishes its execution.

But sever can still take other requests parallelly.
In that way, we will use the server resources efficiently.

The app.Run() method doesn't forward the request to the subsequent middleware.
This means if you add 2nd app.Run() below first app.Run(),
only first one will be executed.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
