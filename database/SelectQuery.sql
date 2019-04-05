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
where t.Date between @begindate and @enddate
where o.Office_ID = @officeId
where it.InternetType_ID in @inernetTypeId
where w.Worker_ID in @workerId