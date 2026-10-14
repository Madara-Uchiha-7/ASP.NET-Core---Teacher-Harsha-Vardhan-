/*
The bind attribute specifies what properties you would like to include
in the model binding so that remaining properties will not be binded.

See, by default, in model binding, all the properties of the model class will be binded.
But if you mention bind and specify the list of properties that you want to bind, only these
properties will be included in the bind, but remaining will be skipped. So the benefit of this bind
attribute is that you can avoid overposting the unwanted properties. For example, in the registration form,
you have only 10 fields or 10 properties to be submitted. But some hacker or malicious website
has submitted more number of properties which are not expected. They may post some sensitive data
or unwanted data. So to avoid such issues, we use bind attribute so that only the specified properties will be
submitted. The remaining properties which are not mentioned in this bind list will be skipped, even though that is
submitted in the request.

Let's say in model person class, you would like to allow only person name, email, password and confirm password.
So in your home controller, in this action method, you can add bind attribute near this parameter and
then specify the list of properties that you want to accept. You can either mention the list
of properties with comma separation or in order to get it dynamically, you can use name of operator.

Check the contorller class action method parameter area.

When the flow will come into the controller class, in debug mode check the Person parameter,
you will the properties which are not in Bind, they will have the null value.

If you want to bind the less properties then this approch is better,
But If for e.g. there are 13 properties to bind and 2 properties to not bind then 
it is better to use [BindNever].
Now how to use it:
In the model Person class,
add [BindNever] above the property which you do not want to include.
It is present in the:
Microsoft.AspNetCore.Mvc.ModelBinding
namespace.

This also you can check in debug mode, when the flow will come in the controller class.
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
