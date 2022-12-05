using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.DTOLayer.DTOs.ContactDTOs;
using UpSchoolCRM.EntityLayer.Concrete;

namespace UpSchoolCRM.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactAddDTO contactAddDTO)
        {
            if (ModelState.IsValid)
            {
                _contactService.TInsert(new Contact()
                {
                    Name = contactAddDTO.Name,
                    Mail = contactAddDTO.Mail,
                    Content = contactAddDTO.Content,
                    Subject = contactAddDTO.Subject,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
