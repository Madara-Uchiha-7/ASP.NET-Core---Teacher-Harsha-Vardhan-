// We will check how to accept that validation error which we have added using the [Required] attribute
// for the Model class property.

// ModelState is a property of the controller base that is available in all the action methods of
// the controller, which is used to check the status of the validation. It is the object of the 
// model state dictionary type, and also it is the property of controller base class.
// It contains three properties mainly:
// IsValid : Specifies if there is atleast one validation error or not. Return type is boolean. For no error : true
// Values : Contains each model property value with corresponding "Errors" property that
//          contains the list of validation errors of that model property.
// ErrorCount : Returns the number of error.

// In our Model class we have added the [Required] attribute. If the person name is false, then
// in HomeController it will go inside the if case.

// Read the HomeController.cs

// You can run the code using using the postman.  GET request, with body -> form-data selected.
// Dont sent the Name key and value.

// In our model class, Person Attribute, we have added, ErrorMessage = "Person name can not be empty or null."
// This is the argument we are passing to the "Required" class attribute.
// This allows us to define the custom error message to our error.
// Otherwise default error message will be trown which will in this case:
// The Name can not be empty.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();