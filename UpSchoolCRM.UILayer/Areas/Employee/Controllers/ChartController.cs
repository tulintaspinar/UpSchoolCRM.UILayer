using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UpSchoolCRM.UILayer.Models;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmantSalery> departments = new List<DepartmantSalery>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DepartmantChart()
        {
            departments.Add(new DepartmantSalery
            {
                departmanname = "Muhasebe",
                salaryavg=10000
            });
            departments.Add(new DepartmantSalery
            {
                departmanname = "IT",
                salaryavg = 20000
            });
            departments.Add(new DepartmantSalery
            {
                departmanname = "Satış",
                salaryavg = 12000
            });
            return Json(new {jsonlist=departments});
        }
    }
}
