
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Domain.Entities
{
    [Index(nameof(MasterData_Code), IsUnique = true)]
    public class MasterData : BaseEntity
    {
        public string? MasterData_Category_Code { get; set; }
        [StringLength(5, MinimumLength = 5)]
        public string MasterData_Code { get; set; } = string.Empty;
        public string? MasterData_TitleAr { get; set; }
        public string MasterData_TitleEn { get; set; } = string.Empty;
        public virtual ICollection<Product>? SizeProducts { get; set; }
        public virtual ICollection<Product>? ProductsMode { get; set; }
    }
}
