///
/// Let us actually write the unit test cases for AddPerson method.
/// It receives the person add request as argument and adds that person details into the data store
/// that means into the table or collection and returns the same person details as PersonResponse object
/// which includes with the automatic generated person id.
/// 
/// In ServiceContracts project,
/// Create interface called IPersonService
/// This will help in dependency injection.
/// 
/// Check the code and comments.
/// 
/// 
/// Goto Servics projects and add 
/// PersonsService.cs
/// Check the code and comments in it.
/// 
/// Goto CRUDTests 
/// Create a new file -> PersonsServiceTest.cs
/// Check the code and comments in it.
/// 
///


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
