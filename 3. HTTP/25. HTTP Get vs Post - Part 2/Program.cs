/*
Lets read the request body using code.
We can do that using .Body property.
We are passing "context.Request.Body" to StreamReader constructor
because we need a StreamReader type of object, that is based on "context.Request.Body" stream.

You can add a breakpoint on the "string body...." line.
Then run the app 
(when you will run the app, the breakpoint will be triggered 2 times because
chrome by default makes 2 requests initially. The second one is for favorite icon.)
and then send request using Postman
with request body "Hello" and make the request as POST. 
To send hello you need to add Hello
in requst body of postman. 
Once you select the body, 
select the raw from checkbox and Test from dropdown (Dropdown will appear
once you select the raw option).

In debug mode you will see, we will get "Hello" in body variable.

In most of the cases, the request body is either form-data
or url-encoded-form or raw format (means either json or xml data).

Lets send query string in raw format.
Send:
firstName=John&age=20

As you can see there is no space and we are using & to seperate the key value pairs.
Also this is nothing but we added in the url last time.
So, only difference is, instead of appending it to the url we added it into the request body.

In APS.CORE there is a pre defined class which can convert the 
query string's string format to dictionary format.

Class name is QueryHelpers.
It is in:
using Microsoft.AspNetCore.WebUtilities;

It has a static method called ParstQuery().

The return type will be :
Dictionary<string,StringValues>

The StringValues is present in the:
using Microsoft.Extensions.Primitives;

Why its not Dictionary<string, string> 
because here is a possibility of adding duplicate values for the same key.
E.g.
If we pass : firstName=John&age=20&age=30.
So here we are pasing age 2 times.
Then key is age but it has now 2 values.
So, StringValues will hold both of them.
*/

using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    // If we are passing the query string from the postman, we get it in the string format.
    // So, our body variable holds the query string into a string type.
    // Lets convert it into the dictionary. 
    Dictionary<string,StringValues> queryDict =   QueryHelpers.ParseQuery(body); 

    if (queryDict.ContainsKey("firstName"))
    {
        // Since key's value is of type StringValues, we will get 
        // it using index, so that we get the string.
        string? firstName = queryDict["firstName"][0];

        // To get all of them, use foreach
        // You can pass firstName=John&firstName=Chinmay to check this.

        List<string> allNamesList = new List<string>();
        foreach (string? allNames in queryDict["firstName"])
        {
            allNamesList.Add(allNames!);
        }
    }
});

app.Run();
