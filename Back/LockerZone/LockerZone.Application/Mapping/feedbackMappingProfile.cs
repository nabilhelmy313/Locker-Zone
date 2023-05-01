using LockerZone.Domain.Dtos;
using LockerZone.Domain.Entities;

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
