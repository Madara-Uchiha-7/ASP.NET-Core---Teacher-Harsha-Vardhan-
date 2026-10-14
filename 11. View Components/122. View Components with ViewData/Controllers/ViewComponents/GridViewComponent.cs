using Microsoft.AspNetCore.Mvc;
using _122._View_Components_with_ViewData.Models;

namespace _122._View_Components_with_ViewData.Controllers.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Person List",
                people = new List<Person>()
                { 
                    new Person()
                    {
                        Name = "Foo",
                        JobTitle = "Foo Job"
                    },
                    new Person()
                    {
                        Name = "Foo1",
                        JobTitle = "Foo1 Job"
                    },
                    new Person()
                    {
                        Name = "Foo2",
                        JobTitle = "Foo2 Job"
                    }
                }
            };

            ViewData["Grid"] = personGridModel;

            return View();
        }
    }
}
