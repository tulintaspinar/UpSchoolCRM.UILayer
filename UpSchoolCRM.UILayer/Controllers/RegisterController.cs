using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Models;

namespace UpSchoolCRM.UILayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser,appUser.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","User");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Index2()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index2(UserSignUpModel userSignUpModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = userSignUpModel.UserName,
                    Name = userSignUpModel.Name,
                    Surname = userSignUpModel.Surname,
                    Email = userSignUpModel.Mail,
                    PhoneNumber = userSignUpModel.PhoneNumber

                };
                if (userSignUpModel.Password == userSignUpModel.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, userSignUpModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Şifreler uyuşmmaktadır.");
                }
            }
            return View();
        }
    }
}
