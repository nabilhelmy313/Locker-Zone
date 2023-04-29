using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Entities
{
    public class FeedbackMessage:BaseEntity
    {
        public string Message { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty ;
        public string Name { get; set; } = string.Empty;
    }
}
