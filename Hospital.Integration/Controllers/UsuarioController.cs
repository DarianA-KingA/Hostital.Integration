using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.DTO.ViewModel;
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
        public UsuarioController( )
        {
        }
        [HttpPost("AddUsuario")]

        public  async Task<IActionResult> AddUser([FromBody] SaveUserViewModel newUser)
        {
            if(string.IsNullOrEmpty(newUser.Token) ||(newUser.Token != SD.Token_Caja && newUser.Token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");
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
                return StatusCode(500,errorContent);
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
