using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5F.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime AuthDate { get; set; }

        public virtual UserProfile Profile { get; set; }
    }
}
