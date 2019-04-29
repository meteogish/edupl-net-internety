using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inter.Web.Database.Models;
using Inter.Web.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inter.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        public double Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        public SelectList WorkersIds { get; set; }
        public SelectList ClientIds { get; set; }
        public SelectList ServiceIds { get; set; }

        private TransactionsRepository _transactionsRepository;

        public PrivacyModel(TransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        
        public void OnGet()
        {
            // _transactionsRepository.AddTransaction(new Database.Models.TransactionCreateData(){
            //     ClientIds = 1,
            //     ServiceIds = 1,
            //     Date = DateTime.Now.AddDays(-10),
            //     WorkerIds = 1,
            //     Price = 66.12
            // });

            var data = _transactionsRepository.GetTransactionCreateData();

            ClientIds = new SelectList(data.ClientIds, nameof(ViewModel.Id), nameof(ViewModel.Name));
            WorkersIds = new SelectList(data.WorkerIds, nameof(ViewModel.Id), nameof(ViewModel.Name));
            ServiceIds = new SelectList(data.ServiceIds, nameof(ViewModel.Id), nameof(ViewModel.Name));
        }
    }
}