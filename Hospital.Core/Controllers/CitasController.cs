using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Models.SaveViewModel;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Core.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CitasController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index( )
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var userInRole = new List<ApplicationUser>();
            var users = _userManager.Users.ToList();
            foreach(var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    userInRole.Add(user);
                }
            }
            ViewBag.Users = userInRole.Select(u => new SelectListItem 
            {
                Value = u.Id,
                Text = u.Name + " " + u.LastName
            }).ToList();

            ViewBag.Servicios = _context.Servicios.Include(s=>s.TipoServicio).Include(s=>s.AreasMedicas).Select( s=> new SelectListItem 
            {
                Value = s.Id.ToString(),
                Text = s.TipoServicio.Descripcion+", "+ s.AreasMedicas.Descripcion

            }).ToList();
            return View(new SaveCitaViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveCitaViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.Citas.Add(new Citas() 
                {
                    IdPaciente = model.IdPaciente,
                    IdServicio = model.IdServicio,
                    FechaAgendada = model.FechaAgendada,
                    Estado = true
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var userInRole = new List<ApplicationUser>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    userInRole.Add(user);
                }
            }
            ViewBag.Users = userInRole.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.Name + " " + u.LastName
            }).ToList();

            ViewBag.Servicios = _context.Servicios.Include(s => s.TipoServicio).Include(s => s.AreasMedicas).Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.TipoServicio.Descripcion + ", " + s.AreasMedicas.Descripcion

            }).ToList();
            return View(new SaveCitaViewModel());
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            var userInRole = new List<ApplicationUser>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    userInRole.Add(user);
                }
            }
            ViewBag.Users = userInRole.Select(u => new SelectListItem
            {
                Selected = u.Id == cita.IdPaciente,
                Value = u.Id,
                Text = u.Name + " " + u.LastName
            }).ToList();

            ViewBag.Servicios = _context.Servicios.Include(s => s.TipoServicio).Include(s => s.AreasMedicas).Select(s => new SelectListItem
            {
                Selected = s.Id == cita.IdServicio,
                Value = s.Id.ToString(),
                Text = s.TipoServicio.Descripcion + ", " + s.AreasMedicas.Descripcion

            }).ToList();
            return View(new SaveCitaViewModel()
            {
                Id = cita.Id,
                IdPaciente = cita.IdPaciente,
                IdServicio = cita.IdServicio,
                FechaAgendada = cita.FechaAgendada,
                Estado = cita.Estado
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveCitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Citas.Update(new Citas()
                {
                    Id = model.Id,
                    IdPaciente = model.IdPaciente,
                    IdServicio = model.IdServicio,
                    FechaAgendada = model.FechaAgendada,
                    Estado = true
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var userInRole = new List<ApplicationUser>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    userInRole.Add(user);
                }
            }
            ViewBag.Users = userInRole.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.Name + " " + u.LastName
            }).ToList();

            ViewBag.Servicios = _context.Servicios.Include(s => s.TipoServicio).Include(s => s.AreasMedicas).Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.TipoServicio.Descripcion + ", " + s.AreasMedicas.Descripcion

            }).ToList();
            return View(new SaveCitaViewModel());
        }
        public async Task<IActionResult> Details(int id)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            var userInRole = new List<ApplicationUser>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    userInRole.Add(user);
                }
            }
            ViewBag.Users = userInRole.Select(u => new SelectListItem
            {
                Selected = u.Id == cita.IdPaciente,
                Value = u.Id,
                Text = u.Name + " " + u.LastName
            }).ToList();

            ViewBag.Servicios = _context.Servicios.Include(s => s.TipoServicio).Include(s => s.AreasMedicas).Select(s => new SelectListItem
            {
                Selected = s.Id == cita.IdServicio,
                Value = s.Id.ToString(),
                Text = s.TipoServicio.Descripcion + ", " + s.AreasMedicas.Descripcion

            }).ToList();
            return View(new SaveCitaViewModel()
            {
                Id = cita.Id,
                IdPaciente = cita.IdPaciente,
                IdServicio = cita.IdServicio,
                FechaAgendada = cita.FechaAgendada,
                Estado = cita.Estado
            });
        }
        public IActionResult ActivateDisactivate(int id)
        {
            var cita = _context.Citas.AsNoTracking().FirstOrDefault(c=>c.Id == id);
            cita.Estado = !cita.Estado;
            _context.Citas.Update(cita);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult GetAll()
        {
            var listCitas = new List<CitaViewModel>();
            foreach (var cita in _context.Citas.Include(e=>e.Usuario).Include(e=>e.Servicios))
            {
                var preCita = new CitaViewModel()
                {
                    Id = cita.Id,
                    NombrePaciente = cita.Usuario.Name + " " + cita.Usuario.LastName,
                    FechaAgendada = cita.FechaAgendada,
                    Estado = cita.Estado
                };
                preCita.NombreServicio = _context.Servicios.Include(e => e.TipoServicio).Where(s=>s.Id == cita.IdServicio).FirstOrDefault().TipoServicio.Descripcion;
                listCitas.Add(preCita);
            }
            return Json(new { data= listCitas});
        }
    }
}
