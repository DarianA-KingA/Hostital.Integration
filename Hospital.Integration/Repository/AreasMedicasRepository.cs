using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class AreasMedicasRepository : GenericRepository<AreasMedicas>, IAreasMedicasRepository
    {
        private ApplicationContext _db;
        public AreasMedicasRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
