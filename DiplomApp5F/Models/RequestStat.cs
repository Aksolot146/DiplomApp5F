using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5F.Models
{
    [Table("requeststats")]
    public class RequestStat
    {
        public int Id { get; set; }
        public int ActualRequestsCount { get; set; }
        public int NonActualRequestsCount { get; set; }
        public float CompleteRequests { get; set; }
        public float DeclinedRequests { get; set; }
        public float ExpiredRequests { get; set; }
    }
}
