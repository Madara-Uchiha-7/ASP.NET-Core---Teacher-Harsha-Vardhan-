using Microsoft.AspNetCore.Mvc;

namespace _120._Creating_View_Components___1.Controllers.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
