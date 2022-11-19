using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UpSchoolCRM.DataAccess.Concrete;

namespace UpSchoolCRM.UILayer.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var context = new Context())
            {
                ViewBag.EmployeeCount = context.Employees.Count();
                ViewBag.EmployeeWomanCount = context.Users.Where(x => x.Gender == "Kadın").Count(); //Appuser gelmiyor çünkü contexte tanımlanmadı
                ViewBag.LastUser = context.Users.OrderByDescending(x=>x.Id).Take(1).SingleOrDefault().Name;
            }
            return View();
        }
    }
}
