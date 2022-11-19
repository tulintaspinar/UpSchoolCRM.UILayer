using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values != null)
            {
                ViewBag.v1 = values.Name;
                ViewBag.v2 = values.Surname;
            }
            return View();
        }
    }
}
