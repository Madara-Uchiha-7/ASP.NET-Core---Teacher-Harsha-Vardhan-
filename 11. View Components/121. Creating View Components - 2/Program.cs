/*
Lets create the folder Components in Shared. The folder name "Components" is fixed. You can't change it.
In Components create another Folder called  "Grid".

In this "Grid" folder, right click, Add -> View -> Razor View Empty -> Default.cshtml
If you want to use different name for "Default.cshtml" then you  
have to mention it explicitly in the return view statement of the ViewComponent.
E.g. if your name of this view is Sample then you have write return View("Sample")
instead of return View() in the ViewComponent class's InvokeAsync() method.


First of all, as a part of the view, for example, from the index view,
we are invoking the ViewComponent from this line.
So it first executes the ViewComponent class.
It creates an object of the GridViewComponent.
It automatically calls the invokeAsync method.
And here you will write some code for getting the data from databases or
any other calculation logic to create a model object.
You can supply the model object to the view.
Not only the model object, you may add some data in the ViewData object as well.
So both ViewData object and model object will be supplied to the View().
This View expects and executes the default partial view at our just above created location.
And the output of the rendered partial view will be represented 
in this index view back, where originally the ViewComponent was invoked.

All this process happens on the server side only.
There is no client-side concept here.

But here the question is, how can you invoke the ViewComponent?
Lets write a code for that in Index.cshtml:

@await Component.InvokeAsync("Gird")

We use "await" because 
You are writing await because of you are invoking the ViewComponent asynchronously.

The benefit of asynchronous execution is, in case if the ViewComponent execution takes
little bit of time, maybe because of database data,
so while waiting for the data from database, the server handles the other requests.
That means the threads of the server will not be blocked
while retrieving the data from database or any other data sources.
So in that way, asynchronous process doesn't waste the server time.

You have to mention the name of the ViewComponent that you have to call with out the 
Suffix "ViewComponent", so we have passed "Grid" to InvokeAsync() method.

InvokeAsync() method should be async because of all this.
It also should be a public method.



So...
From index view
we goto grid component.
In this Grid Component, lets say we perform some DB operations.
Then flow goes to Default.cshtml.
This Default.cshtml code is given to the Index view and will be placed at:
@await Component.InvokeAsync("Gird")



In case if you want to change the folder name of Components and Grid,
or if you want to change the location of the of these Component Partial Vies,
we have to write complex code in order to customize the Razor View engine.

We can call ViewComponent from other views also. 
So same line has been added in the About View also.


There is another way to invoke the View Component.
The one which we used was:
@await Component.InvokeAsync("Gird")
There is another one just like the partial tag helper in the previous section.
To make this tag helper work, we need to add a ViewImports in the Views folder.
Right click on the Views folder and select add -> razor component -> 
Razor View Imports -> Default name.
In that we will add the library which we will need to use the tag helpers.
Also, we have to import our current assembly itself, i.e. current project name.
So that is also given in this file.
In about view, we have added the another way to invoke the View Component.
We added :
<vc:gird></vc:gird>
Here gird is our View Component class name.
You have to use the slug case.
E.g. class name is AbcDef then, I have to write it as  <vc:abc-def></vc:abc-def>

That means, wherever uppercase is used in the actual view component name,
that should be prefixed with hyphen
and everything totally lowercase.


*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();