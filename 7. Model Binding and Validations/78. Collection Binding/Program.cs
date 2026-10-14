/*
Sometimes you would like to send more than one value for the same key. For example, let's say there is a phone
field and suppose you would like to send more than one Tags. In that case, how can you receive those
values in the model class?

Go to Person Model class.
Check Tags list.

Disable the :-> options.ModelBinderProviders.Insert(0, new PersonBinderProvider()); below.
Because this will not work right now with our new Tags List.

From postman Get request:
add 
Tags[0] as a key and #dotnet value.
Tags[1] and so on.

Debug the action method.
Check person parameter.
You will see the Tags.
*/

using _78._Collection_Binding.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
