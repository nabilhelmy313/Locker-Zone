﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Entities
{
    public class ApplicationRole:IdentityRole<Guid>
    {
        public virtual ICollection<ApplicationUser>  ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
