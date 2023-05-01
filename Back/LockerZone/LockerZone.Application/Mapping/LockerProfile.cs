using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;
using LockerZone.Domain.Entities;

namespace LockerZone.Application.Mapping
{
    public class LockerProfile:MappingProfileBase
    {
        public LockerProfile()
        {
            CreateMap<Locker, AddLockerDto>().ReverseMap();
            CreateMap<Locker, EditLockerDto>().ReverseMap();
            CreateMap<Locker, GetLockerDto>().ReverseMap();
        }
    }
}
