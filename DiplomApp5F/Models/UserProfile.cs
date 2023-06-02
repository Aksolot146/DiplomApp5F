using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5F.Models
{
    [Table("userprofile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int DeptId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        //[JsonIgnore]
        public virtual UserRank UserRank { get; set; }
        //[JsonIgnore]
        public virtual Department Department { get; set; }

        [JsonIgnore]
        public virtual ICollection<Request> Request { get; set; } = new HashSet<Request>();
    }
}
