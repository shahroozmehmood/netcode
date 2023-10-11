using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class NotificationsRead
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("user_id")]
        [ForeignKey("user_id")]
        public int UserId { get; set; }
        [Column("notification_id")]
        [ForeignKey("notification_id")]
        public int NotificationId { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public virtual Notification Notification { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
