/*
http response headers are the key value
pairs that are sent by the server to the client.
Generally it includes the information about the response itself
indicating the type of the response
and how it should be stored and managed in the client.

Generally these response headers are not visible to the end user but intended only for the information
exchange between the server and client.

Lets see common response headers: 
Date : Indicates the date of the response.
Server : Name of the server.
Content-Type : Indicates the mime type of the response body. That means it indicates what type of response we are going to send from the
               server to the client. Suppose the server wants send plain text as response. Then the content type will be assigned
               as text/plain in the response header. Similarly if the server wants to send the response as html code
               that means a web page then the content type will be text/html. Similarly for sending the json data
               content type will be application/json. For xml data content type will be application/xml. 
               Generally we use either of these in web api controllers.
Content-Length : This key's value will be assigned automatically by the kestrel. It depends on the length of the response
                 body. This value indicates the number of bytes
Cache-Control : This indicates how the browser should cache the response body in the memory. In case of cache control equal to no-cache
                then it indicates the browser that; hey browser don't store this response body in the cache memory; means temporary
                memory. In case if the response body is cached by the browser when making the request to the same url
                next time, instead of freshly fetching the data it can be easily retrieved from the cache memory itself.
                In case if you want to enable the cache for this particular response you will specify the number of seconds to
                cache, for example you will say max-age=60, that indicates up to 60 seconds the
                response can be cached in the browser memory. So within that 60 seconds if the browser
                wish to send one more request to the same url, it need not download the response body one more time freshly.

Set-Cookie   :  We will use the set-cookie response header to set the cookies. It enables the browser to store a cookie
                value in the browser memory itself. Means the servers can send the cookies to the browser.
                So the cookies are stored in the browser itself. 
Access-Control-Allow-Origin : 
                For CORS - that is cross origin resource sharing, access-control allow-origin header can be used.
Location : While redirection from one url to another url we use the "location" header.

For more headers: https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Headers
 
How to send response headers from the asp.net core app.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // Below is the way to access the response object using the context object.
    // There you have a property called Headers. It is of collection type which implements IHeaderDictionary.
    // So it is fundamentally a dictionary key value pairs.
    // So you can add, remove or clear any kind of response headers through this collection.
    // Value should be of string type only. 
    context.Response.Headers["MyKey"] = "My Value";
    // When the browser actually sends a request asp.net core sends this key value pair
    // as response header to the browser.
    // Run the application.
    // Go to inspect -> Network -> reload the page -> Headers -> Response Header -> You will see the key value pair we added above.
    // In general keys should not contain any space.

    // Lets say we want to add html content in your response.
    // E.g. "Hello" in H1 and "world" in h2.
    // Then, we need to inform the browser that we trying to give html content.
    // So, parse the html and display the same accordingly.
    // For that we need to add the response header.
    // Then this response header will be read by the browser. and understand that okay this is the
    // html code and it displays the same as headings.
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h2>");
    await context.Response.WriteAsync("<h2>World</h2>");
    // Above 2 html responses, you can see them also in:
    // Network tabs' response column.
});

app.Run();
