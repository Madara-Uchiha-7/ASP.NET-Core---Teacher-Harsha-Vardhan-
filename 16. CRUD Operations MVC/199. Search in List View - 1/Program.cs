/*
In the index.cshtml
We will add a search area.

The values for dropdown, we are supplying from PersonController.
For that we have added the ViewBag in the PersonController whcih we can read directly in the 
Index view.

After clicking on the search button:
Now what happens exactly when the user clicks on the search button?
In order to make the page interactive, when the user clicks on the search button,
you can post data which user has added in the search area to a server.
That means when the user clicks on this search button, 
the browser makes either GET request or POST request to the server.
In case of search form or any kind of query that you can retrieve the data from the server,
for that purpose, you can use the GET request.
But for inserting, updating, for this kind of modification operations,
you can use the POST request.
So you can use GET or POST, two types of requests in the form.

Since we are creating the form for the search purpose, we can use the GET request.

So, our Index view's form tag has a get request.
It has a action attribute also, which tells him where to go i.e. the url
which is present in our Route in the HomeController.
Note how form tag covers whole page.

You can submit the form data as X-WWW form URL encoded.
The Browser has to collect the values from the inserted data.
In order to make your form element eligible for that, your form element must contain the name.
With this name only, the value will be submitted. So for that, we have mentioned this select tag name as searchBy.
The selected value from the dropdown will go into searchBy.

We have given name attribute to the area where user will type the value after he 
selects the some input from dropdown.
We have given "searchString" to that name attribute.

Now value will go as below:
E.g. 
searchBy=Name&searchString=abc

Like this, a query string will be generated automatically
based on the values that are entered or selected by the user.
This will be received by the action method.

This is the reason our Index action method has the parameters.
Note: The action method parameter names and the name attribute value should match.
So, our parameter names in this case will be 
searchBy and searchString



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
