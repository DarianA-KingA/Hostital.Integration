using Flurl;
using Flurl.Http;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.DTO.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorariosController : ControllerBase
    {
        [HttpPost("GetHorarios")]
        public async Task<IActionResult> GetHorarios([FromBody] string token)
        {
            if (string.IsNullOrEmpty(token) || (token != SD.Token_Caja && token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");
            try
            {
                // Definir la URL de la API que contiene el endpoint GetHorarios
                var apiUrl = $"{SD.localURL}/GetHorarios";

                // Llamada POST enviando el token como parte del cuerpo de la solicitud
                var horarios = await apiUrl
                    .PostJsonAsync(SD.Token_Integration)               // Envía el token en el cuerpo de la solicitud
                    .ReceiveJson<List<HorarioViewModel>>();   // Recibe los horarios como una lista de HorarioDTO

                // Retorna los datos de horarios en la respuesta HTTP si la solicitud es exitosa
                Log.Logger.Information("Informacion solicitada de horarios");
                return Ok(horarios);
            }
            catch (FlurlHttpException ex)
            {
                // Maneja errores HTTP y devuelve un estado 500 con el mensaje de error
                Log.Logger.Warning(ex.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }      
}
