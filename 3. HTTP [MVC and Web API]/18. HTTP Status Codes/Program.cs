
///
///
/// Status codes are sent from server to browser.
/// To indicate the status of the response, e.g. the response status code 101 indicates "switching protocols".
/// For example we are switching from http protocol to https.
/// 
/// and this 200 is the default status code in most of the cases.
/// So if the process has been completed successfully that indicates 200 response.
/// 
/// Similarly you also have 302 that means "Found".
/// That indicates redirection from one url to another url.
/// E.g. we are sending the request to 
/// the url called "/view-courses" and the same has been forwarded to "/courses/view".
/// This means url called  /view-courses is found and now we are redirectring to another url "/courses/view".
/// 
/// This type of response is represented as 302.
/// 
/// 
/// 304 means "Not modified".
/// That means the file is already available on the browser cache such as image or
/// html file or css file, so the browser can use the same file from the cache. 
/// It generally happens with the static files such as images.
/// but alternatively if that file has been modified on the server, then the fresh file will be sent to the
/// browser then it is called as 200 response as usual.
/// 
/// 400 that is "bad request".
/// That indicates some of the data that is sent as a part of the request is incorrect
/// or some necessary information is not included in the request.
/// For example there is a page that shows a particular course on the udemy but the course id is not supplied,
/// so it is the bad request.
/// 
/// 401 unauthorized.
/// That means as you can guess it is the authorization issue.
/// That means any one of the user credentials such as username or email or OTP is incorrect.
/// Then it is called as 401 unauthorized.
/// 
/// 404 not found.
/// This is when we enter wrong URL.
/// 
/// 
/// 500: Internal server error:
/// Comes in case of any server side runtime error such as runtime exceptions on the code
/// it is represented as the status code 500.
/// 
/// 
/// How can you send these status codes from your code?
/// Let's try that in our code.
/// 
/// 
///




var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// In this mapGet method you cannot,
// write any code but only can return a value.
// app.MapGet("/", () => "Hello World!");

// If you want to write any piece of the code that you want to execute upon
// receiving the request, instead of the map get, you have to try using run.

// Difference between map and run is covered in another section.

// Run is the one of the preferred ways to execute some piece of the code upon receiving the request.
// In this run method, you will be passing only one argument and that will be your lambda expression.
// Of course you can also pass a method if you want.
// This particular lambda expression will be executed upon receiving the request
// and this lambda expression should receive only one argument that is context which is of type http context.
// So the HttpContext is a type of object that gets created automatically upon receiving the request.
// So when the browser sends a request to the kestrel and the kestrel forwards the same
// request to the application code to the asp.net core application then asp.net core automatically creates
// an object of type HttpContext and this context contains the information related to your request, response and many more
// other details. For eg. context.Request. or context.Response, here context is the object of class HttpContext which we are 
// taking using the parameter.
// 
app.Run(async (HttpContext context) =>
{
    // Now, we know that we have the Response property in the context. Lets use that.
    context.Response.StatusCode = 400; // It is only to send for "bad request". This 400 we added for testing here.
    // You need not give the status description, that will be automatically taken by the kestrel at the time of actual response.


    // I have added this line. In Response Header of network tab we will get 
    // Content-Type  test
    context.Response.ContentType = "test";

    // Now, in order to send actual response body you have to use WriteAsync()
    await context.Response.WriteAsync("Hello I am the response from the Program.cs");
    // If you are using any method of asynchronous with async suffix, here it is WriteAsync()
    // you have to convert that entire method as async method. So we have added the async in Run() 
    // and you have to prefix the method call with await keyword, so we added the await before : context.Response.WriteAsync

    // We can use mroe that one WriteAsync
    // Added \n so that it will not come on the same line on the browser window.
    await context.Response.WriteAsync("\nHello I am another response from the Program.cs");


    // Run the code and check network tab in browser inspect mode.
    // You will see 400 Bad Request
    // Bad Request came automatically which is given by the krestel.
});

app.Run();



/*
The Content-Type header in an HTTP response indicates the media type (also known as MIME type) of the resource being returned by the server. 
This header is crucial because it informs the client (e.g., a web browser) about the format of the data in the response body, 
allowing the client to process and render the content correctly.
Key aspects of the Content-Type header:
Format Specification:
It specifies the exact type of data, such as text/html for HTML documents, application/json for JSON data, 
image/jpeg for JPEG images, or application/pdf for PDF files. 
*/