using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inter.Web.Database.Models;
using Inter.Web.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inter.Web.Pages
{
    public class IndexModel : PageModel
    {
        private TransactionsRepository _transactionRepository;

        public IEnumerable<TransactionInfoResult> tableData;

        public IndexModel(TransactionsRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;   
        }

        public void OnGet()
        {
            tableData = _transactionRepository
                .GetTransactionsInfo(new Database.Models.TransactionFilter(){
                    StartDate = new DateTime(2019, 05, 05),
                    FinishDate = new DateTime(2019, 05, 19),
                    InternetTypeIds = new List<long>(){
                    3
                    },
                    OfficeId = 1,
                    WorkerIds = new List<long>() {
                        1
                    }
                });
        }
    }
}
