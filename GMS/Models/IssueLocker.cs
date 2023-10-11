using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GMS.Models
{
    public partial class IssueLocker
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("locker_id")]
        [ForeignKey("locker_id")]
        public int LockerId { get; set; }
        [Column("member_id")]
        [ForeignKey("member_id")]
        public int MemberId { get; set; }
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

        
        public virtual Locker Locker { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
