using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Models.SaveViewModel;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Serilog;
using System.Net;

namespace Hospital.Core.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
                    var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                    if (await _userManager.IsInRoleAsync(user, SD.Role_Admin))
                    {
                        Log.Logger.Information($"Acceso de {user.Name} {user.LastName}");
                        return Redirect(ViewBag.ReturnURL ?? Url.Action("Index", "Home"));

                    }
                    else
                    {
                            ModelState.AddModelError(string.Empty, "Usuario no autorizado");
                    }
                    // Redirigir al ReturnUrl si está presente, de lo contrario redirigir a una acción por defecto
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            Log.Logger.Information("Sesion cerrada");

            return RedirectToAction("Login");
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            // Enviar la lista de roles a la vista
            ViewBag.Roles = roles;
            return View(new SaveUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.Where(u => u.Cedula == model.Cedula);
                if (existingUser.Count() > 0)
                {
                    ModelState.AddModelError("Cedula", $"La cedula {model.Cedula} ya está registrada");
                }
                else
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Name = model.Name,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                        Birthday = model.Birthday,
                        Cedula = model.Cedula,
                        FechaCreacion = DateTime.Now,
                        Estado = true
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        Log.Logger.Information("Usuario creado");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("Password", err.Description);
                        }
                    }
                }
            }
            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            // Enviar la lista de roles a la vista
            ViewBag.Roles = roles;
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string userId)
        {
            var exitingUser = await _userManager.FindByIdAsync(userId);
            var user = new SaveUpdatedUserViewModel()
            {
                Id = exitingUser.Id,
                UserName = exitingUser.UserName,
                Email = exitingUser.Email,
                Name = exitingUser.Name,
                LastName = exitingUser.LastName,
                PhoneNumber = exitingUser.PhoneNumber,
                Address = exitingUser.Address,
                Birthday = exitingUser.Birthday,
                Cedula = exitingUser.Cedula,
            };
            var rol = await _userManager.GetRolesAsync(exitingUser);
            user.RoleName = rol.FirstOrDefault();
            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Selected = r.Name == user.RoleName,
                Value = r.Name,
                Text = r.Name
            }).ToList();
            ViewBag.Roles = roles;
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(SaveUpdatedUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;
                user.Birthday = model.Birthday;
                user.Cedula = model.Cedula;
                user.FechaCreacion = DateTime.Now;
                user.Estado = true;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var rol = await _userManager.GetRolesAsync(user);
                    if (rol.FirstOrDefault() != model.RoleName)
                    {
                        await _userManager.RemoveFromRoleAsync(user, rol.FirstOrDefault());
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);

                    }
                    Log.Logger.Information("Usuario editado");

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("Password", err.Description);
                    }
                }
            }
            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            // Enviar la lista de roles a la vista
            ViewBag.Roles = roles;
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Details(string userId)
        {
            var exitingUser = await _userManager.FindByIdAsync(userId);
            var user = new SaveUpdatedUserViewModel()
            {
                Id = exitingUser.Id,
                UserName = exitingUser.UserName,
                Email = exitingUser.Email,
                Name = exitingUser.Name,
                LastName = exitingUser.LastName,
                PhoneNumber = exitingUser.PhoneNumber,
                Address = exitingUser.Address,
                Birthday = exitingUser.Birthday,
                Cedula = exitingUser.Cedula,
            };
            var rol = await _userManager.GetRolesAsync(exitingUser);
            user.RoleName = rol.FirstOrDefault();
            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Selected = r.Name == user.RoleName,
                Value = r.Name,
                Text = r.Name
            }).ToList();
            ViewBag.Roles = roles;
            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> ActivateDisactivate(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.Estado = !user.Estado;
            await _userManager.UpdateAsync(user);
            Log.Logger.Information("Usuario desactivado/activado");

            return RedirectToAction("Index");
        } 
        [Authorize]
        public async Task<JsonResult> GetAll()
        {
            List<UserViewModel> listUser = new List<UserViewModel>();
            foreach (var user in _context.ApplicationUsers.ToList())
            {
                var newUser = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Cedula = user.Cedula,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Estado = user.Estado

                };
                var roles = await _userManager.GetRolesAsync(user);
                newUser.RoleName = roles.FirstOrDefault();
                listUser.Add(newUser);
            }
            return  Json(new { data =  listUser }); 
        }
    }
}
