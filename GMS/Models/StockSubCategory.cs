using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GMS.Models
{
    public partial class StockSubCategory
    {

        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("stock_category_id")]
        public int StockCategoryId { get; set; }
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


        public virtual StockCategory StockCategory { get; set; } = null!;
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
