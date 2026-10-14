/*
In ASP.NET Core, Model is a class that represents the structure of the data that you would
like to receive from the request and also send the response back to the browser.
That means the action method can receive the data in the form of Model object as a parameter
and also optionally can return the Model object as a response.
But we will focus on sending part later.
In this case, the role of the Model binding is that first it fetches all the values from
the form data, request body, route data, and query string and if and if that action method has
a parameter of the Model class type, it automatically creates an object of the Model class and
adds all the values from the request into the properties of the Model object.
Then that Model object reference will be received as an argument in the action method.
Right click on the project -> Add new Folder "Models" 
Right click on the "Models" -> Add -> New Item -> Under Visual C# select Class and give name "Book.cs"
Lets go in our controller class.
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

// My question
/*
How does it know that which Route Parameter is related to which Property of the Model class.
E.g. If I have UserFirstName and UserLastName and UserFatherName properties in the Model class.

Now, from URL, lets say I skip the middle one i.e. UserLastName then, how will it know to map name 
to the Father and not to the UserLastName???

ANS :
It does not guess by position.

ASP.NET Core model binding maps values by name matching, not “1st segment → 1st property”.

So it will bind only when the route/query key matches the property name.



Example:

If your route is:
/users/{UserFirstName}/{UserLastName}/{UserFatherName}

and you call:
/users/John/Smith/David

it maps correctly.



But if you “skip” last name like:
/users/John/David

then ASP.NET Core will treat David as UserLastName, not FatherName, because the 2nd segment is still {UserLastName}.



If you want skipping to work, you must pass values by name, like query string:
/users?UserFirstName=John&UserFatherName=David

or make route parameters optional and handle nulls.
*/
