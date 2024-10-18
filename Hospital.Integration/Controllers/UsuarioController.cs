using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.DTO.ViewModel;
using Hospital.Integration.Helpers;
using Hospital.Integration.Models;
using Hospital.Integration.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private const string token = "Integration";
        private const string urlLocal = "https://localhost:44330/Acces";
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
            { await _core.Transfer(); }catch (Exception ex) { }
            try
            {
                var client = new HttpClient();
                newUser.Token = SD.Token_Integration;
                // Serializar el objeto a JSON
                var json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST al endpoint
                var response = await client.PostAsync($"{urlLocal}/CreateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return StatusCode(500, errorContent);
                }
            }
            catch (Exception ex) 
            {
                if (!await _core.CoreOnline())
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
                    return StatusCode(200, "Cambio guardado en integracion");
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

            // El token que enviarás al endpoint
            var token = "Integration";

            // Serializar el token a JSON
            var json = JsonConvert.SerializeObject(token);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST al endpoint
            var response = await client.PostAsync($"{urlLocal}/GetUserWithAppoinmnet", content);


            if (response.IsSuccessStatusCode)
            {
                // Leer la respuesta
                var responseData = await response.Content.ReadAsStringAsync();
                var usuario  = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(responseData);
                return Ok(usuario);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode(500,errorContent);
            }
        }
        #region Codigo Comentado
        //[HttpPost("AddUsuario")]
        //public async Task<IActionResult> Add([FromBody] UsuarioDTO usuario)
        //{
        //    try
        //    {
        //        _unitOfWork.Usuario.Add(new Usuario
        //        {
        //            Nombres = usuario.Nombres,
        //            Apellidos = usuario.Apellidos,
        //            Correo = usuario.Correo,
        //            Clave = usuario.Clave,
        //            Telefono = usuario.Telefono,
        //            FechaNacimiento = usuario.FechaNacimiento,
        //            Cedula = usuario.Cedula,
        //            Direccion = usuario.Direccion,
        //        });
        //        await _unitOfWork.SaveAsync();
        //        return Ok();
        //    }
        //    catch (Exception ex) 
        //    {
        //        return StatusCode(500, "Ocurrió un error al guardar el usuario. " + ex.Message);
        //    }

        //}
        //[HttpGet("GetUsuario")]
        //public IActionResult Get()
        //{
        //    return Ok(_unitOfWork.Usuario.GetAll().ToList());
        //}

        //[HttpPut("UpdateUsuario")]
        //public async Task<IActionResult> Update([FromBody] UsuarioDTO usuario)
        //{
        //    try
        //    {
        //        _unitOfWork.Usuario.Update(new Usuario
        //        {
        //            Id = usuario.Id,
        //            Nombres = usuario.Nombres,
        //            Apellidos = usuario.Apellidos,
        //            Correo = usuario.Correo,
        //            Clave = usuario.Clave,
        //            Telefono = usuario.Telefono,
        //            FechaNacimiento = usuario.FechaNacimiento,
        //            Cedula = usuario.Cedula,
        //            Direccion = usuario.Direccion,
        //            Estado = usuario.Estado,
        //            FechaCreacion = usuario.FechaCreacion,
        //            UltimaModificacion = DateTime.Now,
        //        });
        //        await _unitOfWork.SaveAsync();
        //        return Ok();
        //    }
        //    catch (Exception ex) 
        //    {
        //        return StatusCode(500, "Ocurrió un error al actulizar el usuario. " + ex.Message);

        //    }
        //}
        //[HttpPut("DisableUsuario")]
        //public async Task<IActionResult> Delete([FromBody] UsuarioDTO usuario)
        //{
        //    try
        //    {
        //        _unitOfWork.Usuario.Remove(new Usuario
        //        {
        //            Id = usuario.Id,
        //            Nombres = usuario.Nombres,
        //            Apellidos = usuario.Apellidos,
        //            Correo = usuario.Correo,
        //            Clave = usuario.Clave,
        //            Telefono = usuario.Telefono,
        //            FechaNacimiento = usuario.FechaNacimiento,
        //            Cedula = usuario.Cedula,
        //            Direccion = usuario.Direccion,
        //            Estado = usuario.Estado,
        //            FechaCreacion = usuario.FechaCreacion,
        //            UltimaModificacion = DateTime.Now,
        //        });
        //        await _unitOfWork.SaveAsync();
        //        return Ok();
        //    }
        //    catch (Exception ex) 
        //    {
        //        return StatusCode(500, "Ocurrió un error al guardar el usuario. " + ex.Message);
        //    }

        //}
        #endregion
    }
}
