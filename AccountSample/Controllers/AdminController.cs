using Microsoft.AspNetCore.Mvc;

namespace AccountSample.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
