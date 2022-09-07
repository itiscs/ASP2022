using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityApp.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("UserName"))
                ViewData["Name"] = HttpContext.Request.Cookies["UserName"]?.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult SaveName(string txtName)
        {
            HttpContext.Response.Cookies.Append("UserName", txtName);
            return RedirectToAction("Index");
        } 

        [Authorize]
        public IActionResult Privacy()
        {
            return View(_userManager.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}