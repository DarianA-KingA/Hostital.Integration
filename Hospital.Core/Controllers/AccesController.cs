using Hospital.Core.Context;
using Hospital.Core.DTO;
using Hospital.Core.Models;
using Hospital.Core.Models.SaveViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Core.Controllers
{
    public class AccesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }
        //Retirna la lista de pacientes y sus citas
        public async Task<IActionResult> GetUserWithAppoinmnet([FromBody]string token)
        {
            if (token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            // Paso 1: Obtienes los usuarios y sus citas de la base de datos
            var clientes = await _context.Users
                .Include(u => u.Citas)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.LastName,
                    u.Birthday,
                    u.Cedula,
                    u.Address,
                    u.Email,
                    u.UserName,
                    u.FechaCreacion,
                    u.Estado,
                    Citas = u.Citas.Select(c => new {
                        c.Id,
                        c.IdPaciente,
                        c.IdServicio,
                        c.FechaAgendada,
                        c.idHorarioCita,
                        c.Estado
                    })
                }).ToListAsync();

            // Paso 2: Procesar operaciones asincrónicas para cada usuario
            var clientesConRoles = new List<object>();

            foreach (var cliente in clientes)
            {
                var user = await _userManager.FindByIdAsync(cliente.Id);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.FirstOrDefault() == SD.Role_Usuairo)
                {
                    // Agregar los roles al cliente
                    clientesConRoles.Add(new
                    {
                        cliente.Id,
                        cliente.Name,
                        cliente.LastName,
                        cliente.Birthday,
                        cliente.Cedula,
                        cliente.Address,
                        cliente.Email,
                        cliente.UserName,
                        cliente.FechaCreacion,
                        cliente.Estado,
                        Rol = roles,
                        Citas = cliente.Citas
                    });
                }
            }

            // Devolver el resultado con los usuarios y sus roles
            return Ok(clientesConRoles);
        }
        //Agrega usuario
        public async Task<IActionResult> CreateUser([FromBody]SaveUserViewModelDTO model)
        {
            if (model.Token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            if (model.RoleName == SD.Role_Admin)
                return BadRequest("No se permiten registrar usuarios administradores");
            try
            {
                var existingUser = _context.Users.Where(u => u.Cedula == model.Cedula);
                if (existingUser.Count() > 0)
                {
                    return BadRequest($"CedulaLa cedula {model.Cedula} ya está registrada");
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
                        return Ok();
                    }
                    else
                    {
                        string errors = "";
                        foreach (var err in result.Errors)
                        {
                            errors += $"{err}\n";
                        }
                        return StatusCode(500, errors);
                    }
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);

            }

        }

        public async Task<IActionResult> GetServicios([FromBody] string token)
        {
            if (token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            var servicios = _context.Servicios
                .Include(s=>s.AreasMedicas)
                .Include(s=>s.TipoServicio)
                .Select(s => new 
            {
                s.Id,
                s.IdAreaMedica,
                s.IdTipoServicio,
                s.Costo,
                s.Estado,
                AreasMedicas = new 
                {
                    Id = s.AreasMedicas.Id,
                    Descripcion = s.AreasMedicas.Descripcion,
                    Estado = s.AreasMedicas.Estado
                },
                TipoServicio = new 
                {
                    Id = s.TipoServicio.Id,
                    Descripcion = s.TipoServicio.Descripcion,
                    Estado = s.TipoServicio.Estado
                }
            });
            return Ok(servicios);
        }
        [HttpPost]
        public IActionResult CloseCitas([FromBody]CloseCitaDTO citaDTO)
        {
            if(citaDTO.Token!=SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            var cita = _context.Citas.AsNoTracking().FirstOrDefault(c => c.Id == citaDTO.IdCita);
            if (cita == null)
                return BadRequest("No se encontró la cita");
            cita.Estado = false;
            _context.Citas.Update(cita);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult AddTransaccion([FromBody] SaveTransaccionDTO transaccionDTO)
        {
            if (transaccionDTO.Token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            try
            {
                var x = _context.Transacciones.Add(new Transacciones()
                {
                    IdCajero = transaccionDTO.IdCajero,
                    IdPaciente = transaccionDTO.IdPaciente,
                    TipoTransaccion = transaccionDTO.IdTipoTransaccion,
                    EstadoTransaccion = transaccionDTO.IdEstadoTransaccion,
                    Monto = transaccionDTO.Monto,
                    Fecha = transaccionDTO.Fecha,
                    //IdCita = transaccionDTO.idCita,
                    Comentario = transaccionDTO.Comentario ?? "",
                    Estado = true,
                });
                _context.SaveChanges();
                int id = x.Entity.Id;
                return Ok(id);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult GetHorarios([FromBody] string token)
        {
            if (token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            var horarios = _context.HorariosCitas.Select(c => new 
            {
                c.Id,
                c.HoraInicio,
                c.HoraFin,
                c.Estado
            });
            return Ok(horarios);
        }
        [HttpPost]
        public IActionResult AddCita([FromBody] SaveCitaViewModelDTO citaDTO)
        {
            if (citaDTO.Token != SD.Token_Integration)
                return StatusCode(401, "Acceso denegado");
            _context.Citas.Add(new Citas 
            {
                IdPaciente = citaDTO.IdPaciente,
                IdServicio = citaDTO.IdServicio,
                FechaAgendada = citaDTO.FechaAgendada,
                idHorarioCita = citaDTO.idHorarioCita,
                Estado = true
            });
            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Ping() 
        {
            return Ok(true); 
        }

    }
}
