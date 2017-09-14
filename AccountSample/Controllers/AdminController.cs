using Microsoft.AspNetCore.Mvc;

namespace AccountSample.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() => View();
     
        public IActionResult AddAdmin() => View();

        public IActionResult AccountExist() => View();
    }
}
