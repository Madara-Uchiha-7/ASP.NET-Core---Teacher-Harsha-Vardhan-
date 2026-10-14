/*
So far in model binding, we have seen the form fields, route data, and query string parameters.
Form fields are two types, either form URL encoded or form data.
We have already seen that in the earlier lectures in the same section.
But there are some other content types other than the form data and form URL encoded.
For example, you have application by JSON, application by CSV means comma separated values,
or application by XML. So for such type of content types, you have to consider using request body. 
Of course, the content types such as form URL encoded and form data also will be actually sent as a part of the request body.
But that is not called as the request body model binding.
Those are treated as form fields. Because by default, HTML forms use either 
form URL encoded or multi-part form data. So those are called form fields.
Here, the request body model binding is either application by JSON or application by XML
or a custom format. So when you want to receive the JSON data or XML data mainly,
you have to use the from body attribute for your model parameter in the action method.
So that it enables the input formatters to parse the request body into the specified model object.
For example, the JSON data or XML data can be converted into the model object.

For example, Index action method receives a model object as person.

Goto postman 
use action GET
Select Body -> raw
From dropdown Text -> select JSON
In ASP.NET Core, JSON input for methods already have been added. So you need not explicitly enable them.
Send :
{
    "PersonName" : "Chinmay",
    "Email" : "wow@wow.com",
    "Phone" : "1000000000",
    "DateOfBirth : "2000-01-01",
    "Age" : 10,
    "FromDate" : "2030-01-01",
    "ToDate" : "2032-12-31",
    "Tags" : ["Tag1", "Tag2", "Tag2"],
    "Password" : "123",
    "ConfirmPassword" : "123"
}

Add the Attribute before the Person which you are using in Controller class.
Check that class.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
