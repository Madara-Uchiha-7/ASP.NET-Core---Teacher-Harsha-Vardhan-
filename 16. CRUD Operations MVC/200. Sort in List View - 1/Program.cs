/*
Lets sort the column values by descending order if user clicks on the 
column.

By default on the first load, sort order will be in Ascending order for peron name. 

Notice how we have used "defaultColumnHeadUrl" variable in the index.cshtml's href attribute.


My old code was :
string defaultColumnHeadUrl = $@"persons/index?searchBy={searchByViewBagValue}&searchString={searchStringViewBagValue}";

Using Chat GPT help I fixed it to:
string defaultColumnHeadUrl = $@"/persons/index?searchBy={searchByViewBagValue}&searchString={searchStringViewBagValue}";

Why help needed?
Below issue was for above mentioned old code:

When I first click on run application the 
url will be  :
http://localhost:5255/ and at the same time
href url for lets say column Name will be created as :
/persons/index?searchBy=&searchString=&sortBy=Name&sortOrder=DESC

When you
again click on the Name column,
Your URL will become:
http://localhost:5255/persons/index?searchBy=&searchString=&sortBy=Name&sortOrder=DESC
href url for lets column Name will be created as :
/persons/index?searchBy=&searchString=&sortBy=Name&sortOrder=ASC

When you
again click on the Name column,
I was getting error as :
"No webpage was found for the web address:
http://localhost:5255/persons/persons/index?searchBy=&searchString=&sortBy=Name&sortOrder=ASC "

To Fix this we used chat gpts suggested code line.
Adding "/" at the start means we are telling browser that start from the root 
of the website.

We updated our font-awesome link:
We went to
https://cdnjs.com/libraries/font-awesome/6.1.1
and copied first link i.e.:
We copied it by clickin on the "</>"
of :
https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css



The code logic for the link of Name column which is written in @{}
is written by me.
But in next lecure there are a lot of changes done by teacher.
So for reference I am keeping this Index.cshtml changes in the
MyIndex.cshtml file.

From next lecure we will keep on using the main Index.cshtml file.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
