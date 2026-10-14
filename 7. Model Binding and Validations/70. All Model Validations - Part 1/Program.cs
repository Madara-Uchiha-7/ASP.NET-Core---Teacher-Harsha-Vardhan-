// Lets explore through all possible validation rules.

// So we have already seen the required attribute, but we miss a
// small part while creating the error message.
// We did 
// [Required(ErrorMessage = "Person Name can't be empty or null")]
// public string? PersonName {get; set;}
// In the error message field name i.e. here "PersonName" will be supplied 
// as an argument and it internally uses the string.Format to generate 
// the actual error message. 
// So, we can also do:
// [Required(ErrorMessage = "{0} can't be empty or null")]
// The problem in above is it will print :
// PersonName can't be empty or null
// But what if we need a space in Person and Name.
// Then add one more attribute.
// E.g.
// [Required(ErrorMessage = "{0} can't be empty or null")]
// [Display(Name = "Person Name")]
// public string? PersonName {get; set;}
// We can write anything in Name = "This will be your any string which you want to use."

// Next one is:
// [StringLength(int maximumLength, MinimumLength = value, ErrorMessage = "value")]
// This is applicable for string type, of properties like name, phone number,
// For example, let us say our requirement is the personName length should be between 3 to 40
// characters, but not more than 40 characters. So then you have to write:

// [Required(ErrorMessage = "{0} can't be empty or null")]
// [Display(Name = "Person Name")]
// [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be in between {2} to {1} characters.")]
// public string? PersonName {get; set;} 

// Here {0} will be the name which we have given in Display attribute.
// {2} will be the Minimum length
// {1} will be the maximum length.

// Next one is : 
// [Range(int minimum, int maximum, ErrorMessage = "value"]
// Specify the minimum value and maximum value that you want to accept in the numerical field.
// It is applicable only for numerical properties, such as short, int, long, such data types.
// 
// E.g:
// [Range(0, 999.99, ErrorMessage = "{0} should be in between ${1} and ${2}"]   : $ is to show the doller before price.
// public double? Price { get; set; } 

// Here {0} will be the name of the Property i.e. Price 
// {1} will be the Minimum
// {2} will be the maximum.

// Check the Person.cs in Models. Use the GET in postman and test the functionality.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();