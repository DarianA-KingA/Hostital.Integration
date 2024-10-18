using Flurl;
using Flurl.Http;
using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.Helpers;
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
    public class CitasController : ControllerBase
    {
        ApplicationContext _context;
        Core _core;
        public CitasController(ApplicationContext context)
        {
            _context = context;
            _core = new Core(context);
        }
        [HttpPost("CloseCita")]

        public  async Task<IActionResult> CloseCita([FromBody] CloseCitaIVewModel cita)
        {
            if ( string.IsNullOrEmpty(cita.Token)|| (cita.Token != SD.Token_Caja && cita.Token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");
            try
            {
                var client = new HttpClient();
                var token  = cita.Token;
                // Crear el objeto del modelo
                var newUser = new
                {
                    IdCita = cita.IdCita,
                    Token = SD.Token_Integration
                };

                // Serializar el objeto a JSON
                var json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST al endpoint
                var response = await client.PostAsync($"{SD.localURL}/CloseCitas", content);

                if (response.IsSuccessStatusCode)
                {
                    Log.Logger.Information($"Cita cerrada por {token}");
                    return Ok(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Log.Logger.Error(errorContent);
                    return StatusCode(500, $"Error al cerrar cita: {errorContent}");
                }
            }
            catch (Exception ex) 
            {
                if (!await _core.CheckHealth())
                {
                    var result = _context.Citas.Add(new Models.Cita()
                    {
                        IdCita = cita.IdCita,
                        IdHorarioCita = 1,
                        IdPaciente = "Para cerrar cita",
                        IdServicio = 1,
                        Pendiente = true,
                        FechaAgendada = DateTime.Now,
                        Accion = SD.Accion_Modificar,
                        Estado = true,
                    });
                    _context.SaveChanges();
                    Log.Logger.Information($"Nueva cita [ID {result.Entity.Id}] guardado en integración pendiente de sincronización");
                    return StatusCode(200, "Cita guardado en integración pendiente de sincronización");

                }
                Log.Logger.Error(ex.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
            
        }
        [HttpPost("AddCita")]
        public async Task<IActionResult> AddCita([FromBody] SaveCitaViewModel model)
        {
            if (string.IsNullOrEmpty(model.Token) || (model.Token != SD.Token_Caja && model.Token != SD.Token_Web))
                return StatusCode(401, "Acceso no autorizado");
            try
            {
                var apiUrl = $"{SD.localURL}/AddCita";
                model.Token = SD.Token_Integration;
                var response = await apiUrl.PostJsonAsync(model);  

                if (response.StatusCode == 200)
                {
                    Log.Logger.Information("Cita agregada");
                    return Ok();
                }
                else
                {
                    Log.Logger.Warning(await response.GetStringAsync());
                    return StatusCode((int)response.StatusCode, await response.GetStringAsync());
                }
            }
            catch (FlurlHttpException ex)
            {
                if (!await _core.CheckHealth())
                {
                    var result = _context.Citas.Add(new Models.Cita()
                    {
                        IdCita = model.Id,
                        IdHorarioCita = model.idHorarioCita,
                        IdPaciente = model.IdPaciente,
                        IdServicio = model.IdServicio,
                        Pendiente = true,
                        FechaAgendada = model.FechaAgendada,
                        Accion = SD.Accion_Agregar,
                        Estado = true,
                    });
                    _context.SaveChanges();
                    Log.Logger.Information($"Nueva cita [ID {result.Entity.Id}] guardado en integración pendiente de sincronización");
                    return StatusCode(200, "Cita guardado en integración pendiente de sincronización");

                }
                Log.Logger.Error(ex.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

    }
}
