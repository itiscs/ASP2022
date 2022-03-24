using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
