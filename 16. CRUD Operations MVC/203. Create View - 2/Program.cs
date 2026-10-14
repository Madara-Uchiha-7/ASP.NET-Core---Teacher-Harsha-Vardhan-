/*
In Create view,
for receive news letters,
input element's value attribute's value is true.

When the user checks this checkbox, it submits receive newsletters equal to true.
So, as per the model binding, it assigns true into ReceiveNewsLetters boolean property.

We are going to create the action method so that we can accept the 
data entered by the user.

Check the action method parameter.
Its of "PersonAddRequest" type.
As you can see, all the values from the form will get mapped in this object.
We do not need to do any additional work for this.

We added "ModelState.IsValid"
The model will be automatically gets validated
after the model binding internally.
That means before calling our action method,
the model validation automatically taken place
because of the validation rules such as required, email, whatever added
in PersonAddRequest.cs

But only the thing is, we can check the status and respond accordingly.
So we have used "ModelState.IsValid".

Then we are reading the errors using "ModelState.Values..."

We are adding errors in 
"ViewBag.Errors" in controllers
and showing the same in the Create View, under the submit button.

If all is good then we have used "RedirectToAction" to goto another view.
"RedirectToAction("Index", "Persons");"
Goto to Index action method of the Persons controller.
Since the action method is in the controller you can skip the 2nd 
argument that is the controller name. But its better to not do so to avoid
the confusion.

After clicking on Submit button, we are performing form 
validations on the server side.
Its better to perform such validations on the client side itself.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
