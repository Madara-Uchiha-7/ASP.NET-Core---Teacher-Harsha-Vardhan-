/*
While invoking the view component in the parent view,
you can supply one or more parameter values.
and those can be received in the invokeAsync method of the view component.

Goto Index view and we have added the parameters there.
We use the anonymous object using the new keyword.

Then we received them in the Component class.
There, we have added the parameters to our InvokeAsync method.
We can also supply the model object from Index view to Component class.
This is also also added in the parameter.
Note:
The parameter names in the InvokeAsync() should match with the parameter alias 
in the view.
e.g. in Index view, we are using  "viewPersonGridModel = personGridModel"
so the parameter name in the Component class will have to be "viewPersonGridModel".

In old About view we will get the NullReferenceException.
Because the InvokeAsync() parameter will receive the null value, since 
we are not passing any Model object in the About View.
So, to fix it, you have to make sure to pass the Model object from 
view in such cases to the Component class.
We have added the About View accordingly.

In about view we have used:
<vc:grid viewPersonGridModel="personGridModel"></vc:grid>
In this, attribute name, in this case "viewPersonGridModel", should be the 
same name as the parameter name of InvokeAsync()

For me :
<vc:grid viewPersonGridModel="personGridModel"></vc:grid> 
this line is not working.
Chat gpt is saying use the same which is done in the Index view.

*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();