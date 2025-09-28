/*
Http request is a message that is sent from the browser to server.
It has a basic format:

Method      Url     HTTP/1.1                    :       Start Line

Key:    Value                                   :       Request Headers
Key:    Value
                                                :       Empty Line

...                                             :       Request Body
...


This above format is automatically prepared by the browser and will be received by the server.
The request start line contains the method and url and http version.
The request methods are the type of the requests.
Sometimes the browser seeks the information, sometimes the browser sends the information.
So to represent appropriate intention of the request different methods are defined : get, post.
There are some other type of requests also such as put and delete.
Then:
The url is used to locate the particular information on the server.
For example there is a website something like udemy.com. If you want to see the courses page
then the url will be /courses.
Then:
Http version, it can be 1, 2 or 3.
By default it is http 1.1. We can change this using our code.

Request headers:
These also key value pairs much like response headers.
The difference is it is in opposite direction.
The request headers are sent from browser to server, whereas response headers are sent from
server to browser.

Request Body:
It is the actual information that browser wants to send to server.

The biggest difference between get and post is that,
in case of get request request body will not be there. 
Whereas the post request would contain request body.

If Start line is:
GET / HTTP/1.1
then the first forward slash is equal into localhost:6734 that is the port number.
But if your url is different like:
localhost:6734/hello
Then start line will be:
GET /hello HTTP/1.1
It shows the url after the url.

By default the chrome doesn't show the request body but the original request would contain request body.

Once the request is received by server, it passess that information to asp.net core.
Then asp.net core automatically prepares a context object which contains all the details of the request including the request start line
and headers and request body

So, we can find the request details in the the context object in code.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // .Path : Gives the request URL that is present in the request start line.
    string path = context.Request.Path;

    // .Method : Gives the method name.

    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync("<h2>World</h2>");
});

app.Run();
