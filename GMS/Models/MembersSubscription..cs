using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class MembersSubscription
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("member_id")]
        [ForeignKey("member_id")]
        public int MemberId { get; set; }
        [Column("subscription_plan_id")]
        [ForeignKey("subscription_plan_id")]
        public int SubscriptionPlanId { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("duration")]
        public int Duration { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
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


        public virtual Member Member { get; set; } = null!;
        public virtual SubscriptionPlan SubscriptionPlan { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
