using Hospital.Integration.Context;
using Hospital.Integration.Models;
using Hospital.Integration.Repository.Interface;

namespace Hospital.Integration.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private ApplicationContext _db;
        public UsuarioRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
    }
}
