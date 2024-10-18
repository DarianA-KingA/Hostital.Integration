using Flurl.Http;
using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Hospital.Integration.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Hospital.Integration.Helpers
{
    public class Core
    {
        private readonly ApplicationContext _context;
        public Core( ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<bool> CheckHealth()
        {
            try
            {
                // Llamar al endpoint de health check de la aplicación web
                var response = await $"{SD.coreUrl}/health"
                    .GetAsync();

                // Si la respuesta es exitosa (200 OK), significa que la web está disponible
                if (response.StatusCode == 200)
                {
                    return true; // La aplicación web está disponible
                }
                else
                {
                    return false; // La aplicación web no está disponible
                }
            }
            catch (FlurlHttpException)
            {
                return false; // Si hay una excepción, la aplicación web no está disponible
            }

        }
        public async Task TransferUser()
        {
            if (!await CheckHealth())
                return;
            string baseUrlUser = $"{SD.localURL}/CreateUser";
            var usarios =  _context.Usuarios.AsNoTracking().Where(u => u.Pendiente);
            foreach (var usario in usarios)
            {
                var model = new SaveUserViewModel() 
                {
                    UserName = usario.UserName,
                    Email = usario.Email,
                    Name =  usario.Name,
                    LastName = usario.LastName,
                    PhoneNumber = usario.PhoneNumber,
                    Address = usario.Address,
                    Birthday = usario.Birthday,
                    Cedula = usario.Cedula,
                    Password = usario.Password,
                    RoleName = usario.RoleName,
                    Token = SD.Token_Integration
                };
                try
                {
                    var result = await baseUrlUser.PostJsonAsync(model);
                    if (result.ResponseMessage.IsSuccessStatusCode)
                    {
                        Log.Logger.Information($"Usuario {usario.UserName} sincronizado con el core.");
                        usario.Pendiente = false;
                        _context.Usuarios.Update( usario );
                        _context.SaveChanges();
                    }
                }
                catch (FlurlHttpException ex)
                {
                        Log.Logger.Error($"Error al sincronizar Usuario {usario.UserName} con el core: {ex.Message}");

                }

            }
        }
        public async Task TransferTransaccion()
        {
            if (!await CheckHealth())
                return;
            string baseUrlUser = $"{SD.localURL}/AddTransaccion";
            var transacciones = _context.Transacciones.AsNoTracking().Where(t=>t.Pendiente).ToList();
            foreach (var trans in transacciones)
            {
                var model = new SaveTransaccionViewModel()
                {
                    IdCajero = trans.IdCajero,
                    IdPaciente = trans.IdPaciente,
                    IdEstadoTransaccion = trans.IdEstadoTransaccion,
                    IdTipoTransaccion = trans.IdTipoTransaccion,
                    Monto = trans.Monto,
                    Fecha = trans.Fecha,
                    Comentario = trans.Comentario ?? string.Empty,
                    Token = SD.Token_Integration
                };
                try
                {
                    var result = await baseUrlUser.PostJsonAsync(model);
                    if (result.ResponseMessage.IsSuccessStatusCode)
                    {
                        Log.Logger.Information($"Transaccion [ID: {trans.Id}] sincroizada a core.");
                        trans.Pendiente = false;
                        _context.Transacciones.Update(trans);
                        _context.SaveChanges();
                    }
                }
                catch (FlurlHttpException ex)
                {
                    Log.Logger.Error($"Error al sincronizar Transaccion [ID: {trans.Id}] con el core: {ex.Message}");

                }
            }
        }
        public async Task TransferirCita()
        {
            if (!await CheckHealth())
                return;
            string baseUrlUser = $"{SD.localURL}/AddCita";
            var citas = _context.Citas.AsNoTracking().Where(t => t.Pendiente && t.Accion == SD.Accion_Agregar).ToList();
            foreach (var cita in citas)
            {
                var model =  new SaveCitaViewModel()
                {
                    IdPaciente = cita.IdPaciente,
                    IdServicio = cita.IdServicio,
                    FechaAgendada = cita.FechaAgendada,
                    idHorarioCita = cita.IdHorarioCita,
                    Estado = cita.Estado,
                    Token = SD.Token_Integration
                };
                try
                {
                    var result = await baseUrlUser.PostJsonAsync(model);
                    if (result.ResponseMessage.IsSuccessStatusCode)
                    {
                        Log.Logger.Information($"Cita sincronizada [ID: {cita.Id}] con el core.");
                        cita.Pendiente = false;
                        _context.Citas.Update(cita);
                        _context.SaveChanges();
                    }
                }
                catch (FlurlHttpException ex)
                {
                    Log.Logger.Error($"Error al sincronizar Cita [ID: {cita.Id}] con el core: {ex.Message}");

                }
            }
        }
        public async Task CerrarCitas()
        {
            if (!await CheckHealth())
                return;
            string baseUrlUser = $"{SD.localURL}/CloseCitas";
            var citas = _context.Citas.AsNoTracking().Where(t => t.Pendiente && t.Accion == SD.Accion_Modificar).ToList();
            foreach (var cita in citas)
            {
                var model = new 
                {
                    IdCita = cita.IdCita,
                    Token = SD.Token_Integration
                };
                try
                {
                    var result = await baseUrlUser.PostJsonAsync(model);
                    if (result.ResponseMessage.IsSuccessStatusCode)
                    {
                        Log.Logger.Information($"Cita sincronizada [ID: {cita.Id}] con el core.");
                        cita.Pendiente = false;
                        _context.Citas.Update(cita);
                        _context.SaveChanges();
                    }
                }
                catch (FlurlHttpException ex)
                {
                    Log.Logger.Error($"Error al sincronizar Cita [ID: {cita.Id}] con el core: {ex.Message}");

                }
            }
        }
    }
}
