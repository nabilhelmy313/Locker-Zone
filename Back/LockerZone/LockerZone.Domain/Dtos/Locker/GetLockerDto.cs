using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Dtos.Locker
{
    public class GetLockerDto
    {
        public int Number { get; set; }
        public double Price { get; set; }
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
        public string? Description { get; set; }
    }
}
