using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcGroentenEnFruit.Data;
using MvcGroentenEnFruit.ViewModels.Identity;
using System.Threading.Tasks;

namespace MvcGroentenEnFruit.Controllers
{
    public class AccountController : Controller
    {
        private GFDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signinManager;

        public AccountController(GFDbContext context,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signInManager;
        }

        #region AdminOverview
        public IActionResult AdminOverview()
        {
            return View();
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.RoleId = RolesData.Roles();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.RoleId != null)
                {
                    var user = new IdentityUser();
                    user.Email = vm.Email;
                    user.UserName = RolesData.GetRoleName(vm.RoleId.Value);


                    if (await ValidateIdentityUserAsync(user))
                    {
                        var result = await _userManager.CreateAsync(user, vm.Password);
                        if (result.Succeeded)
                        {
                            return View("Login");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Foutieve gebruikersnaam of email adres!");

                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Geen rol geselecteerd!");
            }
            return View();
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.Email);
                if (user != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(user, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Problem signing in!");
            }
            return View();
        }
        #endregion

        private async Task<bool> ValidateIdentityUserAsync(IdentityUser user)
        {
            bool validateResult = false;
            var emailUser = await _userManager.FindByEmailAsync(user.Email!);
            if (emailUser == null)
            {
                var nameUser = await _userManager.FindByNameAsync(user.UserName!);
                if (nameUser == null)
                {
                    validateResult = true;
                }
            }
            return validateResult;
        }

    }
}
