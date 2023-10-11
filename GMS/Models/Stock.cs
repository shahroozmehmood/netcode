using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class Stock
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("stock_sub_category_id")]
        public int StockSubCategoryId { get; set; }
        [Column("unit_sale_price")]
        public decimal UnitSalePrice { get; set; }
        [Column("unit_purchase_price")]
        public decimal UnitPurchasePrice { get; set; }
        [Column("threshold_value")]
        public int ThresholdValue { get; set; }
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



        public virtual StockSubCategory StockSubCategory { get; set; } = null!;
    }
}
