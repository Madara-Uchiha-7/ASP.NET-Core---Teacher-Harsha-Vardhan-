/*
Middleware is a component that is assembled into the application pipeline
to handle the requests and responses.
Imagine a set of methods that execute one after another whenever you receive
the request, in this case those methods are called as middleware.

After the execution of all thge middlewares the response will be given back to browser.
The middlewares are chained one after another and they execute in the
same sequence how they are created or added.

Initially the application request pipeline is empty and then you will add the middleware one
by one.

So assume that we have added the first middleware and then the second one and
then the third one and so on as many as you want.
Each middleware performs a single operation, that means we are trying to implement
single responsibility principle.
For example the first middleware implements the https redirection and second middleware enables static
files redirection and then the third one enables the authentication the fourth one enables authorization
like this each middleware performs an individual single operation.
In this way it is easy to understand the purpose of each middleware and easily you can compose the sequence
of middleware execution.
For example in case if you don't want a single particular operation you can
remove that particular middleware without affecting the functionality of other middleware.
That is the underlying goal of middlewares.

You can create middlewares in two ways:
The middleware can be at the request delegate that means either an anonymous method
or lambda expression, it is okay for simple operations.

But in case if the middleware functionality is a bit larger you can
write the same code in a separate middleware class.

So in general the middleware can be either single anonymous method or lambda
expression or also can be a class and moreover there is no rule that each
middleware has to forward the request to the next subsequent middleware.
Such middleware is called as terminal middleware or short circuiting middleware.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
