/*
You can create multiple sections in the same layout view.
That means, you will provide the content for the section in the
view, but it will be rendered in the layout view.

e.g.
View:
--------------------------
@section section_name
{
    section Content here
}
Normal view cotent here.
--------------------------
Layout View:
--------------------------
section Content from view will be rendered in @RenderSection("section_name")
Normal view will be rendered in @RenderBody()
--------------------------

In contact view we have added our section.
And in layout view we are using this section.


@RenderSection("footer-section", false):
why we added false?
The other views does not have the "footer_section"
So, application will throw error. By giving false we are saying that its not required.

Advantages of this:
There are two common practices for these sections.
One is, the view may import one or more script tags that
means JavaScript files and those will be rendered in the layout view.
For example, there are multiple views, let's say 100 views and there
is a script file that should be imported in all the views.
Then you can import that script file directly in the layout view by directly adding 
the <script> tag in the layout view.
But suppose I have another JavaScript file that must be imported only
in specific view. Then this helps.

And the second use case for
this is, maybe you would like to supply the content for either photo area or sidebar.
Or maybe in the navigation bar, Some additional hyperlinks.Then also this helps.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();