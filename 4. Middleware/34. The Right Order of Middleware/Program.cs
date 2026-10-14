/*
There are a lot of predefined middleware functions in asp.net core.
But in most of the common projects you require to use a set of predefined
middleware as you can see below:

                Request
                   |
                  \|/
                   |     
Response <---   Exception Handler
                 |      |        
                /|\     |
                 |     \|/ 
                 |      |
                 --HSTS
                 |      |
                /|\    \|/
                 |      |  
                 --HttpRedirection
                 |          |
                /|\        \|/
                 |          |
                 -------Static Files
                 |              |
                /|\            \|/ 
                 |              |
                 ----------Routing
                 |              |
                /|\            \|/
                 |              |
                 ---------------CORS
                 |                  |
                /|\                \|/
                 |                  |
                 -----------------Authentication
                 |                      |
                /|\                    \|/
                 |                      |
                 ----------------------Authorization
                 |                          |
                /|\                        \|/
                 |                          |
                 ---------------------------Custom Middlewares
                 |                              |
                /|\                            \|/ 
                 |                              |
                 --------------------------------End point


Microsoft recommends you to use the middleware in the same order as shown here.
Because you want to function the https, static files, routing, authentication
and all these functions well and proper.    
So in order to enable the proper processing of all these said features
it is recommended to follow the same order of middleware.

Enable the exception handler middleware in case of development environment.
And then after that it is recommended to enable HSTS.
That means http strict transport security.
So it enforces the browser to use https protocol
rather than http protocol.
But in case if the browser sends http request then automatically the same
request will be transferred that means redirected to https with HttpRedirection
middleware.

If the browser sends a request to a static file such as file name dot
extension; then this static files middleware will search for that particular file.
and then you require to enable the routing using Routing middleware.

And optionally enable the CORS;
and then authentication and then
authorization.

app.UseExtensionHandler("/Error");
app.UseHts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseMapControllers();
// Out custom middleware calls
app.Run();
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
