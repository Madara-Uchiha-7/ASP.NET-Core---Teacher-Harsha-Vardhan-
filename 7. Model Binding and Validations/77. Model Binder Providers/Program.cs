/*
Suppose you would like to use the same custom model binder for all the action methods wherever Person type of model class is used.
Then you can declare it globally by using BinderProvider.

Syntax:

class className : IModelBinderProvider  -> This interface is present in Microsoft.AspNetCore.Mvc.ModelBinding;
{
    public IModelBinder GetBinder (ModelBinderProviderContext providerContext)
    {
        // return type of custom model binder class to be invoked.
        return new BinderTypeModelBinder(typeof(YourModelBinderClassName));
    }
}

Now you can return the typeof the model binder class that you have created already so that this will be enabled
globally for the entire project wherever the particular type of model class is used as action
method parameter. That means any action method that has a parameter of person type would have the model
binder as the specified model binder means you need not write this model binder explicitly in
every action method that is your actual benefit.

In same CustomModelBinders folder, add a new item -> class -> PersonBinderProvider
Check the PersonBinderProvider.
Then check the controller class, We removed the attribute from action method parameter.

Next is:
You have to add PersonBinderProvider class as a reusable service to the controller.
Then only the controllers can recognize that.
builder.Services.AddControllers(); will change to :

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

ModelBinderProviders is a collection of model binder providers And you have to insert our custom model
binder provider at the first place. Because the binder providers execute in the same
order how they have added in the collection.
Okay, the purpose behind adding our binder provider at the index number zero that means at
the first place is that you would like to execute this person binder provider against the
built-in model binder. Because if you add this person binder provider at the end of the binded providers collection
it may not be reached or selected. By default the preference will be given for the first one that is default model binder
provider.

*/

using _77._Model_Binder_Providers.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
