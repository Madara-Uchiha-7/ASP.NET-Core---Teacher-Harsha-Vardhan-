/*
Sometimes you would like to read the request headers as a part of the model binding.

HTTP Request -> Model Binding 
                ----------------------------------------------|
                |Request     Header Name : Value -> Parameter |
                |Headers                                      |   --> Arguments to action method parameters -> Controller (Action)
                |                                             |
                |                                             |
                _______________________________________________


Right now we are reading the inputs from request, that is either from the form fields or request body, that
means either JSON or XML, or from the router data or from query string. Lastly, from the request headers also you can receive the values.

The traditional way to read the request headers is, you can write like ControllerContext.HttpContext.Request.Headers["keyName"]
in action method.

But instead of this lengthy approach, you can take the advantage of the model binding.

You can simply declare a string type of parameter and you can apply an attribute for the same,
that is from header in the action method parameter:->
public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
Name = "User-Agent" is the key of which value you want. The value will be stored in UserAgent
This contains the details of current working browser.

Run the code from VS and add /register in url to hit the Action method.
These Headers are present in  Inspect Mode -> Network -> Headers -> Request Headers.

If error comes and you are printing the Headers i.e. UserAgent in this case, on the browser,
then only error is shown, not the UserAgent value.
Because in case of model validations, we are sending the bad request response, not the content result in which 
you are printing the UserAgent.
*/

using _79._FromHeader.CustomModelBinders;

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
