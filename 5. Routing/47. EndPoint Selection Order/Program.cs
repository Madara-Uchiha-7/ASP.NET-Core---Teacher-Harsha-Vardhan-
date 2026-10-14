/*
Here is the question.
If the same incoming URL matches with more than one route, then which route will be picked up?
Either the first one or second one.

The answer is it should not be based on the order, but it is based on certain precedence rules.
Mainly, it follows four roles while selecting the route.

1. URL template with more segments.
.e.g "a/b/c/d" is higher than "a/b/c"

2. URL template with literal text has more precedence than a parameter segment.
e.g. "a/b" is higher than "a/{parameter}"

3. UTL template that has a parameter segment with constraints has more precedence 
than a parameter segment without constraint.
e.g. "a/{b:int} is higher than "a/{b}"

4. Catch-all parameters (**)
e.g. "a/{b}" is higher than "a/**".
** means it matches with any value.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
