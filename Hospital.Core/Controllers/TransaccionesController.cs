using Hospital.Core.Context;
using Hospital.Core.Models;
using Hospital.Core.Models.SaveViewModel;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hospital.Core.Controllers
{
    [Authorize]
    public class TransaccionesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TransaccionesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.TipoTransaccion = _context.TipoTransaccion.Select(e=> new SelectListItem 
            {
                Value= e.Id.ToString(),
                Text = e.Descripcion
            });
            ViewBag.EstadoTransaccion = _context.EstadoTransacciones.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            var pacientes = new List<SelectListItem>();
            var cajeros = new List<SelectListItem>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    pacientes.Add(new SelectListItem 
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
                else if (await _userManager.IsInRoleAsync(user, SD.Role_Cajero))
                {
                    cajeros.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
            }
            ViewBag.Pacientes = pacientes;
            ViewBag.Cajeros = cajeros;

            //ViewBag.Citas = _context.Citas.Include(e=>e.Usuario).Include(e=>e.HorariosCitas).Select(e => new SelectListItem
            //{
            //    Value = e.Id.ToString(),
            //    Text = e.Usuario.Name +" "+e.Usuario.LastName+" | "+e.HorariosCitas.HoraInicio.ToString() + " - " + e.HorariosCitas.HoraFin.ToString()
            //});
            return View(new SaveTransaccionViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTransaccionViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.Transacciones.Add(new Models.Transacciones() 
                {
                    IdCajero = model.IdCajero,
                    IdPaciente = model.IdPaciente,
                    EstadoTransaccion = model.IdEstadoTransaccion,
                    TipoTransaccion = model.IdTipoTransaccion,
                    //IdCita = model.IdCita,
                    Monto = model.Monto,
                    Fecha = model.Fecha,
                    Comentario = model.Comentario??string.Empty,
                    Estado = true,
                });
                _context.SaveChanges();
                Log.Logger.Information("Transaccion creada");

                return RedirectToAction("Index");
            }
            ViewBag.TipoTransaccion = _context.TipoTransaccion.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            ViewBag.EstadoTransaccion = _context.EstadoTransacciones.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            var pacientes = new List<SelectListItem>();
            var cajeros = new List<SelectListItem>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    pacientes.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
                else if (await _userManager.IsInRoleAsync(user, SD.Role_Cajero))
                {
                    cajeros.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
            }
            ViewBag.Pacientes = pacientes;
            ViewBag.Cajeros = cajeros;

            //ViewBag.Citas = _context.Citas.Include(e => e.Usuario).Include(e => e.HorariosCitas).Select(e => new SelectListItem
            //{
            //    Value = e.Id.ToString(),
            //    Text = e.Usuario.Name + " " + e.Usuario.LastName + " | " + e.HorariosCitas.HoraInicio.ToString() + " - " + e.HorariosCitas.HoraFin.ToString()
            //});
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var transaccion = _context.Transacciones.FirstOrDefault(t=>t.Id == id);
            if (transaccion == null) 
                return BadRequest();
            ViewBag.TipoTransaccion = _context.TipoTransaccion.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            ViewBag.EstadoTransaccion = _context.EstadoTransacciones.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            var pacientes = new List<SelectListItem>();
            var cajeros = new List<SelectListItem>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    pacientes.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
                else if (await _userManager.IsInRoleAsync(user, SD.Role_Cajero))
                {
                    cajeros.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
            }
            ViewBag.Pacientes = pacientes;
            ViewBag.Cajeros = cajeros;

            //ViewBag.Citas = _context.Citas.Include(e => e.Usuario).Include(e => e.HorariosCitas).Select(e => new SelectListItem
            //{
            //    Value = e.Id.ToString(),
            //    Text = e.Usuario.Name + " " + e.Usuario.LastName + " | " + e.HorariosCitas.HoraInicio.ToString() + " - " + e.HorariosCitas.HoraFin.ToString()
            //});
            return View(
                new SaveTransaccionViewModel() {
                    Id =  transaccion.Id,
                    IdCajero = transaccion.IdCajero,
                    IdPaciente = transaccion.IdPaciente,
                    IdTipoTransaccion = transaccion.TipoTransaccion,
                    IdEstadoTransaccion = transaccion.EstadoTransaccion,
                    //IdCita = transaccion.IdCita,
                    Monto = transaccion.Monto,
                    Fecha = transaccion.Fecha,
                    Comentario = transaccion.Comentario??string.Empty,
                    Estado = transaccion.Estado
                });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveTransaccionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Transacciones.Update(new Models.Transacciones()
                {
                    Id = model.Id,
                    IdCajero = model.IdCajero,
                    IdPaciente = model.IdPaciente,
                    EstadoTransaccion = model.IdEstadoTransaccion,
                    TipoTransaccion = model.IdTipoTransaccion,
                    //IdCita = model.IdCita,
                    Monto = model.Monto,
                    Fecha = model.Fecha,
                    Comentario = model.Comentario ?? string.Empty,
                    Estado = model.Estado,
                });
                _context.SaveChanges();
                Log.Logger.Information("Transaccion modificada");

                return RedirectToAction("Index");
            }
            ViewBag.TipoTransaccion = _context.TipoTransaccion.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            ViewBag.EstadoTransaccion = _context.EstadoTransacciones.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            var pacientes = new List<SelectListItem>();
            var cajeros = new List<SelectListItem>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    pacientes.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
                else if (await _userManager.IsInRoleAsync(user, SD.Role_Cajero))
                {
                    cajeros.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
            }
            ViewBag.Pacientes = pacientes;
            ViewBag.Cajeros = cajeros;

            //ViewBag.Citas = _context.Citas.Include(e => e.Usuario).Include(e => e.HorariosCitas).Select(e => new SelectListItem
            //{
            //    Value = e.Id.ToString(),
            //    Text = e.Usuario.Name + " " + e.Usuario.LastName + " | " + e.HorariosCitas.HoraInicio.ToString() + " - " + e.HorariosCitas.HoraFin.ToString()
            //});
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var transaccion = _context.Transacciones.FirstOrDefault(t => t.Id == id);
            if (transaccion == null)
                return BadRequest();
            ViewBag.TipoTransaccion = _context.TipoTransaccion.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            ViewBag.EstadoTransaccion = _context.EstadoTransacciones.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Descripcion
            });
            var pacientes = new List<SelectListItem>();
            var cajeros = new List<SelectListItem>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, SD.Role_Usuairo))
                {
                    pacientes.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
                else if (await _userManager.IsInRoleAsync(user, SD.Role_Cajero))
                {
                    cajeros.Add(new SelectListItem
                    {
                        Value = user.Id,
                        Text = user.Name + " " + user.LastName
                    });
                }
            }
            ViewBag.Pacientes = pacientes;
            ViewBag.Cajeros = cajeros;

            ViewBag.Citas = _context.Citas.Include(e => e.Usuario).Include(e => e.HorariosCitas).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Usuario.Name + " " + e.Usuario.LastName + " | " + e.HorariosCitas.HoraInicio.ToString() + " - " + e.HorariosCitas.HoraFin.ToString()
            });
            Log.Logger.Information("Transaccion consultada");

            return View(
                new SaveTransaccionViewModel()
                {
                    Id = transaccion.Id,
                    IdCajero = transaccion.IdCajero,
                    IdPaciente = transaccion.IdPaciente,
                    IdTipoTransaccion = transaccion.TipoTransaccion,
                    IdEstadoTransaccion = transaccion.EstadoTransaccion,
                    //IdCita = transaccion.IdCita,
                    Monto = transaccion.Monto,
                    Fecha = transaccion.Fecha,
                    Comentario = transaccion.Comentario ?? string.Empty,
                    Estado = transaccion.Estado
                });
        }
        public async Task<IActionResult> ActivateDisactivate(int id)
        {
            var transaccion = _context.Transacciones.AsNoTracking().FirstOrDefault(t=>t.Id == id);
            if (transaccion == null)
                return BadRequest();
            transaccion.Estado = !transaccion.Estado;
            _context.Transacciones.Update(transaccion);
            _context.SaveChanges();
            Log.Logger.Information("Transaccion desactivada");
            return RedirectToAction("Index");
        }
        public JsonResult GetAll()
        {
            var transaccion =  _context.Transacciones
                                .Include(t=>t.TipoTransacciones)
                                .Include(t=>t.EstadoTransacciones)
                               .Select(t => new  TransaccionViewModel{
                                   NombreCajero = _context.Users.FirstOrDefault(u=>u.Id == t.IdCajero).Name +" "+ _context.Users.FirstOrDefault(u => u.Id == t.IdCajero).LastName,
                                   NombrePaciente = _context.Users.FirstOrDefault(u=>u.Id == t.IdPaciente).Name +" "+ _context.Users.FirstOrDefault(u => u.Id == t.IdPaciente).LastName,
                                   TipoTransaccion = t.TipoTransacciones.Descripcion,
                                   EstadoTransaccion = t.EstadoTransacciones.Descripcion,
                                   Monto = t.Monto,
                                   Fecha = t.Fecha,
                                   Id = t.Id,
                                   Estado = t.Estado,
                               });
            return Json(new { data = transaccion });
        }
    }
}
