using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Domain.Entities;

namespace LockerZone.Persistence.Repositories
{
    public class LockerRepository:BaseRepository<Locker>,ILockerRepository
    {
        public LockerRepository(LockerZoneDbContext dbContext):base(dbContext) { }
       
    }
}
