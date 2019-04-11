﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internety.Web.Models
{
    public class TransactionFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public long OfficeId { get; set; }
        public List<long> WorkerId{ get; set; }
        public List<long> InternetTypeIds { get; set; }
    }
}
