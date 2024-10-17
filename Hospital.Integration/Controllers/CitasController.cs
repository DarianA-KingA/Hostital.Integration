using Hospital.Integration.DTO.SaveViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitasController : ControllerBase
    {
        private const string token = "Integration";
        private const string urlLocal = "https://localhost:44330/Acces";
        [HttpPost("CloseCita")]

        public  async Task<IActionResult> CloseCita([FromBody] CloseCitaIVewModel cita)
        {
            if ( string.IsNullOrEmpty(cita.Token)|| (cita.Token != SD.Token_Caja && cita.Token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");

            var client = new HttpClient();

            // Crear el objeto del modelo
            var newUser = new
            {
                IdCita = cita.IdCita,
                Token = "Integration"
            };

            // Serializar el objeto a JSON
            var json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST al endpoint
            var response = await client.PostAsync($"{urlLocal}/CloseCitas", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode(500,$"Error al cerrar cita: {errorContent}");
            }
        }
    }
}
