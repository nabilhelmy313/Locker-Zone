using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Persistence.Repositories
{
    public class FeedbackRepository : BaseRepository<FeedbackMessage>, IFeebackRepository
    {
        public FeedbackRepository(LockerZoneDbContext dbContext) : base(dbContext) { }
    }
}
