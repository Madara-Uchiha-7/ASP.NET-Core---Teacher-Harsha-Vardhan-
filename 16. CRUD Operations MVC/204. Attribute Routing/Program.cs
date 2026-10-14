/*
Already we are using the attribute routing,
that means we are going to apply the route attribute for each action method.

So just above the action method, we are writing route attribute and specifying the URL.
So when you make a request to this particular URL,
automatically that request will be received by this action method. 
That's what the concept.

But what's the new point here?

The new point is here, you can apply the route as a 
prefix for the controller class level also.

It acts as a prefix for all the routes of the action method.

For example, for the controller class, we have applied the route called mycontroller
and of course, we have given the route for each action method.
So the route that is applied for the controller class acts as a prefix.
So this first action method can be reached as myController/URL1.

Here the URL1 is the the url given in the Route attribute of the action method.

But if you make a request to only URL1 without myController,
that will not be received by the action method.

But in case if you want to override that prefix, you have to prefix slash.

So,
if you write Route("/URL1")
above the action method then 
slash overrides the prefix that is applied by the controller class.


So in persons controller,
we can remote the "persons" from action method route and add it in the 
main controller class

If you use route on persons controller as [Route("persons")],
you know you do not have to add this "persons" in the action method routes,
but what if we do it, and did not remove the persons from the action method?
The url will become e.g.:
persons/persons/create 

If you use route on persons controller as [Route("persons")],
you do not need to write "/" as a prefix in the action method Routes.
E.g. assume below is action method Route
[Route("create")]
Here you do not need to write the [Route("/create")]
If you write [Route("/create")] instead of [Route("create")]
then
url will become: you localhost url + create
e.g. http://localhost:5255/create 
instead of http://localhost:5255/persons/create

This additional "/" overrides the default prefix.


You can use the route tokens.
That means the controller and action mentioned in the 
square brackets are called as route tokens:

[Route("[controller]/[action]") -> This acts as a prefix
You can use this route tokens in order to take the controller name or
action name automatically.
Instead of manually writing it.

For e.g. we have added this in our controller, check the code.


The benefit is in case if you change the controller class name
or action name in future, it will be automatically used for Routes.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
