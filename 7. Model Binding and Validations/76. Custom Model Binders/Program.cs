/*
Whenever you would like to execute some complex logic while model binding,
you have to create custom model binder. Means, instead of using the default model binding functionality,
you are going to create your own model binding, and you can reuse the same across multiple places in the entire project.
For example, let's say, 
whenever the user has submitted first name and last name in the request,
you would like to concatenate them as a string value that is into person name property.
Otherwise, if the user has submitted year, month, date independently,
you have to combine them together to form a date value.

So for this type of complex operations, you have to create custom model binder in real-world projects.
For another example,
let's say there is a string value submitted as a part of the request. 
Let's say bank account type equal to savings account.
So based on that string value, you have to generate the corresponding enumeration value, enum value.
So for this type of operations,
the default custom model binding doesn't work.
You have to create your own and that is called custom model binder.

In this case, you have to create your custom model binder class
that is implementing IModelBinder interface.
Means then it is recognized as a custom model binder but this interface forces you to create BindModelAsync method
in which you can write your actual model binding functionality.
To get a specific value, you can use the valueProvider.getValue method of the binding context
and you can assign them into the respective property of your model class.
Means you have to create your own object of the model class manually
and assign the value into each property one by one by using this valueProvider.
Means almost like whatever the default functionality happens in inbuilt model binding,
the same thing should be done programmatically here. The benefit is you have your own grip
to decide what value should be assigned into what property instead of just depending on the property name.
For another example, let's say there is address. The user submits street name and city name independently.
Suppose the user submits the street and city names with comma separation. For example, abcStreet, pqrCity.
Based on the comma separation, you have to split it into multiple pieces. The first value should be assigned into street property
but the second value into city property. For this type of complex or custom logic,
custom model binders are best.

class ClassName : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // gets the value from request
        bindingContext.ValueProvider.GetValue("FirstName");
    
        // returns model object after reading data from the request
        bindingContext.Result = ModelBidingResult.Success(your_object);
    }
}


So in real world projects, it is pretty rare to use custom model binding.
So don't use it frequently until you actually need it. Suppose here exact requirement is
there is a model property called Name, right?
So if the user submits the first name and last name independently, 
both of them should be added as a single string value into this personName.

Suppose the user submits like firstName and lastName independently (for now from Postman)
Both of these firstName and lastName should be attached as a single value into personName property.

Right click on project-> Add a new folder.-> Folder name is CustomModelBinders.
Add PersonModelBinder class file in it.

But this class will not be invoked at the time of binding.
You have to set it explicitly.
So in the HomeController, you have to add an attribute called ModelBinder.
And then you have to pass the type of the CustomModelBinder class,
that is PersonModelBinder.


*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
