///
///
/// Lets see the HTTP responses from HTTP protocol.
/// Run the project.
/// Open the developer tools.
/// Go to network tab.
/// Refresh the browser.
/// Click on the localhost in the name column.
/// 
/// In General:
/// Status Code is 200, it means success.
/// 
/// Check response headers.
/// This is the actual response message that was sent by the kestrel to this browser.
/// So when this chrome browser makes a request, the kestrel has prepared a response in this format.
/// And the same has been received by this chrome.
/// As you can see these are key-value pairs.
/// 
/// Based on these http headers the browsers can understand how the actual response has to be treated or displayed on the
/// actual output.
/// 
/// Response Body:
/// Response body is the actual information or content that is given from server to browser.
/// In our case, as per the code, we are giving this "hello world" as response.
/// So the same is called as response body.
/// This actual string value is called as response body in our current example.
/// But most of the real-time cases it will be either file content such as image file or something or maybe a html code.
/// It will look for e.g.:
/// <html>
/// <head></head>
/// <body>Web Page</body>
/// </html>
/// 
/// According to the teacher
/// HTTP Response will have 
/// 
/// Strat Line : 
/// Will have, for e.g.
/// HTTP/1.1  StatusCode StatusDescription
/// 
/// 1.1 is the HTTP version. It can be 2 or 3 also.
/// 
/// Response header:
/// Will be a key value pairs on each new line.
/// Response body:
/// E.g:
/// <html>
/// <head></head>
/// <body>Web Page</body>
/// </html>
/// 
/// In my chrome browser I only has Response hreader i.e. key value pairs in HTTP response.
///



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
