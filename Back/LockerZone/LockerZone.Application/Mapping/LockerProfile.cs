using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;
using LockerZone.Domain.Entities;

namespace LockerZone.Application.Mapping
{
    public class LockerProfile : MappingProfileBase
    {
        public LockerProfile()
        {
            CreateMap<Locker, AddLockerDto>().ReverseMap();
            CreateMap<Locker, EditLockerDto>().ReverseMap();
            CreateMap<Locker, GetLockerDto>().
                ForMember(c => c.FromDay, c => c.MapFrom(a => a.FromDay.ToString("yyyy-MM-dd"))).
                ForMember(c => c.ToDay, c => c.MapFrom(a => a.ToDay.ToString("yyyy-MM-dd"))).ReverseMap();
        }
    }
}
