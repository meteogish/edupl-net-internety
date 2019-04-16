use Internety
go
insert into Client values ('Heniu', 'Guziak', 'Kasztanowo 22', '99827188822');
insert into InternetType 
values ('FastInternet'),
('MediumInternet'),
('SlowInternet');

insert into Internet values (1), (2), (3);
insert into FastInternet values (1, 10, 20)
insert into MediumInternet values (2, 5, 10)
insert into SlowInternet values (3, 1, 3)
insert into Office values ('KasztanowaOffice', 'Lodz, Krzyczalskiego 22')

insert into Services 
values ('InternetDlaDziadka+',3, 25),
('InternetDlaMamy+',2, 50),
('InternetDlasyna+',1, 99);

insert into Workers values ('Bogdan', 'Byczek', 666,666555444, 'Kohanin 22', '99827133221', '11-11-2010', 1)
insert into Transactions values ('05-05-2019',99, 1, 1, 1)

use master

