///
///
/// You are able to experience all the websites through internet that is all through http protocol.
/// It stands for hypertext transfer protocol and it is a protocol means set of rules
/// that enables the browsers to send request and servers to respond to the same means client
/// or the browsers send request to server and those servers receive that request and can send the response back to the
/// browser.
/// 
/// All the websites on internet use http protocol with or without SSL (security socket layer)
/// http protocol with SSL certificates are called as https protocol which is basically http protocol with a
/// security layer.
/// 
/// It is actually developed by tim berners-lee in 1990s and later it is standardized by IETF 
/// and W3C (Word Wide Web Consortium)
/// so that everyone in the world can use it.
/// 
/// 
/// 
/// 
/// When you run the application, the browser send request to server but in the form of http request.
/// That request will be reveived by our http server called kestrel which is also called as the application server.
/// Then it invokes the main application code which we wrote.
///                      ________________________     _______________________________________________   
///      		         |                      |     |					  	                        |
/// 		             | Internet             |     |  ASP.NET Core Application		       	    |
///                      |                      |     |   _____________        ____________________	|
///                      | Http request ------> |     |   |           |        |                  |	|
/// Browser  <---HTTP--->|			            |<----|-->|  Kestrel  |<------>| Application Code |	|
/// 		             | HTTP response <----- |     |   |___________|        |__________________|	| 	
/// 	                 |______________________|     |_____________________________________________|
///
/// 
/// So, below 4 lines of code which is created when we create this project,
/// will executes upon receiving the request from the kestrel.
/// 
/// app.MapGet("/", () => "Hello World!");
/// Upon receiving the request at the root level i.e. "/" also means means localhost port number.
/// then this string value will be sent as response back to the browser.
/// 
/// 
/// Since http is the default protocol in all the browsers that is generally hidden in the browser url area.
/// 
/// You can also see the network requests in the browser developer tools.
/// In order to open the developer tools on the browser, right click on the browser once you run the project.
/// Then select inspect. Then select network tab.
/// Network is the place where you can see all the requests.
/// So, if you press refresh button on the browser, you will see the request in the network tab.
/// 
/// It is the request that is sent. Above there is the show overview, it is the timeline. You can untick that box,
/// we do not need to see timeline in our case. To untick the box, click on setting symbol and 
/// untick the overview.

/// Now, in name column there is a name called
/// localhost, this is the request that is sent to http localhost and if you click on that
/// you can see more details.
/// 
/// It shows the url, method of the request which is GET in our case.
/// The status code. 
/// You can see the response headers and request headers as well.
/// 
///


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
