using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Areas.Employee.Models;
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
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash,true,true);
            if (result.Succeeded && appUser.EmailConfirmed)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        

    }
}
/*
 Kullanıcı tablosuna bir tane daha sütun ekleyelim. Bu sutün rastgale 6 haneli bir karakter alsın.
Bu 6 haneli karakter kullanıcının sisteme giriş yaptığı mail adresine body kısmından iletilsin.

.....

Login sayfasından önce bir sayfa daha açılsın bu sayfa email confirmed işlemi karşılıyor olacak
mail adresine gelen nveriyi doğru şekilde girerse 1.input mail adresi 2.input kod 
doğru ise mail confirmed kısmı true olsun 

pzvymftacjovndys
 */