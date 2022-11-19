using Microsoft.AspNetCore.Mvc;

namespace UpSchoolCRM.UILayer.ViewComponents.Dashboard
{
    public class _HeadDashboardPartial : ViewComponent  
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
