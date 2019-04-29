using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inter.Web.Database.Models;
using Inter.Web.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Inter.Web.Pages
{
    public class IndexModel : PageModel
    {
        private TransactionsRepository _transactionRepository;

        public IEnumerable<TransactionInfoResult> TableData { get; private set; }

        public SelectList Offices { get; private set; }

        public List<SelectListItem> Workers { get; set; }

        public List<SelectListItem> InternetTypes { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime FinishDate { get; set; } = DateTime.Now;

        public IndexModel(TransactionsRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void OnGet(string passed)
        {
            TransactionFilter filter;
            string f = (string) TempData["Filter"];

            if(f == null)
            {
                filter = new Database.Models.TransactionFilter()
                {
                    StartDate = null,
                    FinishDate = null,
                    InternetTypeIds = Enumerable.Empty<long>(),
                    OfficeId = 1,
                    WorkerIds = Enumerable.Empty<long>()
                };
            }
            else {
                filter = JsonConvert.DeserializeObject<TransactionFilter>(f);
            }

            TableData = _transactionRepository
                .GetTransactionsInfo(filter);

            var dt = TableData
                .Select(td => new ViewModel(td.OfficeId, td.OfficeName))
                .Distinct();

            Offices = new SelectList(dt
                , nameof(ViewModel.Id), nameof(ViewModel.Name));

            Workers = TableData
                .Select(td => new ViewModel(td.WorkerId, $"{td.WorkerName} {td.WorkerSurname}"))
                .Distinct()
                .Select(vm => new SelectListItem(vm.Name, vm.Id.ToString())).ToList();

            InternetTypes = TableData
            .Select(td => new ViewModel(td.InternetTypeId, td.InternetType))
            .Distinct()
            .Select(vm => new SelectListItem(vm.Name, vm.Id.ToString())).ToList();
        }

        public IActionResult OnPost(DateTime startDate, DateTime finishDate, string officeId, string[] workerIds, string[] internetTypesIds)
        {
            TransactionFilter Filter = new TransactionFilter() {
            OfficeId = long.Parse(officeId),
            WorkerIds = workerIds.Select(str => long.Parse(str)).ToList(),
            InternetTypeIds = internetTypesIds.Select(str => long.Parse(str)).ToList(),
            StartDate = startDate,
            FinishDate = finishDate
            };

            TempData["Filter"] = JsonConvert.SerializeObject(Filter);
            return RedirectToPage("Index");
        }
    }
}
