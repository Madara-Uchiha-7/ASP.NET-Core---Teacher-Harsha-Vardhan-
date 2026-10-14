using Microsoft.AspNetCore.Mvc;
using _125._ViewComponentResult.Models;

namespace _125._ViewComponentResult.Controllers.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel viewPersonGridModel)
        {
            return View(viewPersonGridModel);
        }
    }
}
