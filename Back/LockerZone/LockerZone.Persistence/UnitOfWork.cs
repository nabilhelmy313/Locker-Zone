using AutoMapper;
using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Persistence;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LockerZoneDbContext _dbContext;

        public IMapper Mapper { get; }
        public UnitOfWork(LockerZoneDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            Mapper = mapper;
        }


        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
