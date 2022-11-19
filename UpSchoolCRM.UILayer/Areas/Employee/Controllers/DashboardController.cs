using Microsoft.AspNetCore.Mvc;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
