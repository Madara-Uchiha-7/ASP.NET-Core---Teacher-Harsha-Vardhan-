/*
The options pattern is all about specifying the
exact properties that you want to read from
the configuration.

For example, in your configuration source, you have
more than 10 properties, means more than 10
key-value pairs, but you would like to
exactly require only one or two of them.

So specifying the same as a class properties
is called as options pattern.
In order to implement this, you will be
creating a model class with the same properties,
same name as the key.
So only the values of those particular keys
will be loaded into these properties, remaining or not.

For example, let's say in your configuration, you
have connection strings, client ID, client API key,
and many more other details.
Then if we can create a model class
and specify the properties that you want to
read, only those exact properties will be read,
others will not.

This is called options pattern.

For this you need to create a normal C# class called as the Option class that contains the 
public properties.
It should be a non-abstract class with a parameter-less constructor.
And all the properties should be read-write properties and public.
Fields are not bound.
Means even though you have created one or more fields in your options class, those will
be ignored.

I have created a folder for that class and added a class, please check the code in it also.
Then we added a code in HomeController.cs, check it also.
*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
