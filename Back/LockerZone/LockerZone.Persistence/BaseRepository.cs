using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LockerZone.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly LockerZoneDbContext _dbContext;
        private DbSet<T> table = null;
        public BaseRepository(LockerZoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbContext.Set<T>().Where(a=>!a.Is_Deleted).ToListAsync();
            else
                return await _dbContext.Set<T>().Where(a=>!a.Is_Deleted ).Where(predicate).ToListAsync();
        }

    

        public Task<int> Count(Expression<Func<T, bool>> predicate = null) =>
                        predicate == null
                ? _dbContext.Set<T>().CountAsync()
                : _dbContext.Set<T>().Where(predicate).CountAsync();

        public virtual T FindByID(Guid Id)
        {
            return _dbContext.Set<T>().FirstOrDefault(z => z.Id == Id)!;

        }

        public virtual void Create(T obj)
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Added;
        }

        public virtual async Task CreateRangeAsync(IEnumerable<T> objList)
        {
            await _dbContext.AddRangeAsync(objList);
        }

      
        public virtual void Delete(Guid id)
        {
            T existing = _dbContext.Set<T>().Find(id)!;
            existing.Is_Deleted = true;
        }

        public void Update(T obj, params string[] excludedFields)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            foreach (string fld in excludedFields)
                _dbContext.Entry(obj).Property(fld).IsModified = false;
        }


    }
}
