/*
In last lecture we sent the request using the Postman.
It was the GET request.

So how can you make the post request in postman.

In the place of GET select POST in postman.

But whats the diff in GET and POST.
So the difference is in the intention as well as the request message format
and what happens on the server.


Get:
Request Type	        Description
GET	                    Requests to retrieve information (e.g., page, entity object, or static file).
POST	                Sends an entity object to the server. Generally inserted into the database.
PUT	                    Sends an entity object to the server. Generally updates all properties (Full update) in the database.
PATCH	                Sends an entity object to the server. Generally updates few properties (Partial update) in the database.
DELETE	                Requests to delete the entity in the database.


It doesn't mean that in get request we don't send information.
See for example
We want all the info of the course whose id = 1.
We can pass id = 1 using get request and we will receive all the information from the server about the course.

The post request e.g. can be a registration form which will be inputed in the database.
Then server sends back the response as "Saved Successfully" or etc.

In case of get request the request body is empty but in case of post request the request
body contains some information.
This request body may be in the form of xml or json or a query string or any other type of information.

In postman,
if you have select the post in the place of get,
then if you go to the body column of requst and select raw, 
you can write any raw information which may include in the request body.
For e.g.
Hello
Then this Hello message will be sent as request body to the server.

In that requst's body tab
there are:
1. form-data
2. x-www-form-urlencoded (Query string data)
3. raw (either normal message or json data or xml data)
These are the general commonly using request body types.
If you select raw:
then there will be dropdown at the end.
This drop down will allow us to select Json or xml or normal text.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
