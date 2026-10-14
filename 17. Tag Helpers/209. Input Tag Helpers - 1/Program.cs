/*
Instead of you write all these attributes like name, id, value, and data validation rules,
in order to generate all these attributes automatically or programmatically,
you can simply use the shorthand that is asp-for as the tag helper.

If you mention the model property name, based on that, it will generate all these attributes,
so that your code will be simplified and easy to understand as well as modify.
See, in general, the name attribute must be same as the property name,
so that the model binding can easily pick up the value
and assign the same into the corresponding model property when you submit the form.
Similarly, this id must be same as the model property name,
so that it will be easy to bind the same with the label tag.
Of course, id is not concerned with the form submission,
and this value attribute is required when you want to load the existing value,
that means the value from the model object into this HTML tag.
For example, there is already an existing person object,
and it has the person name,
and you would like to load that person name into this input tag as value attribute, 
then only it is required, otherwise not required.
In the same way data-cal-rule attributes are required in order to generate the client-side validations.

To use this tag helper we need to make the view as a strongly typed view.
We have done the changes in the Create View.


If you check the Person Name in create view, we now do not need to write "type="text" id="PersonName" name="Name"
Though you can still mention type if you want to asp.net will take it automatically. No need to mention it again.

If you run the app , go to the create page and right click on the the page and select view page source,
and check the code which is generate, you will see below line:
<input 
    class="form-input" 
    type="text" 
    data-val="true" 
    data-val-required="Person name can not be blank" 
    id="Name" 
    name="Name" 
    value="" 
/>

Already in the model class, if you mention the data annotations
like required, range, any other data annotations for validations,
based on those validation roles, it generates the data validation attributes e.g. data-val, data-val-required.

So based on which the client-side validations can be taken place.
But how to really do that?
How can you enable the client-side validations?
We will try that in the next lecture.

You can see id and name which is generated is same and these 2 are same as Model Property name.
By default value="", i.e. value attribute will be empty that is the text box of name will be empty.

But from the controller, if you supply the model object,
the corresponding model property value will reflect here automatically.
This helps when you have the edit functionality.

Similarly we have applied tag helpers for other areas also.


Now, for email input tag.
If you use asp-for, it will create the type attribute as:
type=text
but we do not want it to be the text type. But we want it as a email type.
So there are 2 ways to do it.
In that input tag, you do not remove the type attribute.
e.g.
 <input type="email" asp-for="Email" class="form-input" />

This way type="email" will override the type="text" which is created by "asp-for".

Another way is:
We have added the attribute above the Property Email of PersonAddRequest:
[DataType(DataType.EmailAddress)]

So because of this attribute, asp-for will create a type="email" instead of type="text"

2nd way is better because this will reflect in all the views.
Same annotation we have used for DateOfBirth.

To show genders in Create view, we have used enum.GetNames in that file.

Since ReceiveNewsLetters data type is bool, the asp-for will automatically pick its type attribute in html file
as a radio button, so no need to add attribute DataType for that property.


*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
