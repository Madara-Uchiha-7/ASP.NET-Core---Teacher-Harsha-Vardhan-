// ASP.NET Core web applications require
// the input data. But from where it fetches the input data?
// That is, from the request. The request may send the data in various formats, in different ways.
// For example, the request may contain the input data in the form of request headers, or request query
// of request headers, or request query string parameters, or in the request 
// body, either in the form of query string or JSON or XML. Or input parameters may also be
// sent via route parameters. So it is the responsibility of
// the server card to retrieve all that input data from the request before starting the process.
// But writing the manual code for retrieving the values from all these sources is error-prone and time
// -consuming, even lengthy too. So in order to minimize and simplify the code to retrieve the
// data from the request parameters, ASP.NET Core has a concept called model binding.

// So the target of the model binding is, retrieve the data from various input sources from the request
// and make that data as available to the parameters of the controller action methods.
// That means, practically, a controller action method can receive the data from the request body or request
// headers, or from the route data, or from any part of the request. But as a developer, you're required
// know, how do you handle that model data? How do you retrieve the data from the request by using this
// model binding? In the same way, how can
// you specify the specific source from which you would like to retrieve the data?
// For example, if you are interested in retrieving the value from the route parameters, but not from the
// request headers, how do you mention the same in the code? That is what we will learn.

// By default, the controller parameters can retrieve the data from Model Binding in below order:
/*
 HTTP request -> 
    Routing -> 
        Model Binding (Form Fields, Request Body, Route Data, Query String Parameters) -> 
            Controller(Action_1, Action_2,...)
*/
// Form Fields has highest priority and then priority gets lower and lower. So, Query String Parameters 
// has the lowest.
// E.g. if you supply the value called x equal to 10, that means the parameter name is
// x and value is 10, and if it is present in all Model Binding areas, then Form Fields will be picked.
// In code we can force and specify from which area of Model Binding I want to pick the data.
// Routing decides which action method to execute depending on the Route URL, then automatically model
// binding process occurs in background, then only the execution control reaches to the action method, means before
// the execution control reaches to the action method, the model binding would occur.
// 

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();



