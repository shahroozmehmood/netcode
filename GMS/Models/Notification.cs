using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class Notification
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("content")]
        public string Content { get; set; } = null!;
        [Column("type")]
        public int Type { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<NotificationsRead> NotificationsReads { get; set; }
    }
}
