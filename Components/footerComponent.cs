using Microsoft.AspNetCore.Mvc;
using startup.Models;

namespace startup.Components
{
        [ViewComponent(Name = "footerView")]
    public class footerComponent :ViewComponent
    {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return await Task.FromResult((IViewComponentResult)View("Default"));
            }
        }
    }
