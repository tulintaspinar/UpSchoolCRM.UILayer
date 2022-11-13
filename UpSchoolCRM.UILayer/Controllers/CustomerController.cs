using Microsoft.AspNetCore.Mvc;

namespace UpSchoolCRM.UILayer.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
