using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class ServiciosRepository : GenericRepository<Servicios>, IServiciosRepository
    {
        private ApplicationContext _db;
        public ServiciosRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
