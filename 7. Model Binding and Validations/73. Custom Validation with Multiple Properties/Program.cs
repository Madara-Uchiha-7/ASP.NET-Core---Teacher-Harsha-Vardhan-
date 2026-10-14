// We learned how to validate a single property or single field.
// But sometimes you have to validate multiple fields, For example, in the registration form,
// you have more than five text boxes. And you would like to validate two or more number of properties
// or fields. Then how do you apply custom validations on multiple fields or multiple properties?
// Lets add the FromDate and ToDate properties in our Perons class.
// Now lets add a custom validator to check if the FromDate is less than ToDate or not.
// 


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
