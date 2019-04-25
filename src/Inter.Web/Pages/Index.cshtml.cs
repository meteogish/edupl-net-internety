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
                    StartDate = new DateTime(2019, 05, 05),
                    FinishDate = new DateTime(2019, 05, 19),
                    InternetTypeIds = new List<long>(){
                    3
                    },
                    OfficeId = 1,
                    WorkerIds = new List<long>() {
                        1
                    }
                };
            }
            else {
                filter = JsonConvert.DeserializeObject<TransactionFilter>(f);
            }

            TableData = _transactionRepository
                .GetTransactionsInfo(filter);

            Offices = new SelectList(TableData
                .Select(td => new ViewModel(td.OfficeId, td.OfficeName))
                .Distinct()
                .Concat(new[] {
                    new ViewModel(12L, "12"),
                    new ViewModel(13L, "13"),
                    new ViewModel(14L, "14")}
                ), nameof(ViewModel.Id), nameof(ViewModel.Name));

            Workers = TableData
                .Select(td => new ViewModel(td.WorkerId, $"{td.WorkerName} {td.WorkerSurname}"))
                .Distinct()
                .Concat(new[] {
                    new ViewModel(12L, "12"),
                    new ViewModel(13L, "13"),
                    new ViewModel(14L, "14")}
                ).Select(vm => new SelectListItem(vm.Name, vm.Id.ToString())).ToList();

            InternetTypes = TableData
            .Select(td => new ViewModel(td.InternetTypeId, td.InternetType))
            .Distinct()
            .Concat(new[] {
                    new ViewModel(12L, "12"),
                    new ViewModel(13L, "13"),
                    new ViewModel(14L, "14")}
            ).Select(vm => new SelectListItem(vm.Name, vm.Id.ToString())).ToList();
        }

        public IActionResult OnPost(string officeId, string[] workerIds, string[] internetTypesIds)
        {
            TransactionFilter Filter = new TransactionFilter() {
            OfficeId = long.Parse(officeId),
            WorkerIds = workerIds.Select(str => long.Parse(str)).ToList(),
            InternetTypeIds = internetTypesIds.Select(str => long.Parse(str)).ToList(),
            StartDate = new DateTime(2019, 05, 05),
            FinishDate = new DateTime(2019, 05, 19)
            };

            TempData["Filter"] = JsonConvert.SerializeObject(Filter);
            return RedirectToPage("Index");
        }
    }

    public class ViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ViewModel(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
