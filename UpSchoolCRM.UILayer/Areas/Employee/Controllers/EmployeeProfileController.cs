using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Areas.Employee.Models;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfile userEditProfile = new UserEditProfile();
            userEditProfile.Name = values.Name;
            userEditProfile.Surname=values.Surname;
            userEditProfile.PhoneNumber=values.PhoneNumber;
            userEditProfile.Email = values.Email;
            return View(userEditProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfile userEditProfile)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditProfile.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditProfile.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation,FileMode.Create);
                await userEditProfile.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.Name = userEditProfile.Name;
            user.Surname=userEditProfile.Surname;
            user.PhoneNumber = userEditProfile.PhoneNumber;
            user.Email = userEditProfile.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditProfile.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                return View();
            }
            
        }
    }
}
