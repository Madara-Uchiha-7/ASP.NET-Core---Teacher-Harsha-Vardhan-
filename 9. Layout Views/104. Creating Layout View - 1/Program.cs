/*
In ASP.NET Core, the layout view is a webpage that is responsible to contain the presentation logic
that is common for all the views.
For example, you have 10 views in the entire project,
and you would like to maintain the same kind of look and feel along with common header,
sidebar, and footer for all those views. So whichever the design is common,
you will place that in the layout view. For example, in the header, you can place the
application title, the navigation bar, etc. And in the sidebar, you can place the navigation links.
Then in the footer, you can place some client's information
or copyright information, whichever you would like to show at the bottom of the page.
So the common content is placed in the layout view and gets repeated for every view.


---
We added normal starting code in this file:
    builder.Services.AddControllersWithViews();
    and
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllers();

Then we created the folder called wwwroot
In that we created a file called "StyleSheet.css"
In it, we added the code from teacher.

Then in our project we added a new folder, called Controllers. We can give it any other name.
Right click on that folder and select add new controller.
Select MVC Controller empty.
Name :HomeController.cs

Lets create a 3 action methods in it.
Also create a ProductController.cs
Check the code in both of them.

We are calling Views from the Controller, 
So we need to create the views.

But before then that,
in order to contain the common layout or common template,
like header, sidebar, footer, etc., we are going to create a layout view.
So that acts as a master page or common template for all the views.
And since it is common for more than one controller,
it is recommended to place the same in the views slash shared folder,
These views are also called as the shared views.

So, create the folder called Views and inside it create the folder called Shread.
Here we will create the layout view because it is common for all the controllers.

In the Shared folder add a Razor Component -> Select Razor Layout under Visual C# -> Name
can be anything. But in this case we are keeping it default : _Layout.cshtml
It is common naming convention to prefix the name using _

Generally, all the layout views and partial views
or even shared views are recommended to be prefixed with underscore,
because it is easy to differentiate between the normal views and shared views.
Maybe layout view or partial view as well.

So if it is normal view, don't prefix with underscore.
But if it is layout view or partial view, underscore is recommended, but not must.

We have imported the css file in it.
This css will be commin for all the views now, i.e. this css will act as the global.

It is possible to share the title(<title> in html) from the view to the layout view.


We have added our Custom HTML code,
in that we have added the links to our Routes.
As you can see that the href has the same value as its in the Routes.
We give that value after "/"
I.e. "/" will be used as a prefix in our href for the route values except you will see one href which has only "/", this is the
default index method Route value.
This prefix is done because we want out route value to be added after the the localhost and then port number.
You can assume that for all these URLs, localhost port number is the common prefix that is called domain name.

You can press "Ctrl-K-D" to align the code in .cshtml.

Then we have commented the 
<div>
   @RenderBody()
</div>
which is the default code which is generated.

and we have added the @RenderBody() in our own div.

Our actual content will be in @RenderBody()

This @RenderBody() is the special method
that can be used only inside the layout view
that can represent the actual content of the view.
At your execution time, the View.cshtml executes first.

The content of the view will be substituted in the place of
@RenderBody() in the layout view.

For example, in the View.cshtml, you have created some div tag.
So that div tag will be reflected at the place of @RenderBody().

The layout views cannot be executed directly.
But alternatively, the layout view can be invoked from any view.

Lets continue in the next lecture.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
