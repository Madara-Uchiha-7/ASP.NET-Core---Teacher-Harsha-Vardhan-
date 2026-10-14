// But the problem in last lecture code Controller class is that in almost every if statement, we are writing two
// individual statements. One is for setting the status
// and returning the content result.
// We can minimize this using StatusCodeResult.
// Types:
// return new StatusCodeResult(status_code); -> If situation does not come into below 3 types then use this. e.g. 500
// return new UnauthorizedResult(); -> This one is used for 401. 
// return new NotFound(); -> This one is for 400 i.e. Bad Request
// return new BadRequestResult(); -> This one is for Http 404 i.e. Not Found
// Lets update our Controller

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

// Use:
// For 401, you can use unauthorized result.
// For 400, you can use the bad request in case of request values are invalid.
// That means for validation errors And in case if the sufficient
// data is not available at the server, let's say based on the
// ID, there is no separate database record exist in the database, In that case, not found result.
// And for any other status code, you can use the status code result.
// For StatusCode() you can pass the int value of the status code.
// But in this case, the response body will be empty. Then you can use the write async method to write any response
// message.