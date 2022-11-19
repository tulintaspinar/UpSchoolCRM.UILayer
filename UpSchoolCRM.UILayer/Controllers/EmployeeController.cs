using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.BusinessLayer.ValidationRules;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICategoryService _categoryService;
        public EmployeeController(IEmployeeService employeeService, ICategoryService categoryService)
        {
            _employeeService = employeeService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            ValidationResult validationResult = validationRules.Validate(employee);
            if(validationResult.IsValid)
            { _employeeService.TInsert(employee); return RedirectToAction("Index"); }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var employee = _employeeService.TGetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee e)
        {
            var employee = _employeeService.TGetById(e.EmployeeID);
            e.EmployeeStatus = employee.EmployeeStatus;
            _employeeService.TUpdate(employee);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _employeeService.TChangeEmployeeStatusToFalse(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _employeeService.TChangeEmployeeStatusToTrue(id);
            return RedirectToAction("Index");
        }
    }
}
