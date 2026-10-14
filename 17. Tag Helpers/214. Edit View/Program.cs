/*
Now we are going to create this edit view, which we have not done in the CRUD operations section.

The edit view is almost equivalent to the create view, but only the difference is,
the selected person details should appear automatically in the text boxes at the time
of opening the view, and there itself the user can modify in these text boxes,
And once the user clicks on the submit button,
the modified or updated details have to be saved in the actual data store.



We created the Person Create View.
On top me added PersonUpdateRequest model.

Then we crtead the action method for its url.:


[HttpGet]
[Route("[action]/{personID}")]
public IActionResult Edit(Guid personID)
{
    ...
}

Here you have to make sure that the Edit parameter name i.e. personID matches with the "personID" in the above Route.

In index view,
we added edit button.
For that we added :
<td style="width:20%">
    <a 
        asp-controller="Persons" 
        asp-action="Edit" 
        asp-route-personID = "@person.ID"
    >
        Edit
    </a>
</td>

Here we added a new tag helper :
asp-route-personID
In this personID is same as our Route and Edit action method paramter.
asp-controller, asp-action, asp-route-personID will generate the url like e.g.:
/Persons/Edit/1

In the controller in the end if the Action method,
we added:
return View(personUpdateRequest);

This will allow the Edit view to populate the original values in the form.

Similarly we created the Post action method.

To get the person id in the personUpdateRequest of Edit action when user clicks on the update/submit button,
we added : <input type="hidden" asp-for="ID" /> in the html.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
