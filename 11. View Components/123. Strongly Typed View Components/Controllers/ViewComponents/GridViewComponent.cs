using Microsoft.AspNetCore.Mvc;
using _123._Strongly_Typed_View_Components.Models;

namespace _123._Strongly_Typed_View_Components.Controllers.ViewComponents
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

            return View(personGridModel);
        }
    }
}
