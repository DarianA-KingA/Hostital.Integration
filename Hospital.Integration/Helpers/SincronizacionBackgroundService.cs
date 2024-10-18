using Hospital.Integration.Context;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Hospital.Integration.Helpers
{
    public class SincronizacionBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SincronizacionBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Logger.Information("Ejecucion de tarea en segundo plano");
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    var core = new Core(context); // Crear una nueva instancia de Core en cada iteración

                    await core.TransferUser();
                    await core.TransferTransaccion();
                    await core.CerrarCitas();
                    await core.TransferirCita();
                }

                // Espera 5 minutos antes de volver a intentar (ajusta según sea necesario)
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
