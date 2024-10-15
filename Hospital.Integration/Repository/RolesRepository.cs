using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        private ApplicationContext _db;
        public RolesRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
