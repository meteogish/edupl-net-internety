using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inter.Web.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inter.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(TransactionsRepository repos)
        {
            TransactionsRepository repo = repos;
            repo.GetTransactionsInfo(new Database.Models.TransactionFilter(){
                FinishDate = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now.AddDays(-1000),
                InternetTypeIds = new List<long>(){
                   2
                },
                OfficeId = 2,
                WorkerIds = new List<long>() {
                    2
                }
            });   
        }
        public void OnGet()
        {

        }
    }
}
