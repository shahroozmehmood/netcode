using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    
    public partial class Invoice
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("stock_category")]
        public string StockCategory { get; set; } = null!;
        [Column("stock_sub_category")]
        public string StockSubCategory { get; set; } = null!;
        [Column("unit_sale_price")]
        public decimal UnitSalePrice { get; set; }
        [Column("unit_purchase_price")]
        public decimal UnitPurchasePrice { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("member_id")]
        [ForeignKey("member_id")]
        public int MemberId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("discount_type")]
        public int? DiscountType { get; set; }
        [Column("precentage_value")]
        public decimal? PercentageValue { get; set; }
        [Column("discount")]
        public decimal Discount { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("modify_by")]
        public int? ModifyBy { get; set; }
        [Column("modify_at")]
        public DateTime? ModifyAt { get; set; }

       
        public virtual Member Member { get; set; } = null!;
    }
}
