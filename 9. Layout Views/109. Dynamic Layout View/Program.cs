/*
What's the meaning of dynamic layout View?
That means you are going to layout property of View dynamically based on the
condition.

E.g.
Goto Product Controller.
In Serach Action method, the user has to supply the value of 
the Product ID.
So we have changed the Route for this action method.
We also made that ProductID optional using the "?":
[Route("search-products/{ProdcutID?}")]
We are getting this product ID in the action method parameter also and 
we will add it in the view bag. Using this view bag we will change the Layout.
The Product ID will come from URL.

Then in the search view we have added the condtion for layout.

Run the app and also check the Serach view by passing the url with some id.


*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();