/*
Query string is a syntax where you can send the parameter values from the
request to the server. Means from the browser to server along with the request.

Lets say there is Start line:
GET /dashboard?id=1 HTTP/1.1
/dashboard is the request url path, so ignore it.
id=1 is the query string.
To separate between the path and query string there is question mark.
It is the key value pair seperated with =
E.g. there is a page that shows the specific cource on udemy.
Then that page number will go in this format. Either by course id or its name.
This format is when request type is of GET. 

In case of POST, the query string will not be present in this url.
But instead the same gets present in the request body.

To send more than one key value pair, seperate them using &
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) => 
{
    context.Response.Headers["Content-Type"] = "text/html";

    // Read the query string if the requst is GET
    // Its in the .Query property.
    // Upon receiving the request asp.net core
    // will read all the query string parameters which are part of the url
    // and those key value pairs will be
    // available in this Request.Query property.
    // It is IQuery collection type, means it is a kind of dictionary.
    // We will check if it contains a specific key.
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string? id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>");
        }
    }
    // Run the app.
    // In url, after the port number, add the ?id=7&name=john
    // Press enter.
    // Now, we are sending the id key which will be grabbed by the above if condition.
    // Then in network tab, in response, you will see <h1>7</h1> which is the response we are sending 
    // using WriteAsync
});

app.Run();

// In the real world applications upon receiving the query string value such as id
// you will retrieve the relevant information from the database.
// There is another way of receiving the argument values, that is through routing.
// So query string and routing are two different ways to get the values from the browser to server.