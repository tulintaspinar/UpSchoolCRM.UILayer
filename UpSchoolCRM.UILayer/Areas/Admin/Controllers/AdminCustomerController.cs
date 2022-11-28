﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());
            return Json(jsonCustomers);
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }
        public IActionResult GetById(int CustomerID)
        {
            var values = _customerService.TGetById(CustomerID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
    }
}
