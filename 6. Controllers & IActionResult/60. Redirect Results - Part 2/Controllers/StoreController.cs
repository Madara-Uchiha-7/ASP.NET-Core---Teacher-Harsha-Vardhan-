using Microsoft.AspNetCore.Mvc;

namespace _60._Redirect_Results___Part_2.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"</h1>Book with id: {id}</h1>", "text/html");
        }
    }
}
