// The content result is a type of action result, which can be returned from the action method.
// The content result can represent almost any type of content. Let's say you would like to
// return a plain text, or HTML text, or XML data, or JSON data, or else PDF files, or
// else almost all types of content can be represented by the content result. 
// While creating the object for this content result class, you require to
// specify two parts of the information, that is the content and the content type.
// The content is the actual response body that you would like to return as a part of the
// response, let's say some message, and the content type will be added in the response headers, that is
// the MIME type of the content. For example, if the response body is the plain text, the content
// type would be text-by-plain. So in this existing application, let
// us try to mention the return type as ContentResult in our Controller class.
// 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
