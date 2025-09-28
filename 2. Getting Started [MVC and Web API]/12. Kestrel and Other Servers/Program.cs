/// asp.net core applications require a server in order to receive the request and send the response.
/// kestrel is the default cross platform http server for asp.net core applications.

/// it acts as both development server as well as real application server which is able to receive the request
/// from real internet.

/// however most of the cases in the real world you will use the kestrel as an
/// application server and development server only.
/// and in production you will be using Reverse proxy servers.
/// meaning is that during development the developers use kestrel as a development server
/// meaning you will be writing some asp.net core code and you will be testing and running the
/// application by using the default server called kestrel.

/// and after completion of the development you require to push the code into the
/// production server which can receive the request from the internet anywhere in the world.

/// so there the kestrel act as an application server and you will be using reverse proxy
/// servers such as IIS, nginx or apache any one of these.

/// the architecture look like this. 

/// With only kestrel the http request will be received from local network or internet.
/// The kestrel will receive that request and it will forward that request to application code.
/// The kestrel will receive the request and fills the information in the form of
/// an object and that object is called as http context.
/// So the kestrel prepares a http context object which contains the details of the request
/// and sends that http context to the application code.
/// So that the application code can receive that context and can process based on that
/// and can provide the response or result back to the kestrel then the kestrel sends the same response
/// back to the internet or the client.
/// So this is the general process that happens with kestrel.
/// But kestrel doesn't support some of the advanced features that are required on internet in these days
/// for example load balancing, url rewriting this type of features are required or expected in these days on production.
/// servers.
/// Most of the websites today use a reverse proxy server.
/// Meaning is that the actual request from the client will be received by a reverse proxy server
/// such as IIS, nginx or apache and these reverse proxy servers offer some of the advanced features on
/// internet
/// Such as : load balancing, url rewriting, authentication, caching, Decompressing the request,
/// Decryption of SSSL Certificates.
/// And these servers transfer the same request to the actual application server that is kestrel.


///                   ________________________________________________
///                   |                                              |
/// 		          | ASP.NET Core Application		       	     |
///                   |   _____________        ____________________  |
///                   |   |           |        |                  |  |
/// Internet <---HTTP-|-->|  Kestrel  |<------>| Application Code |  |
/// 		          |   |___________|        |__________________|  | 	
/// 	              | _____________________________________________|



/// So, in most of the production scenarios weprefer a reverse proxy servers because of these advanced features.
/// and that reverse proxy server will transfer the request to the kestrel. and then as usual the kestrel receives
/// the request and prepares http context and that context object contains the details of the request
/// such as request body or request headers or the session or cookies etc. and then the application code receives
/// the request along with the context and can execute some code and can provide the response back to the kestrel.
/// and the kestrel as usual sends the same response back to the reverse proxy server.
/// and then the same response will be sent back to the actual client who sends the request.


///                      ________________________     _______________________________________________   
///      		         |                      |     |					  	                        |
/// 		             | Reverse Proxy server |     |  ASP.NET Core Application		       	    |
///                      |                      |     |   _____________        ____________________	|
///                      | IIS / Nginx/ Apache  |     |   |           |        |                  |	|
/// Internet <---HTTP--->|			            |<----|-->|  Kestrel  |<------>| Application Code |	|
/// 		             |                      |     |   |___________|        |__________________|	| 	
/// 	                 |______________________|     |_____________________________________________|




/// In addition to this you can simulate the features of reverse proxy server during development as well
/// by using a dummy reverse proxy server called IIS express.
/// IIS express simulates IIS means it acts as a reverse proxy server which can receive the request and
/// forward the same to kestrel of course during development it is just an option whether to use IIS express or not.
/// Both IIS express and actual IIS both are supported by windows operating system only.
/// nginx, apache are supported by linux mainly of course by windows as well.
/// So this is the overview of the servers that we are going to use in asp.net core applications.

/// But where is the kestrel can we see that?
/// See by default when you try to run this application, it automatically opens up the browser
/// such as chrome or firefox whatever and sends the request and our application receives that
/// request and provides the response that is hello world.

/// But before this thing happens means before the browser can send request internally on the terminal the kestrel
/// server has been opened.
/// You can see that on the terminal which will also open with browser when you run the project.
/// This terminal window indicates the kestrel server.
/// This is the default log that was generated by the kestrel server.
/// As soon as the application execution starts the kestrel automatically kicks in.
/// and by default that kestrel server gets started.
/// so that your application is available to receive the request.
/// Then only the chrome like browsers can send request and of course you will get the response
/// accordingly.

/// Copy the url which is in the browser when you run the project.
/// Now, if try close the terminal, server will stop.
/// Now open the browser and paste the same URL in the browser and press enter and it will not work.


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
