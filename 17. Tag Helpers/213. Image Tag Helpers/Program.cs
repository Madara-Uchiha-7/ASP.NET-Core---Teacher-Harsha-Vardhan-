/*
There is a problem with images. For example, you have used img1.jpg on your img tag,
and it has been loaded into the browser. By default, most of the browsers caches the images.
So your img1.jpg will be cached in the browser memory, and even though you have changed the
image on the server, that will not be reflected on the browser, but instead it keeps showing
the cached image. So how do you enforce the browser to show the updated or modified image?

You can solve this problem by using asp-append-version tag-helper for img tag.



Goto and search logo generator on goolge and pick any image.
We added it in wwwroot.

We added it in _LayoutView.

When you use:
asp-append-version="true":
<img src="~/market.png" width="25px" asp-append-version="true"/>
will be converted into:
<img src="~/market.png?v=HashOfImageFile" width="25px"/>

So what this tag helper will do is that,
it will generate a query string parameter called "v",
"v" for version, that is equal to the hash of the image file.
It automatically generates the hash of the image file by using hashing algorithm called SHA-512.
So this hash will be regenerated every time if the image file is modified or replaced.
For example, for the first image, it generates one hash.
But for another image, that means if you replace the image, it generates a different hash.
And that hash will be assigned into the parameter called "v".
In the browser perspective, as soon as the v value has been changed,
since the URL is changed overall, it makes a fresh request to the server to get the updated image.
In that way, we can make sure that the browsers display the updated logo image
as soon as the file is replaced or modified on the server.

You can see this in the element tab of inspect mode.

In create view,
<div class="center-box">
we have used this class center-box.
Because of this, 
when we are in create person area,
and if we reduce the browser size,
the form will adjust itself automatically.



*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
