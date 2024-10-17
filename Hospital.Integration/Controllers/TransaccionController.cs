using Hospital.Integration.DTO.SaveViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransaccionController : ControllerBase
    {
        private const string token = "Integration";
        private const string urlLocal = "https://localhost:44330/Acces";
        [HttpPost("AddTransaccion")]
        public  async Task<IActionResult> AddTransaccion([FromBody] SaveTransaccionViewModel newTrans)
        {
            if (string.IsNullOrEmpty(newTrans.Token) || (newTrans.Token != SD.Token_Caja))
                return StatusCode(401, "Solicitud no autorizada");
            var client = new HttpClient();

            // Crear el objeto del modelo


            // Serializar el objeto a JSON
            newTrans.Token = token;
            var json = JsonConvert.SerializeObject(newTrans);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST al endpoint
            var response = await client.PostAsync($"{urlLocal}/AddTransaccion", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadAsStringAsync());
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode(500,$"Error al crear transaccion: {errorContent}");
            }
        }
    }
}
