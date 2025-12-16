using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcGroentenEnFruit.ViewModels.Identity;
using System.Threading.Tasks;

namespace MvcGroentenEnFruit.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region Index
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(vm.RoleName))
                {
                    ModelState.AddModelError("","Role exists!");
                }
                else
                {
                    var role = new IdentityRole(vm.RoleName);
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", string.Join(',', result.Errors.Select(x => x.Description)));
                    }
                }
            }
            return View(vm);
        }
        #endregion

        #region MapUsers
        [HttpGet]
        public IActionResult MapUserWithRole()
        {
            ViewBag.RoleID = new SelectList(_roleManager.Roles, "Id", "Name");
            ViewBag.UserID = new SelectList(_userManager.Users,"Id","Email");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MapUserWithRole(UserRoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(vm.UserId);
                var role = await _roleManager.FindByIdAsync(vm.RoleId);
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                // redirecttoAction doen we zodat we naar index gaan EN(BELANGRIJK) zodat de actie ook uitgevoerd wordt van index --> Rollen worden meegegeven. Bij return view zouden de rollen null returnen
            }
            ViewBag.RoleID = new SelectList(_roleManager.Roles, "Id", "Name");
            ViewBag.UserID = new SelectList(_userManager.Users, "Id", "Email");

            //De viewbags geven we weer mee als er een error message zou komen
            return View(vm);
        }
        #endregion
    }
}
