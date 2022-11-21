using Microsoft.AspNetCore.Mvc;
using UpSchoolCRM.BusinessLayer.Abstract;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTasksDetailController : Controller
    {
        private readonly IEmployeeTaskDetailService _employeeTaskDetailService;

        public EmployeeTasksDetailController(IEmployeeTaskDetailService employeeTaskDetailService)
        {
            _employeeTaskDetailService = employeeTaskDetailService;
        }

        public IActionResult Index(int id)
        {
            var values = _employeeTaskDetailService.TGetEmployeeTaskDetailsById(id);
            if (values == null)
                ViewBag.Null = "Görev ataması gerçekleşmemiş.";
            return View(values);
        }
    }
}
