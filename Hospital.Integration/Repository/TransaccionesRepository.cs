using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class TransaccionesRepository : GenericRepository<Transacciones>, ITransaccionesRepository
    {
        private ApplicationContext _db;
        public TransaccionesRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
