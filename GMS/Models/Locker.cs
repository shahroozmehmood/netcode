using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class Locker
    {
        public Locker()
        {
            IssueLockers = new HashSet<IssueLocker>();
        }
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("number")]
        public string Number { get; set; } = null!;
        [Column("status")]
        public string Status { get; set; } = null!;
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

        
        public virtual ICollection<IssueLocker> IssueLockers { get; set; }
    }
}
