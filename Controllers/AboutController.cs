using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
