/*
From the controller action method, we can write a statement called return View();

Similarly we can return the ParticalViewResult.

This is done when Asynchronous request is made from the browser.

In JS, we can send a Async Request using XMLHttpRequest or Fetch API in JS.
So in that case, the controller action method receives the asynchronous 
request from the browser, then create a model object, and pass that
model object to the partial view by writing a statement return ParticalViewResult.

Then the partial view executes on the server-side. 
In the partial view, there can be server-side code, means C -sharp code.
So all that C-sharp code executes on the server-side itself. But the actual HTML code of
the partial view will be sent as a response to the browser. Means the executed content of the
partial view will be added in the response body, and the content type will be set as text
by HTML automatically.

Overall, from your browser perspective, you are making an asynchronous request
and is able to load the information from the server asynchronously in background without
refreshing the full page.

Lets load the list of countries or other list, when we click on the button only.
For this we created another action method. From here we will return the ParticalViewResult.
1st argument will have the name of the partial View in which you want to show the content.

This PartialView() method which we are returning is just a another way to return ParticalViewResult.
PartialView() method has 4 types.
In 4 th we pass the View Name and Model object. We are using this 4th one.
We can also supply the only model object,
or only view name.

In the Index.cshtml, we will add a button, after clicking on this button, this code will work.

In our "responseBody" variable, we will have the html code i.e. the code from our Partial View.
I.e. the whole <div> tag.

We used response.text() in the Code. In case if the response is a JSON format, then the function
is response.json. But in this case, the partial view content is in plain HTML.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
