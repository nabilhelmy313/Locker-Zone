using LockerZone.Application;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Entities;

namespace Application.Mapping.Auth
{
    internal class Authprofile:MappingProfileBase
    {
        public Authprofile()
        {
            CreateMap<ApplicationUser, RegisterDto>()
              .ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(c => c.ProfilePicture, c => c.Ignore())
                .ReverseMap();
            CreateMap<TokenEntity, TokenDto>()
                .ReverseMap();
            
        }
    }
}
