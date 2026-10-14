/*
Sometimes you would like to create a model validation which is specific
to a particular model class, which is not reusable. Then you will use this IValidatable object for your model class, where
you will write your custom validation logic in the same model class instead of writing it outside.

Model class :

class ClassName : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
    {
        if (condition) yield return new ValidationResult("Error Message");
    }
}


For example, your requirement is either of date of birth or age should be submitted.
Either date of birth can be null or age can be null, not both at a time. This is your validation requirement.

But in order to accomplish this, instead of writing the custom validator as a separate class, you can
create the validation code in the same model class.

You have to implement Validate method in your model class,
And there you can write any validation code which gets executed after model binding and before
execution of the action method.

*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
