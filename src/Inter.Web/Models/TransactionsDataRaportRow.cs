using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internety.Web.Models
{
    public class TransactionsDataRaportRow
    {
        public long TransactionId { get; set; }
        public DateTime Date { get; set; }
        public String OfficeName { get; set; }
        public String WorkerName { get; set; }
        public String WorkerSurnem { get; set; }
        public String InternetType { get; set; }
        public double Price { get; set; }
    }
}
