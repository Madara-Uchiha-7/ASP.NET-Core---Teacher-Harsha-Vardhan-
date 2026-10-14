/*
The Model-View-Controller pattern is an architectural pattern that dictates
you how do you separate the code into Models, Views, and
Controllers.

We have talked about controllers and model. Lets see the views.

Here the thumb rule is that the Controller can invoke anything. Controller can invoke the Model.
Controller can invoke the View. And then the View can invoke the model.
These are the three rules.

First of all, there are two types of Model.
Business Model and View Model.
So once the request is sent, first it will be received by the routing and then eventually go
to the Model binding and Model validation as we have seen earlier
and then it reaches to the action method.
So the Controller action method is the entry point for your MVC architecture.
The Controller takes the responsibility of receiving the request and then
deciding what response should be sent. Means whatever returned in the action
method, that will be eventually sent as response body to the client.

Http Requst -> Routing -> Model Binding and Model Validation ->
-> Controller (Action Method) -> 1) Bussiness Model (Bussuness Logic)
                              -> 2) View Model (Properties)
                              -> 3) Presentation Logic (This Goes back to View Model. This is done by View)

Lets see the scenario.
We sent the email and password as a request body.
Then asp.net core's Rotiing Mechanism checks the url if it matches with any action methods or not.
Once the action method is selected, the Model Binding and Model Validation is performed.
Then we reach to action method.
It receives the model object which contains the email address and password.
Then it has to check whether the model state is valid. Means if email and password both
values are not null, then modelState.isValid equal to true.
Then it performs the operation number 1.
It invokes the business model to perform the business logic.
Eventually, the business model is a service class that performs the business logic or business operations
and business validations.
That means it verifies whether the email address and password is correct as per the data from database.
If it is correct, then it returns true back to action method.
So then the action method of the controller performs the second
operation. That is, it creates a view model which contains all the product's
information that are to be displayed in the view. That means on the page.
So, yes, the controller has a list of products as a view model.
For example, as a list of product model class. But it is just a list or collection, right?
So in order to visualize the same, means in order to print it on the page,
you require a view which contains your HTML code.
So the controller action method supplies the view model object to the view (3rd step to 2nd step).
It says that, hey, view, have your design logic. That means your HTML code. And take this list of products.
That means a view model and print the same as you want. Either in the form of table
or in the box format or as a tree list.
The controller doesn't involve in the design logic.
So then the view contains the design logic.And whenever necessary, view reads the
view model information that is supplied by the controller.
So finally, when the view really executes a server, it generates HTML
code which includes with the data of the view model.
That means the result of the view is a plain HTML page
that contains the list of products in the form of a table or in the form of boxes.
Then that final view result will be sent as a response back to browser.
So the thumb rules of the model view controller pattern is the
controller invokes both type of models. It invokes the business model to perform the business operations.
And eventually, the business logic invokes the data access layer to perform the real world database
operations, such as reading or writing the data from database.
Business logic is about validations and calculations.
It invokes the data access logic, which is separate from the business logic.
So the business logic is more of methods to perform validations or calculations.
It mainly deals with the database tables and database related stuff.
And then the second point is the controller creates an object of the view model or a collection.
So it contains either a single object or a collection that is the data to be presented in
the view.

Then it passes the view model object to the view, asking the view to execute to print the
view model data. So then the view accesses the view model object.
Here did you notice a pattern?
View does not directly access the bussiness model.
View directly deals with the data present in the view model.
But view doesn't care from where the data has been retrieved from which database table.
It is the responsibility of the business model to take care about the backend logic.


In Short lets repeat again:
So in brief, controller receives the
request, invoke the business model.

Then business model receives the input
data from the controller and performs
business operations such as searching,
inserting, updating, or any other
database specific operations.
And also performs necessary server side
validations.

If everything is clear, it sends
essential data back to the controller.
Controller receives the data and forms
in the form of an object
of ViewModel class.
The ViewModel class is a POCO
class, as we have created model
classes with validation attributes in
the last section.

In the ViewModel, you can add
data attributes such as required,
range, etc.
that are applied to the data
properties.

So the model classes which we
have created in the model binding
section is exactly an example of
ViewModel.

So the controller passes ViewModel
object to the view.

Then the view access the property
values of the ViewModel and prints
them in desired design.

Then finally, once the view renders
its server side, as result you
will get the view result, which
is the plain HTML code and
the same will be sent as
response as it is to the
browser.

Then the browser receives the plain
HTML code along with corresponding CSS
files and JavaScript files.

So the browsers execute the HTML,
CSS, JavaScript code as per the
nature of the browser.


What is the benefit of model view controller pattern?
Each component that is model view controller is developed independently
so that you can unit test them and also you can divide
your work into multiple teams.
For example, one group of your development team takes care about model
and other team for controller.
Actually, in general, first models are finished off and then the view
and controller can be independently developed in parallel.
That is the greatest advantage of model view controller.

*/
