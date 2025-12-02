using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
