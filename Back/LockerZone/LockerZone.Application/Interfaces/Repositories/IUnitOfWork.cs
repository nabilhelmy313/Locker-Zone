using AutoMapper;

namespace LockerZone.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        public IMapper Mapper { get; }
        public IFeebackRepository FeebackRepository { get;  }
        public ILockerRepository LockerRepository { get;  }
    }
}
