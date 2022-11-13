using System.ComponentModel.DataAnnotations;

namespace UpSchoolCRM.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınzı Giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Adınzı Giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınzı Giriniz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz!")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir mail adresi giriniz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Giriniz!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz!")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor. Lütfen tekrar giriniz.")]
        public string ConfirmPassword { get; set; }
    }
}
