/*
In order to write the server -side presentation logic in the ASP
.NET Core Razor view, you have to use this Razor code block
and Razor expressions.
When you want to declare one or more C-sharp variables or
any other type of C-sharp statements, then you can use these
Razor code blocks:
@ {
    C#/Html code here
}
And in order to print the value of a specific property or a variable, then you have to
use Razor expressions.
Razor Expression:
@Expression
or 
@(Expression)  -> Use () if there is a complex C# expression. 
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
