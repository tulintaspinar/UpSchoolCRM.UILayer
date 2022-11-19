using Microsoft.AspNetCore.Mvc;

namespace UpSchoolCRM.UILayer.ViewComponents.Dashboard
{
    public class _FeatureDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
