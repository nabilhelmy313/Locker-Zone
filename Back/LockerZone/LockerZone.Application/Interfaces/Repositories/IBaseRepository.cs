using System.Linq.Expressions;

namespace LockerZone.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> Count(Expression<Func<T, bool>> predicate = null);
        T FindByID(Guid Id);
        void Create(T obj);
        Task CreateRangeAsync(IEnumerable<T> objList);
        //void Delete(Action<T> deleteFunction, Expression<Func<T, bool>> predicate = null);
        void Delete(Guid id);
        void Update(T obj, params string[] excludedFields);

    }
}
