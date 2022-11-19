namespace UpSchoolCRM.UILayer.Areas.Employee.Models
{
    public class MailRequest
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
    }
}
