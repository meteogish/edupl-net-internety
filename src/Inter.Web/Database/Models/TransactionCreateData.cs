using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Web.Database.Models
{
    public class TransactionCreateData
    {
        public DateTime Date { get; set; }
        public long ServiceId { get; set; }
        public long ClientId { get; set; }
        public long WorkerId { get; set; }

        public string ServiceName { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public double Price { get; set; }
    }
}
