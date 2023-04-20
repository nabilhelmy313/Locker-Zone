using System.ComponentModel.DataAnnotations;

namespace LockerZone.Domain.Entities
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
