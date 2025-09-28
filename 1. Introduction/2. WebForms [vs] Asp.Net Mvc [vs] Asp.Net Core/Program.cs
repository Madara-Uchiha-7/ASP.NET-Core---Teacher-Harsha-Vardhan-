///
///
/// ASP.NET Webforms was available from the beginning
/// of .NET framework, that is from 2002 itself.
/// 
/// Later, Microsoft releases ASP.NET MVC in 2009
/// and ASP.NET Core in 2016.
/// 
/// So, if you talk about ASP.NET Webforms, mainly it has the performance drawbacks.
/// It offers slower performance due to server events and view state.
/// 
/// Because ASP.NET Webforms itself tries to make the web as stateful instead of stateless.
/// That means, every page has to store its state, and that state will be stored in
/// the form of view state, and that view state object has to be transferred from the client to server and server to client for
/// for each request.
/// 
/// For simple web applications, it may be OK, but for medium to larger applications, it's the biggest drawback.
/// 
/// And also, in ASP.NET Webforms, for every request, server page lifecycle has to be executed
/// on the server.
/// 
/// That means, there is a series of server events that executes for each request. It is too complex and heavy weight.
/// 
/// And also, there are other disadvantages, such as
/// unit testing is difficult.
/// 
/// So, ASP.NET MVC was introduced in 2009.
/// ASP.NET MVC uses model, view, and controller pattern.
/// So that you can test your models, views, and controllers independently.
/// But it has its own drawback.
/// Because ASP.NET MVC is built on the top of some of the components that are 
/// already developed for ASP.NET Webforms earlier.
/// For example, system.web.dll. So, somewhere it offers slower performance partially, and lack of support
/// for cross-platform.
/// 
/// 
/// So, we have to improve the performance, and we have to enable the cloud-friendliness, and
/// it should be cross-platform. 
/// These are the design goals of ASP.NET
/// 
/// ASP.NET Core first version was released in 2016.
/// 
/// ASP.NET Webforms and ASP.NET MVC mainly supports Windows-only on the host.
/// But ASP.NET Core was designed as cross -platform from the beginning, from the scratch.
/// Because ASP.NET Core works based on .NET Core, It is also a cross-platform.
/// ASP.NET Webforms is not cloud-friendly, because it was developed in the time where the cloud computing is not in the market.
/// ASP.NET MVC, though it is the newer release, it is not 100% cloud-friendly,
/// because somewhere it depends on some of the components of .NET Framework, which are only available 
/// for Windows.
/// 
/// But ASP.NET Core has first-class support for clouds, such as Microsoft Azure, so that you will be able to host your application
/// on the Microsoft Azure without having any server infrastructure on your development center.
/// 
/// ASP.NET Webforms is not open source from the beginning.
/// 
/// ASP.NET MVC is open source, and ASP .NET Core is also open source.
/// But ASP.NET Core has more popularity than ASP.NET MVC in the open source community.
/// 
/// Because .NET Framework itself is not open source, but .NET Core is open source.
/// 
/// ASP.NET Webforms follows an event-driven programming approach.
/// For example, if the user clicks on a button, it offers click event on the server.
/// 
/// But ASP.NET MVC and ASP.NET Core supports model-view-controller pattern.
/// In addition to this, you can add dependency injection pattern optionally in ASP.NET MVC.
/// But ASP.NET Core has built-in support for dependency injection.
/// 
/// 
/// 
/// 
/// 
/// 
///