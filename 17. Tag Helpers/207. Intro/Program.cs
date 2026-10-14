/*
The tag helper can be invoked as a HTML tag or HTML attribute in the view.
They provide values for attributes of existing HTML tags or generates new HTML tags.
For example, if you use a predefined tag helper called "asp-for"
and specify the model property name for the input tag,
then it will generate automatically the type attribute, name attribute,
id attribute as well as value attribute.
The values for all these attributes will be generated on the server side itself,
so that the same will be sent to the browser.

So instead of you write your own values of type, name and value id attributes,
you can simply use the shorthand that is asp-for.


It makes it easy to generate attributes for the particular purposeful attributes
so that the code looks simple, clean and easy to understand, easy to modify.

Tag helpers for <a>, <form>:

1. asp-controller
2. asp-action
3. asp-route-x
4. asp-route
5. asp-area

Tag helpers for <input>, <textarea>, <label>
asp-for : used to specify the model property name to which the corresponding form element is binded to.

Tag helpers for <select>
asp-for
asp-items : Here you can specify the list of items, based on which the option tags can be generated in the select tag.

Benifit:
If you talk about asp-for for the input tag, label,
text area and select tags,
you can easily bind those form elements to a model property
by using this tag helper easily.

e.g
<input asp-for="ModelProperty"> 
will be converted to:
<input type = "text" name = "ModelProperty" id = "ModelProperty" 
value = "ModelValue" />


The another benefit is that
it generates the URLs in case of form as well as anchor tag.
Instead of you write the hard-coded URLs in the hyperlinks
as well as form tags,
it generates the URLs automatically
based on the specified action name as well as controller name.

For other tags also we have the predefined tag helpers.
for <img>
asp-append-vision

for <script>
asp-fallback-src
asp-fallback-test

for <span>
asp-validation-for

for <div>
asp-validation-summary



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
