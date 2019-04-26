using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Inter.Web.Database.Models;

namespace Inter.Web.Database.Repositories
{
    public class TransactionsRepository
    {
        IDbConnection conn;
        public TransactionsRepository(IDbConnection connection)
        {
            conn=connection;
        }
        public IEnumerable<TransactionInfoResult> GetTransactionsInfo(TransactionFilter filter)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate(
                @"
                select t.Transaction_ID as TransactionId, 
                t.Date, 
                o.Office_ID as OfficeId, 
                o.Name as OfficeName, 
                w.Worker_ID as WorkerId, 
                w.Name as WorkerName,
                w.Surname as WorkerSurname, 
                it.InternetType_ID as InternetTypeId, 
                it.InternetType_Name as InternetType, 
                t.Price 
                from Transactions t
                join Services s on t.Service_ID=s.Service_ID
                join Internet i on s.Internet_ID=i.Internet_ID
                join InternetType it on it.InternetType_ID=i.InternetType_ID
                join Workers w on w.Worker_ID=t.Worker_ID
                join Office o on o.Office_ID=w.Office_ID
                /**where**/
                "
            );
            
            //note the 'where' in-line comment is required, it is a replacement token
            // var selector = builder.AddTemplate("select * from table /**where**/");

            if(filter.FinishDate == null)
            {
                filter.FinishDate = DateTime.Now;
            }

            if(filter.StartDate == null)
            {
                filter.StartDate = DateTime.MinValue;
            }
            builder.Where("o.Office_ID = @OfficeId");
            builder.Where("t.Date between @StartDate and @FinishDate");
            
            if(filter.InternetTypeIds.Any())
            {
                builder.Where("it.InternetType_ID in @InternetTypeIds");
            }

            if(filter.WorkerIds.Any())
            {
                builder.Where("w.Worker_ID in @WorkerIds");
            }

            var transInfo = conn.Query<TransactionInfoResult>(selector.RawSql, filter);
            return transInfo;
           
        }

        public void AddTransaction(TransactionCreateData createData)
        {
            string insert = @"Insert into transactions values(@Date, @Price, @Service_ID, @Client_ID, @Worker_ID)";

            using (conn)
            {
                var transInfo = conn.Execute(insert,
                new
                {
                    Date = createData.Date,
                    Service_ID = createData.ServiceId,
                    Client_ID = createData.ClientId,
                    Worker_ID = createData.WorkerId,
                    Price = (double)99.00
                });

            }
        }
    }
}