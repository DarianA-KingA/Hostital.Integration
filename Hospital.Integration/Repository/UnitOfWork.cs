using Hospital.Integration.Context;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationContext _db;
        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
            AreasMedicas = new AreasMedicasRepository(db);
            Citas = new CitasRepository(db);
            EstadoTransaccion = new EstadoTransaccionRepository(db);
            PerfilesRepository = new PerfilesRepository(db);
            Roles = new RolesRepository(db);
            Servicios = new ServiciosRepository(db);
            TipoServicio = new TipoServicioRepository(db);
            TipoTransaccion = new TipoTransaccionRepository(db);    
            Transacciones = new TransaccionesRepository(db);
            Usuario = new UsuarioRepository(db);
        }
        public IAreasMedicasRepository AreasMedicas { get; private set; }
        public ICitasRepository Citas { get; private set; }
        public IEstadoTransaccionRepository EstadoTransaccion { get; private set; }
        public IPerfilesRepository PerfilesRepository { get; private set; }
        public IRolesRepository Roles { get; private set; }
        public IServiciosRepository Servicios { get; private set; }
        public ITipoServicioRepository TipoServicio { get; private set; }
        public ITipoTransaccionRepository TipoTransaccion { get; private set; }
        public ITransaccionesRepository Transacciones { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
