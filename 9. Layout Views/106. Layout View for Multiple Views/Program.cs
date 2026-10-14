/*
Lets create a views for remaining Action methods.
If we use different name for view which is not same as the 
index method. Then we need to mention it in the "return View()"
statement.

You can see that visual studio has created the
different view folder for the Product Home controller automatically
when we created a view for its Index method.

Run this project and check.


Order of Execution:
_ViewImports.cshtml -> _ViewStart.cshtml -> View.cshtml -> LayoutView.cshtml


Order of Execution:
return View(); -----------------------------------------> 1

Views(Folder Name):
    _ViewImports.cshtml---------------------------------> 2
    _ViewStart.cshtml-----------------------------------> 3

    Controller_Name(Folder Name):
        _ViewImports.cshtml-----------------------------> 4
        _ViewStart.cshtml-------------------------------> 5
        View.cshtml-------------------------------------> 6

    Shared(Folder Name):
        LayoutView.cshtml-------------------------------> 7


The view imports and view start
may present in either views folder
as global or in the controller
name specific folder.

If then, the global ones executed
first, and then the local ones.

*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
