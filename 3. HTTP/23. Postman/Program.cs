/*
Postman is a third-party tool which helps the developers to test our asp.net core applications
and also web api controllers.
That means through this tool you can make requests and read the responses
and can investigate almost everything.

For example you can investigate the response headers, response body
and response status code and you can send different types of request body.
For example you can send the form-data json-data or xml-data or else any type of data as request.

So it gives you full control over the request and response than the browsers.
So in order to work with that you
require to download and install the Postman on your machine.

Go to postman.com.
Download.

Install it.

Sign in is not compulsory.

Teacher version : 9.13

Ctl + 
To zoom in in postman.

Click on plus button to make a new tab.
Here you can make the request.

Copy this project localhost url and paste it into the url area of postman.
Click on send.

In Postman:
In the top headers tab you can see the request headers.
In the bottom headers tab you can see the response headers.


Bottom body tab is Response body.

One of the benefits of this postman is, it allows you to add your own key value
pairs as request headers where in the browser you cannot.

So, add any key and value in the top headers tab in postman.
Grab that key in this current program.
I am using 
Key : TestKey
Value : TestValue.

Run this application in VS.
Send the request again using postman.
You will see response status as 200.
Also in body, you will see the value.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    if (context.Request.Headers.ContainsKey("TestKey"))
    {
        string? testKeyValue = context.Request.Headers["TestKey"];
        await context.Response.WriteAsync($"<p>{testKeyValue}</p>");
    }
    else
    {
        await context.Response.WriteAsync($"<p>hello word</p>");
    }
});

app.Run();
