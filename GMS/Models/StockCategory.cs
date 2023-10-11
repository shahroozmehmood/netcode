using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class StockCategory
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("modify_by")]
        public int? ModifyBy { get; set; }
        [Column("modify_at")]
        public DateTime? ModifyAt { get; set; }

        public virtual ICollection<StockSubCategory> StockSubCategories { get; set; }
        
    }
}
