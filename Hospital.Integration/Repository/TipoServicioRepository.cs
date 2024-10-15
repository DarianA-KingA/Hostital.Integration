using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class TipoServicioRepository : GenericRepository<TipoServicio>, ITipoServicioRepository
    {
        private ApplicationContext _db;
        public TipoServicioRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
