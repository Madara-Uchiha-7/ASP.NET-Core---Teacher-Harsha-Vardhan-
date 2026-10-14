// For any controller, you have to satisfy any one of these rules compulsory.
// Either of these rules or both.
// The class name should be suffixed with the word Controller.
// Or if not, that means if you don't want to suffix Controller for some reason, you can
// also add an attribute [Controller] above the class name that is Controller that guides the ASP.NET Core to
// recognize this class as a Controller class.
// If you can follow both conventions, that is suffixing the word and at the same time Controller attribute,
// then that is better.
// In mostly, devs use first one.
// Optional things to do:
// Making that suffix Controller class 
// public and making it inherit the Contoller base class.

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();

// A Controller is responsible to receive the requests, read the information from
// the requests, such as reading the information from request parameters, 
// from the query string parameters of getRequest, from the request body or 
// request cookies or request headers, etc. And to perform the validations on them.
// For example, there is a page that displays the course details. If you can send the course ID.
// So in this case, the Controller is responsible to read the ID value from the request parameters and
// can validate that. For example, see if the ID is a positive value and less than the maximum value.
// Like all the validations should be done in the Controllers. So if the validation is clear,
// then it invokes the models to fetch the data from databases.
// And after fetching the data from databases by using models, it is again the responsibility of the
// Controller to prepare or generate the response. Generally, the Controller's response is
// called as action result.
// There are different types of action results
// 