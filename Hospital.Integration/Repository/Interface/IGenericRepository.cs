using System.Linq.Expressions;

namespace Hospital.Integration.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string? includeProperties = null, bool tracked = true);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
