using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Models;

namespace UpSchoolCRM.UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInModel appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.Password,true,true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
