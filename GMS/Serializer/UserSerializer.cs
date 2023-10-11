using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS.Serializer
{
    public class UserSerializer
    {

        public int Id { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; } = null!;
        [JsonProperty("password")]
        public string UserPassword { get; set; } = null!;
        public int IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        [JsonProperty("role_id")]
        public int? RoleId { get; set; }
        public string? Token { get; set; }
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
        [JsonProperty("last_name")]
        public string? LastName { get; set; }
        [JsonProperty("gender")]
        public int? Gender { get; set; }
    }
}
