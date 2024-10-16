using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class TipoTransaccionRepository : GenericRepository<TipoTransaccion>, ITipoTransaccionRepository
    {
        private ApplicationContext _db;
        public TipoTransaccionRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
