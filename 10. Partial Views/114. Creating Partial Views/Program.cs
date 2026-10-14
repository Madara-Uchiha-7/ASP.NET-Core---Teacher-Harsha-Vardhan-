/*
The partial view is a view where you will define the reusable content in it.
That means, once you define some reusable HTML code in the partial view,
you can call it in any view wherever you want, any number of times.
For example, you have created a table or navigation bar in the partial view,
and wherever you want it, you can invoke the same in any view either by using the tag helper
or by using HTML helper.


Add a wwwroot folder in this project.
And .css file is taken from teacher.

Then we created a Controllers.
Add a new MVC Controller Empty in it.
Then we created views(Razor View Empty) for each of the action method in the Home Controller by right clicking on 
the action methods.

Then we added a _Layout view in the Shared Folder. 
For this, Right click on Shared folder, and the click on add Razor Component and then select a 
Razor Layout.

We added a css link in it.
And some html code. We added a links to home and about page.
In href attribute we added "~/", this represents localhost and port number from url.

In Views folder, we added _ViewStart.cshtml
For that, right click on Views folder, Add -> Razor View Component -> Razor View Start

It is recommended to prefix the underscore for all the partial view names.
And it is recommended to place them in the shared folder.
Because any views that are present in the shared folder becomes globally common.
That means globally accessible in the entire project from any view within the same project.

Right click on the shared folder, 
add a view -> razor view empty -> _ListPartialView.cshml
PartialView suffix is not a mandate.

We added some html code in it.
In the index view we have added this Partial View.
We have used <partial>. This is called a Tag helper.
In ASP.NET Core, the tag helper is invoked either as a tag or attribute.
But internally, it is a C Sharp class.
So it provides a specific functionality for the existing tag.

In this partial tag helper, you have to apply an attribute called name.
That is something like properties for the C Sharp class.
Here you have to mention the name of the partial view which you want to invoke.
Here you need not mention the file extension like .cshtml.

By default in ASP.NET Core application, the tag helpers are not imported.
So if you want, you have to import them explicitly.
In order to import a namespace or tag helper,
the best way is view imports.
We have already seen that in the earlier lectures.
So right-click on the Views folder.  
Add -> Razor Component -> Razor View Imports

We added below code in it:
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"

* means import all the tag helpers from given library name i.e. from "Microsoft.AspNetCore.Mvc.TagHelpers".



There are 2 more ways to invoke the partial view.

These ways are shown in the About view.


We added "await Html.RenderPartialAsync("_ListPartialView");"
in the code block (i.e. in the @{} ), otherwise it will throw the error.


So what is the difference between partial tag helper,
partial async and render partial async?

Both partial tag helper and partial async both returns the content to the parent view.
So there is some content in the partial view.
And the same content will be returned to the actual view.
So at runtime, the content of the partial view will become as a part of the content of the view.
For example, in the partial view, we have written some 10 lines of code.
This particular piece of the code becomes as a content of the existing parent view.
That is either index view or about view.

But render partial async method works in a different way.
This render partial async method should be invoked in a code block.
But instead of returning the content of the partial view to the parent view,
it streams the content directly to the browser.
So that means the content of the partial view that is written,
will be directly streamed or sent to the browser
instead of returning the same to the actual view.
So it improves the performance.
So for better performance in the larger scale code,

And in the developer perspective, the difference is
both this partial tag helper as well as partial async methods
returns the HTML content as IHtmlContent.
So you can receive the same into a variable in the view if you want.

But the render partial async method doesn't return anything.
Its return type is void.
So the content of the partial view will be sent as a response directly to the browser.



Can we share the View Data or View Bag to Partial View ?
Can we make a Partial View As a strongly typed view ?
Can we invoke a Partial View directly from the Controller action method ?
Answers are in the next lectures.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
