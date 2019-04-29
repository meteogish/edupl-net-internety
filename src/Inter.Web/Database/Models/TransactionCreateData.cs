using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Web.Database.Models
{
    public class TransactionCreateData
    {
        public DateTime Date { get; set; }
        public IEnumerable<long> ServiceId { get; set; }
        public IEnumerable<long> ClientId { get; set; }
        public IEnumerable<long> WorkerId { get; set; }

        public double Price { get; set; }
    }
}
