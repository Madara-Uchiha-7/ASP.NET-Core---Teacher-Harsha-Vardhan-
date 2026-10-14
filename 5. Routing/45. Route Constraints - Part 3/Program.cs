/*
alpha: Requires the parameter value to consist only of alphabetic characters (a-z, A-Z).

range : Matches with an integer value between the specified minimum and
maximum values (both numbers including)
E.g. age:range(18,100) : matches with 18, 19, 100

regex: Requires the parameter value to match a regular expression pattern.
Regular expression is a pattern where you can write the set of rules, or the format or pattern that
you would like to accept.
See the e.g.: "sales-report/......

But in general as per Microsoft Docs, you should not use the constraints to validate the values.
Use if-else and return the error status if needed.
That is why in the real world, projects do not use the constraints in order to validate the values.

So depending on the situation, if you feel the constraints are more suitable, you can use the constraints.
Or if you feel giving the meaningful responses is more meaningful and more suitable for the
client, use if-else way.

--------- For string characters:
length: Matches with a string that has number of characters between minimum and
maximum length (both numbers including)
{username:length(4,7)}

minlength(value):
Matches with a string that has at least specified number of characters.
{username:minlength(7)}

maxlength(value):
Matches with a string that has less than or equal to the specified number of 
characters.
{username:maxlength(7)}


You can write the default values with constraint.
You should write the constraints first and then default value at last.
e.g. {name:minlength(3)=Scott}

We can add more than one constraint using the seperator :

Check the file/ endpoint as the example.

--------- For numbers:
length: Matches with a string that has exactly specified number of characters.
{username:length(9)} : matches with 987654321
 
min(value):
Matches with an integer value that greater than or equal to the specified value.
{username:min(18)} : matches with 18, 19, 200

max(value):
Matches with an integer value that less than or equal to the specified value.
{username:max(100)} : matches with -1, 1, 6, 100
---------------------------------------------------------------------------------------


To accept only the alphabates with length example:
{employeeName:length(5, 10):alpha=Scott}
*/
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// In below, I am using 2 constraints on the fileName and
// 1 on the extensionName. Now if I add the url as
// /file/tesssssssssst.t       : both constrints failed
// or /file/teeeeeeeeeee.txt   : only 1st constrint failed
// Then code does not go to the .MapFallback()
// But if I add only one route parameter and add the lenght(7) to only that
// route parameter and if I give tteeeeeeeessssssttt then .MapFallback() 
// will be called. Why?????
app.Map(
    "file/{fileName:minlength(3):maxlength(7)=Test}.{extensionName:minlength(3)}",
    async (HttpContext context) =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? extensionName = Convert.ToString(context.Request.RouteValues["extensionName"]);

        await context.Response.WriteAsync($" In the file {fileName}.{extensionName}");
    }
    );



// Regex :
// We will accept the Year.
// It should be integer value and it should be four digit number minimum of 1900.
// And we are accepting only few months. We have four reports per year.
// That is in the months of April, July, October and January.
// Begin regex with ^ and end the value by $
// So in between you can write the set of values that you want to accept by separating with pipe symbol
app.Map(
    "sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}",
    async (HttpContext context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($" In the {month}.{year}");
    }
    );

app.MapFallback(async (context) =>
{
    string url = context.Request.Path;
    if (url.Contains("file"))
    {
        await context.Response.WriteAsync($"Wrong file name.");
    }
    else
    {
        url = context.Request.GetDisplayUrl();
        await context.Response.WriteAsync($"You are at Default : {url}  Url.");
    }
});

app.Run();

// Use of - in url is common. It is better approch than making 1st character 
// capital from second connecting word.
// Using the hyphens in the URL also works well with search engines such as Google.




/*
My question :
MapFallback() does not work for more that 1 constraint...:->
I am using 2 constraints on the fileName and
// 1 on the extensionName. Now if I add the url as
// /file/tesssssssssst.t       : both constrints failed
// or /file/teeeeeeeeeee.txt   : only 1st constrint failed
// Then code does not go to the .MapFallback()
// But if I add only one route parameter and add the lenght(7) to only that
// route parameter and if I give tteeeeeeeessssssttt then .MapFallback() 
// will be called. Why?????

Teacher ans:
It didn’t hit MapFallback because the default fallback route is "{*path:nonfile}". 
That nonfile constraint skips any URL that 
looks like a file (has a dot in the last segment), so /file/eeeetesteeeee.t is excluded. 
Your first route failed due to constraints, then the fallback also refused the match, so the pipeline returned a 404.



If you want the fallback to catch “file-like” URLs too, map it with your own pattern, 
for example app.MapFallback("{*path}", ctx => …), and it will run even when the URL 
contains a dot.
*/