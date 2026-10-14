/*
Input formatters are the internal classes in ASP.NET Core,
which are used to transform or convert the request body into the model object.
For example, whenever the request body contains the JSON data,
and content-type is application/JSON in the request headers,
then JSON input formatter will be enabled automatically,
and it reads the JSON data from the request body and converts the same as a model object.

But similarly, if the request body contains XML data,
and content-type is application/XML,
that is in request headers, then automatically XMLSerializerInputFormatter will be enabled automatically,
then it reads the XML data and converts the same as a model object.
By default, ASP.NET controllers have only one input formatter,
that is JsonInputFormatter.

But in case if you want to make the XML work,
that means you would like to read the XML data from the request body,

you have to manually add XMLSerializerInputFormatter for the controllers.
Check "AddXmlSerializerFormatters", in below code. This is how its added.

Now in Postman, in Body->raw-> select XML
When you select JSON instead of XML like we did in last lecture, 
then it automatically adds the request header as contentType equal to applicationByJSON
so that it enables the JSONInputFormatter.

When we select XML from dropdown,
contentType will be set as applicationByXML,
so then it enables the XMLSerializer internally,
which can transform or read the XML data from the request body into the model object.

XML contains the root tag and in that root tag our key value pairs will come in tag-value format
Pass :
<Person>
    <PersonName>Chinmay</PersonName>
    <Email>wow@wow.com</Email>
    <Phone>1000000000</Phone>
    <DateOfBirt>2000-01-01<D/ateOfBirt>
    <Age>10</Age>
    <FromDate>2030-01-01<F/romDate>
    <ToDate>2032-12-31</ToDate>
    <Tags>
        <string>Tag1</string>
        <string>Tag2</string>
    </Tags>
    <Password>123</Password>
    <ConfirmPassword>123"</ConfirmPassword>
<Person>

Notice XML is case-sensitive, so make sure you are writing Pascal case all the way.
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
}).AddXmlSerializerFormatters();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
