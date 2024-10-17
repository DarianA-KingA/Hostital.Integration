using Hospital.Integration.DTO.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiciosController : ControllerBase
    {
        private const string token = "Integration";
        private const string urlLocal = "https://localhost:44330/Acces";
        [HttpPost("GetServicios")]

        public async Task<IActionResult> GetServicios([FromBody] string tokenRequest)
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
            var response = await client.PostAsync($"{urlLocal}/GetServicios", content);


            if (response.IsSuccessStatusCode)
            {
                // Leer la respuesta
                var responseData = await response.Content.ReadAsStringAsync();
                var Servicio = JsonConvert.DeserializeObject<List<ServicioViewModel>>(responseData);
                return Ok(Servicio);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode(500, errorContent);
            }
        }
    }
}
