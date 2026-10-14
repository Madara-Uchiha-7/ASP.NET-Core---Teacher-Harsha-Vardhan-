/*
After creating the person, there should be a way to delete the person, right?
So, we are going to create a delete view, where the user can delete the person.


We will display the delete button for every person,
and if the user clicks on that, we will show this delete page.
And we will ask him or she to delete this particular person.


In edit action method controller why we wrote :
return View(personResponse.ToPersonUpdateRequest());

Because if error comes, we still want to keep the values in the input field,
if we do only return View() when model state is not valid,
then we will see errors but user will loose all the values he has added.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
