using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTasksController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTasksController(UserManager<AppUser> userManager, IEmployeeTaskService employeeTaskService)
        {
            _userManager = userManager;
            _employeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByIdAsync(User.Identity.Name);
            var taskList = _employeeTaskService.TGetEmployeeTaskById(values.Id);
            return View(taskList);
        }
    }
}
