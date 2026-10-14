/*
Sometimes, you would like to invoke the view component programmatically through JavaScript
by making an asynchronous request. Means, you want a view to 
load normally without view component.
on demand, for example, when the user clicks on a button, 
then only the view component should be
invoked. It is possible by returning the view 
component result from the controller action method. 

So, similar to the partial view result in the last section, 
from a controller action method,
you can return the view component result. 

That means, within the view, there is a button,
for example, when the user clicks on a button, 
the browser makes an asynchronous request through
the JavaScript fetch API or through XMLHttpRequest object. 
Of course, fetch request is the modern
code, which is newly introduced in JavaScript. 
So, when the browser makes an asynchronous request,
the controller action method execution starts.
And of course, as a part of the action method,
you can create a model object, for example, and then you will invoke a 
view component by returning
the view component result from this action method. 
Then the view component executes.
It receives the model object that is supplied from the action method.
And after rendering the UI, the rendered UI will be added as a response body
and will be sent as HTTP status 200 with content type text by HTML.
So, this particular response body is equal to the rendered content of the view component.

So, this response body will be received by the JavaScript code because it has originally
sent the request. Then in the view, you will write the JavaScript code to display the response
in the output, in the actual page.



In home controller we have added the action method which will be 
called from Index view.

We have kept the friends.js in wwwroot folder, because it is a 
static content.
CSS files, JS files, images etc comes here.

In home controller,
we are passing the data to the Grid Component,
for that we used
new
{
    viewPersonGridModel = personGridModel
}
Here also like last lectures you will see that 
we are using:
"viewPersonGridModel" which is the same name as the 
parameter in the Grid Component. 
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();