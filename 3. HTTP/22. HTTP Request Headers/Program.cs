/*
Request headers are the key value pairs that are sent by the browser to server.
Request headers are information to the server.
Request headers are the way how the browser talks to the server.
That means for example the browser says that hey server please give me the information in
English.
Sometimes as a part of the request we have to send some information to the server.
E.g.
We are submitting a json data to the server, the same has to be informed to the server.
It can also have the information for cookies or authentication tokens etc.

Lets see some common headers: (Key - Value pair)
Accept : Represents MIME type of response content to be accepted by the client. 
         E.g. text/html i.e. hi server, please give me the response in HTML.
         It does not mean that all the servers will respect it. It is the formality of the server to respect it. but it is not guarantee.

Accept-Language : Represents natural language of response content to be accepted by the client. E.g. en-US

Below 2 are the information about the request body.

Content-Type :  MIME type of request body. 
                E.g. text/x-www-form-urlencoded, application/json, application/xml, multipart/form-data

Content-Length : Length (bytes) of request body. E.g. 100

Date : Date and time of request.

Host : Server domain name. E.g. www.example.com

User-Agent : Browser details.

Cookie : Contains cookies to send to server. E.g. x=100

Both request headers and response headers both are case insensitive.
i.e. the key in .Headers property can be in lower case also.


Is there any possibility that I can add one or more request headers as a part of the request manually.
By default this chrome browser doesn't allow that. But if you are really interested to send your own request
headers, otherwise if you would like to send post request, to make this possible you require a
third party tool called postman.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
