using LockerZone.Application;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Entities;

namespace Application.Mapping.Attachments
{
    public class AttachmentProfile:MappingProfileBase
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment,AttachmentDto>().ReverseMap();
        }
    }
}
