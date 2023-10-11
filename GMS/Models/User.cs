using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class User
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; } = null!;
        [Column("last_name")]
        public string LastName { get; set; } = null!;
        [Column("email")]
        public string Email { get; set; } = null!;
        [Column("gender")]
        public bool Gender { get; set; }
        [Column("password")]
        public string Password { get; set; } = null!;
        [Column("token")]
        public string Token { get; set; } = null!;
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
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
