using Microsoft.AspNetCore.Mvc;
using _124._View_Components_with_Parameters.Models;

namespace _124._View_Components_with_Parameters.Controllers.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int x, int y, PersonGridModel viewPersonGridModel)
        {
            return View(viewPersonGridModel);
        }
    }
}
