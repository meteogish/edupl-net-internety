using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inter.Web.Database.Models
{
    public class TransactionFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public long? OfficeId { get; set; }
        public IEnumerable<long> WorkerIds { get; set; }
        public IEnumerable<long> InternetTypeIds { get; set; }
    }
}
