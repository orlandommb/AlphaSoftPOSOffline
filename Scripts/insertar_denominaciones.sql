--insertando denominaciones de tipo billete
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 50)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 100)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 200)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 500)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 1000)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 2000)


--insertando denominaciones de tipo Moneda
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 1)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 5)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 10)
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 25)
