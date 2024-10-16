using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class EstadoTransaccionRepository : GenericRepository<EstadoTransaccion>, IEstadoTransaccionRepository
    {
        private ApplicationContext _db;
        public EstadoTransaccionRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
