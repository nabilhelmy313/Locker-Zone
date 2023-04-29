using LockerZone.Domain.Dtos;
using LockerZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Application.Mapping
{
    public class FeedbackMappingProfile : MappingProfileBase
    {
        public FeedbackMappingProfile()
        {
            CreateMap<FeedbackMessage,FeedbackMessageDto>().ReverseMap();
        }
    }
}
