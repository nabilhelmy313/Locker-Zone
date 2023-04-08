using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public Guid? Created_By { get; set; }
        public Guid? Last_Modified_By { get; set; }
        public DateTime? Last_Modified_Date { get; set; }
    }
}
