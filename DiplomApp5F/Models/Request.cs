using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5F.Models
{
    [Table("request")]
    public class Request
    {
        public int Id { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Title is too long (64 character limit)")]
        public string Title { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Vendor name is too long (64 character limit)")]
        public string Vendor { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Model name is too long (64 character limit)")]
        public string Model { get; set; }
        //[Required]
        [StringLength(64, ErrorMessage = "Part number is too long (64 character limit)")]
        public string PartNumber { get; set; }
        //[Required]
        [StringLength(1024, ErrorMessage = "Description is too long (1024 character limit)")]
        public string Description { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public int ProfileId { get; set; }
        public int StatusId { get; set; }
        public int RequesterId { get; set; }
        public DateTime CompleteTime { get; set; }

        [JsonIgnore]
        public virtual UserProfile Profile { get; set; }

        [JsonIgnore]
        public virtual RequestStatus RequestStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequestChat> RequestChat { get; set; } = new HashSet<RequestChat>();
    }
}
