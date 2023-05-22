using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Dtos.Locker
{
    public class GetLockerDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public string FromDay { get; set; }=string.Empty;
        public string ToDay { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
