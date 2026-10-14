/*
In this lecture, we are going to create the createPerson view.
Here, once the user enters the details in the person name, email and all text boxes
and click on the create button, these details have to be submitted 
to a controller action method
and those have to be inserted into the persons list.


We will call PersonService AddPerson method from our new action method Create.
So, this action method will be executed when user clicks on
Create View.

We have also added "[HttpGet]" on this action method. This also means
that this action method receives only getRequest. 

Right click on the Create action method name and click on add view and then
select Razor View Empty and name it Create.cshtml

We are going to add a form element in it.
We have already seen how does the form elements work.
That means it collects all the form elements as a giant query string and adds the same in
the request body to make a post request to the mentioned URL.
That's how does the form elements work.

Check the code for "@*PersonName*@"
You will see we have added the flex class for main div in which we have
"Person Name" label and the input element too.
The flex class is given so that the label and the input element will come side 
by side. The label element's div has a class called "w-25".
Means the label element div will take 25% of the area.
This means this input element will take the 75% of the width.

Also notice that the id given to the input tag is same as attribute "for" of the 
label tag.
Since the ID matches with this for attribute of the label,
when the user clicks on the label, the cursor automatically appears in the input tag.
It indicates that the label tag is related to this particular text box.

And in order to make the form to be submitted,
every input tag must have name.
If the input tag or select tag is not having the name attribute,
its value will not be submitted when the user clicks on the submit button.

Generally, we can give them same name,
which is same name as the PersonAddRequest property.

So our attributes has the same name as the PersonAddRequest properties.

So when you can give the same property name for attribute name,
when you are submitting, the model binding automatically pick up the value from input element
and add the same into corresponding person name property.
In case if the name differ, the value of the text box will not be loaded into the property,
then you have to write your own code manually
to copy the value from the input tag into this property,
which is cumbersome and lengthy, not preferred.

Press Ctrl + K + D to format the codes.

For Country in the Create view:
Notice the name attribute. Its a CountryID.
Because for User, in the dropdown, he will see the names of the Countries 
but when he selects one and click on Submit, we should submit the ID of that 
country not the name. Because while adding the new Person we are adding the 
Country ID with him in the backend.
We are passing the country names from viewbag which are added in the controller.
Check the option tag now, it has
value="@country.CountryID"
That means when the user has selected a country name, for example they have selected USA,
corresponding country ID will given to us in the backend.

In the Create view,
for date, we have the input's type attribute set to date.
It offers the calendar automatically.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
