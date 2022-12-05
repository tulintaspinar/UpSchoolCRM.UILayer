using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Models;

namespace UpSchoolCRM.UILayer.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> Index(UserSignUpModel userSignUpModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = userSignUpModel.UserName,
                    Name = userSignUpModel.Name,
                    Surname = userSignUpModel.Surname,
                    Email = userSignUpModel.Mail,
                    PhoneNumber = userSignUpModel.PhoneNumber,
                    EmailConfirmedCode = new Random().Next(10000,99999).ToString()
                   
                };
                if (userSignUpModel.Password == userSignUpModel.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, userSignUpModel.Password);
                    if (result.Succeeded)
                    {
                        SendEmail(appUser.EmailConfirmedCode);
                        return RedirectToAction("EmailConfirmed", "Register");
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

        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailConfirmedCode == appUser.EmailConfirmedCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Login");
            }
            return View();
        }
        public void SendEmail(string emailcode)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tulun.tuana60@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "tulun.tuana60@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Üyelik Kaydı"; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("tulun.tuana60@gmail.com", "pzvymftacjovndys");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }
    }
}
