using Domain.Dto.General.Auth;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.Auth
{
    internal class Authprofile:MappingProfileBase
    {
        public Authprofile()
        {
            CreateMap<ApplicationUser, RegisterDto>()
              .ReverseMap();
            CreateMap<TokenEntity, TokenDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(c => c.ProfilePicture, c => c.Ignore())
                .ReverseMap();
        }
    }
}
