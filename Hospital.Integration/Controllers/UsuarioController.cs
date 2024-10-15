using Hospital.Integration.Models;
using Hospital.Integration.Models.DTO;
using Hospital.Integration.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddUsuario")]
        public async Task<IActionResult> Add([FromBody] UsuarioDTO usuario)
        {
            try
            {
                _unitOfWork.Usuario.Add(new Usuario
                {
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
                    Telefono = usuario.Telefono,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Cedula = usuario.Cedula,
                    Direccion = usuario.Direccion,
                });
                await _unitOfWork.SaveAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Ocurrió un error al guardar el usuario. " + ex.Message);
            }
           
        }
        [HttpGet("GetUsuario")]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Usuario.GetAll().ToList());
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> Update([FromBody] UsuarioDTO usuario)
        {
            try
            {
                _unitOfWork.Usuario.Update(new Usuario
                {
                    Id = usuario.Id,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
                    Telefono = usuario.Telefono,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Cedula = usuario.Cedula,
                    Direccion = usuario.Direccion,
                    Estado = usuario.Estado,
                    FechaCreacion = usuario.FechaCreacion,
                    UltimaModificacion = DateTime.Now,
                });
                await _unitOfWork.SaveAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Ocurrió un error al actulizar el usuario. " + ex.Message);

            }
        }
        [HttpPut("DisableUsuario")]
        public async Task<IActionResult> Delete([FromBody] UsuarioDTO usuario)
        {
            try
            {
                _unitOfWork.Usuario.Remove(new Usuario
                {
                    Id = usuario.Id,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Correo = usuario.Correo,
                    Clave = usuario.Clave,
                    Telefono = usuario.Telefono,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Cedula = usuario.Cedula,
                    Direccion = usuario.Direccion,
                    Estado = usuario.Estado,
                    FechaCreacion = usuario.FechaCreacion,
                    UltimaModificacion = DateTime.Now,
                });
                await _unitOfWork.SaveAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Ocurrió un error al guardar el usuario. " + ex.Message);
            }

        }
    }
}
