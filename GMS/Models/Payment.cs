using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class Payment
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("subscription_id")]
        public int SubscriptionId { get; set; }
        [Column("payment_type")]
        public int PaymentType { get; set; }
        [Column("discount_type")]
        public int? DiscountType { get; set; }
        [Column("percentage_values")]
        public decimal? PercentageValue { get; set; }
        [Column("discount")]
        public decimal Discount { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
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


        public virtual MembersSubscription MembersSubscription { get; set; } = null!;
    }
}
