using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class PerfilesRepository : GenericRepository<Perfiles>, IPerfilesRepository
    {
        private ApplicationContext _db;
        public PerfilesRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
