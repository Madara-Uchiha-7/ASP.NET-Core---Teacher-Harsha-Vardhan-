// Let's assume a business scenario.
// Suppose you have started an online website, and it has an URL
// called /bookstore. Initially, your website sells only books, just like in Amazon.
// But over the years, you have enhanced your e-commerce, and you are going to sell almost everything.
// Then, you want individual URLs, right? For every store.
// Let's say for bookstore, you want an URL called store/books.
// and for mobiles, store/mobiles, etc.

// Now at start you used /bookstore but then you replaced them in your action method attribute
// to /store/books. But the old URL called bookstore has been stored as bookmarks in the browser by
// as bookmarks in the browser by existing customers. So, if they try to open
// this page, bookstore, the page or that URL does not exist. So, they will get an error
// page. You don't want that to happen, right?
// So, you require to keep this URL, but all the requests that are incoming into this bookstore URL
// should be redirected to store/books. So, both URLs should work, but
// the requests to the first URL should be redirected to the other URL.
// This can be achieved by 
// When request is received by action 1, the action 1 returns the redirect reuslt.
// That means the status code will be either 302 or 301 i.e. either found or moved permanently respectively.
// In those cases, the browser should make another request to the action two.
// Then probably the action two returns the valid response, maybe a page, that means a view result.
// And the brower url will show the new url.
// Our HomeController action takes "bookstore" as the URL and redirects it. 
// So we have created another controller for that.
// Lets see that in controller class.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

