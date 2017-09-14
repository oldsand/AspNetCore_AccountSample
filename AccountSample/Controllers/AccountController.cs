using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountSample.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AccountSample.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).Replace("Controller", ""));
                    }
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(nameof(AdminController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddAdminAccount()
        {
            string adminUser = "Admin";
            string adminPassword = "P@ssw0rd";

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
                return RedirectToAction(nameof(AdminController.AddAdmin), nameof(AdminController).Replace("Controller", ""));
            }
            else
                return RedirectToAction(nameof(AdminController.AccountExist), nameof(AdminController).Replace("Controller", ""));
        }

    }
}
