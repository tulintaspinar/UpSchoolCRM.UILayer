using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolCRM.BusinessLayer.Abstract;
using UpSchoolCRM.DataAccess.Concrete;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Areas.Employee.Models;
using Message = UpSchoolCRM.EntityLayer.Concrete.Message;

namespace UpSchoolCRM.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;
            m.SenderName = user.Name +" "+ user.Surname;
            using(var context = new Context())
            {
                var receiver = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x=>x.Name+" "+x.Surname).FirstOrDefault();
                m.ReceiverName = receiver;
            }
            _messageService.TInsert(m);
            return RedirectToAction("SendMessage");
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest m)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "upschoolakbankmail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", m.ReceiverEmail);
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = m.EmailContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = m.EmailSubject; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com",587,false);
            smtp.Authenticate("upschoolakbankmail@gmail.com", "oocqrtokgbkzfxxo");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);

            return RedirectToAction("SendEmail");
        }
    }
}
//oocqrtokgbkzfxxo