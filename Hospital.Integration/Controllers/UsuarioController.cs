using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.DTO.ViewModel;
using Hospital.Integration.Helpers;
using Hospital.Integration.Models;
using Hospital.Integration.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Runtime.InteropServices;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        ApplicationContext _context;
        Core _core;
        public UsuarioController(ApplicationContext context)
        {
            _context = context;
            _core = new Core(context);
        }
        [HttpPost("AddUsuario")]

        public  async Task<IActionResult> AddUser([FromBody] SaveUserViewModel newUser)
        {
            if(string.IsNullOrEmpty(newUser.Token) ||(newUser.Token != SD.Token_Caja && newUser.Token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");
            try
            {
                var client = new HttpClient();
                newUser.Token = SD.Token_Integration;
                // Serializar el objeto a JSON
                var json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST al endpoint
                var response = await client.PostAsync($"{SD.localURL}/CreateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    Log.Logger.Information($"Usuario {newUser.UserName} agregado");
                    return Ok();

                }
                else
                {
                    
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Log.Logger.Error(errorContent);
                    return StatusCode(500, errorContent);
                }
            }
            catch (Exception ex) 
            {
                var CoreDisponible = await _core.CheckHealth();
                if (!CoreDisponible)
                {
                    if (_context.Usuarios.Where(u => u.Cedula == newUser.Cedula).Count() == 0)
                    {
                        _context.Usuarios.Add(new Usuario()
                        {
                            UserId = newUser.Id ?? string.Empty,
                            UserName = newUser.UserName,
                            Email = newUser.Email,
                            Name = newUser.Name,
                            LastName = newUser.LastName,
                            PhoneNumber = newUser.PhoneNumber,
                            Address = newUser.Address,
                            Birthday = newUser.Birthday,
                            Cedula = newUser.Cedula,
                            Password = newUser.Password,
                            RoleName = newUser.RoleName,
                            Estado = true,
                            Pendiente = true,
                            Accion = SD.Accion_Agregar
                        });
                        _context.SaveChanges();
                    }
                    Log.Logger.Warning($"Usuario {newUser.UserName} guardado en integración pendiente de sincronización");
                    return StatusCode(200, "Usuario guardado en integración pendiente de sincronización");
                }
                return StatusCode(500, ex);

            }

        }

        [HttpPost("GetUsuarioWIthCita")]
        public  async Task<IActionResult> Get([FromBody] string tokenRequest)
        {
            if (tokenRequest != SD.Token_Caja && tokenRequest != SD.Token_Web)
                return StatusCode(401, "Acceso no autorizado");
            var client = new HttpClient();
            Log.Logger.Information($"{tokenRequest} solicito lista de usuarios");
            // El token que enviarás al endpoint
            var token = "Integration";

            // Serializar el token a JSON
            var json = JsonConvert.SerializeObject(token);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST al endpoint
            var response = await client.PostAsync($"{SD.localURL}/GetUserWithAppoinmnet", content);


            if (response.IsSuccessStatusCode)
            {
                // Leer la respuesta
                var responseData = await response.Content.ReadAsStringAsync();
                var usuario  = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(responseData);
                Log.Logger.Information("Informacion solicitada de usuaios");

                return Ok(usuario);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Log.Logger.Error( $"Error al solicitar usuarios: {errorContent}");
                return StatusCode(500,errorContent);
            }
        }
    }
}
