using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UpSchoolCRM.UILayer.Models;

namespace UpSchoolCRM.UILayer.ViewComponents.Dashboard
{
    public class _ChartDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<DepartmantSalery> departments = new List<DepartmantSalery>();
            return View();
        }
    }
}
