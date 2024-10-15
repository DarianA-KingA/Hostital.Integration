using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class CitasRepository : GenericRepository<Citas>, ICitasRepository
    {
        private ApplicationContext _db;
        public CitasRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
