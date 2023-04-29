using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Dtos
{
    public class FeedbackMessageDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }=string.Empty;
        public string Message { get; set; }=string.Empty;
    }
}
