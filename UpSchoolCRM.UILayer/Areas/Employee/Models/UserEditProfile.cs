using Microsoft.AspNetCore.Http;

namespace UpSchoolCRM.UILayer.Areas.Employee.Models
{
    public class UserEditProfile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        //resimleri resim dosyası olarak alacak
    }
}
//1- HTML ile kod tarafında kısıtlamalar arasında ne fark var
//2- değişkenlerin büyük harf ile başlayan ile küçük harf ile başlayan arasındaki fark nedir