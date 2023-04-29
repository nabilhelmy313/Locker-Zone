using AutoMapper;
using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Persistence;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LockerZoneDbContext _dbContext;

        public IMapper Mapper { get; }
        public IFeebackRepository FeebackRepository { get; }
        public UnitOfWork(LockerZoneDbContext dbContext,
            IMapper mapper,
            IFeebackRepository feebackRepository)
        {
            _dbContext = dbContext;
            Mapper = mapper;
            FeebackRepository = feebackRepository;
        }


        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
