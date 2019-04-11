using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internety.Web.Models
{
    public class TransactionInfoResult
    {
        public long TransactionId { get; set; }
        public DateTime Date { get; set; }
        public long OfficeId { get; set; }
        public String OfficeName { get; set; }
        public long WorkerId { get; set; }
        public String WorkerName { get; set; }
        public String WorkerSurnem { get; set; }
        public long InternetTypeId { get; set; }
        public String InternetType { get; set; }
        public double Price { get; set; }
    }
}
