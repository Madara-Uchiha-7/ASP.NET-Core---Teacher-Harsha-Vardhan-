/*
Just like _viewimports.cshtml file,
the _viewstart is a special file which gets executed before execution of
the view and it is used to specify the common layout view for multiple views in the same
folder.

For example, you have _viewstart.cshtml. Suppose in this you are
writing a statement layout equal to sample layout.
So the same layout is applicable for all the views within the same controller folder.

So the benefit for the developer here is the developer need not 
repeat the same statement layout equal to some file name in every
view.

You can also create the global one which is present in the Views folder.
You can override the content of global one in the local one becuase of the order in which executes.

If you check our Home Controller Views
you will see the common statement "Layuot = Path"
If you want to change this and you have more that 50 views then this becomes troublesome.
To overcome this issue, _viewstart was introduced.

Right click on our Home Controller View Folder -> Add View -> Select Razor View Empty -> Add ->
-> Again select "Razor View Empty" ->  Name it "_ViewStart.cshtml"

In this we can write only one type of statements, that is
layout equal to the path of the layout view. Check the code in it.
We can not write any Content or any importing statements in this.
Even if you add import statements, it will be ignored.

Now after this, we removed the Layout statement from other views for Home Controller's all the views.

Remove the Layout statement from other views for Products Controller as well.
If we need a different layout for our Products, then we create a  
_ViewStart for our Products and then our _ViewStart for Products will 
have the differnt Layout Path.

We have also added the "_ViewStart" globally i.e. in the Views folder.
So, even if you delete the "_ViewStart" from our Home and Product views and if you do not
want any other Layout for our Home and Product views, then the application will still
run normally.
Right now, our HomeController's Views are using the Layout from its local _ViewStart and
ProductController's Views are using the Layout from the Gloabal _ViewStart.

For testing the override functionality, create a new Layout in Shared.
Right click on Shared folder -> Add -> Razor Component -> Razor Layout -> "ProductsLayout.cshtml"
Import the .css file in it.
Then we added some div tags and added our @RenderBody in it.

For only the Search View, we add this layout. So our search view will override its Product's
_ViewStart.

Run the project.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();