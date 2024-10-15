using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Core.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnURL = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Passsword, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Redirigir al ReturnUrl si está presente, de lo contrario redirigir a una acción por defecto
                    return Redirect(ViewBag.ReturnURL ?? Url.Action("Index", "Home"));
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
           
            return View(loginViewModel);
        }
        public IActionResult Index()
        {
            return View();        
        }
    }
}
