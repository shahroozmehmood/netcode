using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Models
{
    public partial class Member
    {

        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("father_husband_name")]
        public string FatherHusbandName { get; set; } = null!;
        [Column("member_no")]
        public string MemberNo { get; set; } = null!;
        [Column("register_at")]
        public DateTime RegisterAt { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("cnic")]
        public string Cnic { get; set; } = null!;
        [Column("address")]
        public string Address { get; set; } = null!;
        [Column("contact_no")]
        public string ContactNo { get; set; } = null!;
        [Column("gender")]
        public bool Gender { get; set; }
        [Column("height")]
        public string Height { get; set; } = null!;
        [Column("weight")]
        public string Weight { get; set; } = null!;
        [Column("vehicle_number")]
        public string? VehicleNumber { get; set; }
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

        
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<IssueLocker> IssueLockers { get; set; }
        public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; }
    }
}
