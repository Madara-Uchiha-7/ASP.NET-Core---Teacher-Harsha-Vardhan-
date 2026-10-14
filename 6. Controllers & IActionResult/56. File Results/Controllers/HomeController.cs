using Microsoft.AspNetCore.Mvc;
using _56._File_Results.Models;

namespace _56._File_Results
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Hello From Index :)",
                ContentType = "text/plain",
            };
        }

        [Route("About")]
        public ContentResult About()
        {
            return Content("Hello from about", "text/plain");
        }

        [Route("Contact")]
        public ContentResult ContactUs()
        {
            return Content("<h1>Hello from ContactUs</h1>", "text/html");
        }

        [Route("Json1")]
        public JsonResult JsonFormat1()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Age = 10
            };
            return new JsonResult(person);
        }
        [Route("Json2")]
        public JsonResult JsonFormat2()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Age = 10
            };
            return Json(person);
        }

        [Route("Contact/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUsPara()
        {
            return "Hello from Contact with mobile number.";
        }

        [Route("virtual-file-download")]
        public VirtualFileResult VirtualFile()
        {
            // 1st arg for VirtualFileResult : The file path will come here. So that is the relative path
            // based on your web root folder.
            // Go to Program.cs file and unable the static files : app.UseStaticFiles();
            // The default web root path is wwwroot
            // So, lets create the folder of that path. 
            // Right click on project -> Add -> New Folder -> Name it : wwwroot
            // Copy sample or test pdf file and right click on this new folder and paste it.
            // 2nd argument is the content type.
            // Whenever our file is present in this webroot folder, we return the VirtualFileResult
            // or even if file is present in the sub folder of the wwwroot, even then you return VirtualFileResult.
            return new VirtualFileResult("/test.pdf", "application/pdf");

            // Shortcut method is also given by Controller class which also returns VirtualFileResult:
            // You can use below line also:
            // return File("/test.pdf", "application/pdf");
        }

        [Route("physical-file-download")]
        public PhysicalFileResult PhysicalFile()
        {
            // If the file is present outside the webroot filder then we use: 
            // return new PhysicalFileResult();
            // Arguments will be same as VirtualFileResult
            // Path must be a full path e.g:
            return new PhysicalFileResult(@"C:\aspnetcore\sample.pdf", "application/pdf");
            // PhysicalFileResult is not a good practice.

            // Shortcut method is also given by Controller class which also returns PhysicalFileResult:
            // You can use below line also:
            // return PhysicalFile("/test.pdf", "application/pdf");
        }
        [Route("file-download")]
        public FileContentResult FileContent()
        {
            // Sometimes in the real world projects, you might be having the
            // file that is loaded from another data source as a byte array, such as reading the images from
            // databases. In that case, you will have the file content in the form of byte array, that is the
            // raw data. Then you can return the same as file content result.
            // In other words, when you want to return the byte array as the file, then you will use
            // this file content result. It is pretty useful when you are reading the images from databases
            // or you have retrieved the byte array from another data source such as online APIs.

            // Mention the file path as arguments in ReadAllBytes()
            // And it will return the byte array.
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\aspnetcore\sample.pdf");
            return new FileContentResult(bytes, "application/pdf");

            // In the real-world projects, suppose let's say you would like to encrypt some information in file,
            // otherwise, you would like to return only a part of the file instead of sending a full file,
            // in that complex scenarios, this idea will be good.


            // Shortcut method is also given by Controller class which also returns FileContentResult:
            // You can use below line also:
            // return File(bytes, "application/pdf");

            // File() in controller is overloded. So if you send bytes then automatically it will return 
            // FileContentResult.
        }
    }
}
