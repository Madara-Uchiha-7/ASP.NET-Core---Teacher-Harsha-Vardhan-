using Microsoft.AspNetCore.Mvc;

namespace _59._Redirect_Results___Part_1.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Books()
        {
            return View();
        }
    }
}
