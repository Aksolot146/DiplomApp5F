using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5F.Models
{
    [Table("requestchat")]
    public class RequestChat
    {
        public int Id { get; set; }
        public DateTime PubTime { get; set; }
        [StringLength(4096, ErrorMessage = "Message is too long (4096 character limit)")]
        public string Message { get; set; }
        public int ProfileId { get; set; }
        public int RequestId { get; set; }

        [JsonIgnore]
        public virtual UserProfile Profile { get; set; }

        [JsonIgnore]
        public virtual Request Request { get; set; }
    }
}
