/*
We will implement the sorting logic for all the columns in this lecture.

We will create this as an partial view. So that we dont repeat the logic again 
again for each column.

In shared folder add -> razor component -> razor view empty -> _GridColumnHeader.cshtml

Note how we added our viewbag variable in the attribute of html file
in _GridColumnHeader.cshtml and in the <a>here</a>




*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
