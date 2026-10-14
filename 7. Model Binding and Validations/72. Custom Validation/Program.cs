// Writing the Custom Attribute means
// writing the class. 
// That class must inherit the ValidationAttribute class.


/*using System.ComponentModel.DataAnnotations;

class ClassName : ValidationAttribute
{
    public override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // return ValidationResult.Succcess;
        // [or] return new ValidationResult("Error Message");
    }
}*/

// ValidationAttribute is the common base class for all the built-in validations.
// But where should you write actual validation code?
// That is in the isValid method. It's a predefined method with fixed parameters.
// So that you have to override it. In this isValid method, you can write your actual code for validation
// and it gets called as a part of the model validation that occurs after model binding.
// That means when ASP.NET Core receives a request, first it performs routing. And if that route points to an action method,
// then first it performs model binding, reading the inputs from the request.
// Then it performs the model validation. So as a part of that, this isValid method gets called automatically.
// So this first parameter called value represents the actual value of the property that you want to validate.
// And validationContext contains additional details of the validation
// such as reference of the property which is being validated 
// and reference of the model object which is being validated. 

// Lets do for our date of birth property.
// For example, if you configure like minimum year of birth should be 2000.
// So if the actual input value is less than that, it has to return a validation error.

// In solution Explorer, right click on project.
// Add a new folder, Name it:-> CustomValidators
// Name can be any. Add a new Item -> class in this folder. Name it:-> MinimumYearValidationAttribute.
// It is advisable to suffix the word attribute, but it is not must though.

// Add the "MinimumYearValidation" as an attribute above your Date Property.
// As you can see while writing the name of the attribute above the property, we have skipped the
// Attribute suffix.
// Check Model Person.cs for this.

// Now we can use same minimum year attribute multiple times,
// with dynamic year.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
