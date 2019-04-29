using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Web.Database.Models
{
    public class TransactionCreateData
    {
        public DateTime Date { get; set; }
        public IEnumerable<ViewModel> ServiceIds { get; set; }
        public IEnumerable<ViewModel> ClientIds { get; set; }
        public IEnumerable<ViewModel> WorkerIds { get; set; }

        public double Price { get; set; }
    }
}
