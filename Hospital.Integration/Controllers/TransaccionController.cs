using Flurl.Http;
using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.DTO.ViewModel;
using Hospital.Integration.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Hospital.Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransaccionController : ControllerBase
    {
        ApplicationContext _context;
        Core _core;
        public TransaccionController(ApplicationContext context)
        {
            _context = context;
            _core = new Core(context);
        }
        [HttpPost("AddTransaccion")]
        public async Task<IActionResult> AddTransaccion([FromBody] SaveTransaccionViewModel newTrans)
        {
            if (string.IsNullOrEmpty(newTrans.Token) || (newTrans.Token != SD.Token_Caja))
                return StatusCode(401, "Solicitud no autorizada");
            try
            {
                var apiUrl = $"{SD.localURL}/AddTransaccion";
                newTrans.Token = SD.Token_Integration;
                
                var horarios = await apiUrl
                    .PostJsonAsync(newTrans)               
                    .ReceiveJson<int>();   
                return Ok(horarios);
            }
            catch (FlurlHttpException ex)
            {
                if (!await _core.CheckHealth())
                {
                    var result = _context.Transacciones.Add(new Models.Transacciones() 
                    {
                        IdCajero = newTrans.IdCajero,
                        IdPaciente = newTrans.IdPaciente,
                        IdTipoTransaccion = newTrans.IdTipoTransaccion,
                        IdEstadoTransaccion = newTrans.IdEstadoTransaccion,
                        Monto = newTrans.Monto,
                        Fecha = newTrans.Fecha,
                        Comentario = newTrans.Comentario??string.Empty,
                        Pendiente = true,
                        Accion = SD.Accion_Agregar,
                        Estado = true
                    });
                    _context.SaveChanges();
                    Log.Logger.Information($"Nueva transanccion [ID {result.Entity.Id}] guardado en integración pendiente de sincronización");
                    return StatusCode(200, "Transanccion guardado en integración pendiente de sincronización");

                }
                Log.Logger.Error($"Error al guardar transaccion: {ex.Message}");
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }
    }
}
