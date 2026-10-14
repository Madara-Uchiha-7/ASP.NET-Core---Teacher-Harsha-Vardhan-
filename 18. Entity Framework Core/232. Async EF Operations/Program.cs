/*

The asynchronous method execution can be paused by using await keyword based on either IO-bound code or CPU-bound code.

That means, as soon as the particular task has been completed, it can resume the execution of the asynchronous method.

But meanwhile, the same thread can execute some other method or some other request.
In that way, you can ensure the maximum usage of the CPU capacity.
First of all, you will create an asynchronous method by using async keyword and it can use one or more await keywords.
Wherever you would like to wait for getting the response from a particular method,
for example, reading the data from file or database or executing some large amount of task,

wherever you would like to wait for a particular method execution, you can use the await keyword.
Upon using the await keyword, the current method execution can be passed until we get the proper response from the task.

Particularly, in this lecture, we are going to use the async and await keywords, the service methods as well as controller action methods.

In the real-world projects, always it is advisable to maintain the service methods and controller action methods as asynchronous methods always.
Because most of the I-O operations, particularly database interaction, should be done with asynchronous operation.

Means, you have to use async and await always while interacting with the files, databases or any other external resources,
such as communicating with email servers, etc.

So, in order to fulfill that, switch to the I-countries service. Let's convert all these methods as asynchronous methods.
We made return type to Task<>
So, the meaning of the task here is that it is awaitable.
That means, while calling this method, the caller can use the await keyword.
That means, he can wait for getting the response from this method.
So, meanwhile, the same thread can execute some other remaining methods or can handle other requests.
In that way, we can ensure the maximum utilization of the CPU capacity.


Because of these changes we made same changes in the CountryService.
So, we added the async keyword on start before the method return type for all the methods for which 
we made a change in the ICountryService.cs

Because we are using the async keyword,
we can use await in those methods, so thats why have used await as a prefix in those those method codes.

Particularly, when you are retrieving the data from database by using entity framework, we have to use await.
Because it is the I-O bound.
That means reading the data from external resource.

As we have done in the CountryService,
we have done the same in the PersonsService.cs and in IPersonsService.cs 

There are still more files in which we need to make the change so lets do this in the next lecture.

*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
