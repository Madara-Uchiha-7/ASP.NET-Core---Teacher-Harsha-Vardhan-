/*
When you want to connect to other external RESTful web services from your ASP.NET 
Core web application,
you have the predefined class called HTTP Client.

So HTTPClient is a predefined class in System.NET.HTTP namespace,
which is used to send HTTP requests to server and get the response from the same.
For example, when you want to connect to a third-party or external web service,
you want to make HTTP GET, POST, PUT or DELETE requests and read the response from the same.
So for that kind of scenarios, you will use HTTP Client.

Generally, you will try to connect to external web services
when you want to read some information which is not available in your local database.
For example, you need to get the latest weather information or information from the stock market,
otherwise getting the latest news or tweets or any other external information from other sources.

Yes, your ASP.NET Core application, especially server code, acts as a client here.
That means the browser sends a request to the server
and your .NET application running on the server acts as a client.
It creates an object of the HTTPClient class.
It can send another HTTP request to external web service and eventually can get the response.


We added a controller.
Right click on the project and add a folder:Views
In that add a new Folder : Shared
On this "Shared" right click -> Add -> Razor Component -> Razor Layout -> _Layout.cshtml

Goto 
https://cdnjs.com/libraries/font-awesome

Locate : https://cdnjs.cloudflare.com/ajax/libs/font-awesome/7.3.0/css/all.min.css

We copied the link tag from this and pasted it in the 
head tag after title tag in _Layout.html

So you are now eligible to use Font Awesome icons.
 
We added more needed code in the _Layout.cshtml

Then we added the .css file.

Then we added the path of this .css file into the _Layout.cshtml head tag.

Now lets make this file a default layout, 
right click on the view folder, add -> razor component -> Razor View Start : _ViewStart.cshtml

In that we added the path :
Layout = "~/Views/Shared/_Layout.cshtml";

Now, in controller, right click on the Index method, 
add view, Razor view empty -> Index.cshtml

Add the code into that file. I have added the comment for the part 1.

Lets make the HTTP client service available on your application.
So we have to add that HTTP client service as a part of your services collection.

So we added :
builder.Services.AddHttpClient();

Now a predefined service called HTTP client is available.

Goto finhub.io
Click on Get free api key or click on register.
Click on : Get free api key
Register your name,
email and some password.
Once you sign up, you will get the key.
This key, we will be using in our FinnhubService.cs

Create a new Folder : Services

Add a class in it: MyService (We will rename later) : Renammed to FinnService 
So my goal here is that in this particular MyService I would like to use that HTTP client.

Check the comments and in the Services class.

On"finhub.io",
goto documenatation,
Scroll down the left pannel and go to stock Pricce -> Quote

In sample code they have given the code, select cURL from language dropdown.
Copy it, 
paste it in the Service URL parameter area in Services File.

Read all the comments in the Services file.

Then create a folder called Models add a class in it.
Class name "Stock.cs"
Check the code and 
check the HomeController Code.

Added a code in index.cshtml

Then run the app.

In HttpClient class we have
Properties:
BaseAddress
DefaultRequestHeaders

Methods:
GetAsync()
PostAsync()
PutAsync()
DeleteAsync()
*/

using _159._Http_Client___Part_1_2_3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddScoped<FinnhubService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
