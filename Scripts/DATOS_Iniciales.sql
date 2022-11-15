
IF not exists (select * From AspNetRoles Where NormalizedName = 'CAJERO/A' and Name = 'Cajero/a' )
BEGIN
INSERT INTO AspNetRoles  (Id, NormalizedName, Name) values ( NEWID(),'CAJERO/A','Cajero/a')
END 

IF not exists (select * From AspNetRoles Where NormalizedName = 'SUPERADMIN' and Name = 'SuperAdmin' )
BEGIN
INSERT INTO AspNetRoles  (Id, NormalizedName, Name) values ( NEWID(), 'SUPERADMIN','SuperAdmin')
END

IF not exists (select * From AspNetRoles Where NormalizedName = 'ADMIN' and Name = 'Admin' )
BEGIN
INSERT INTO AspNetRoles  (Id, NormalizedName, Name) values ( NEWID(), 'ADMIN','Admin')
END

IF not exists (select * From TipoOrdenes Where Nombre = 'Delivery')
BEGIN
insert into TipoOrdenes (Nombre) values ('Delivery')
END

IF not exists (select * From TipoOrdenes Where Nombre = 'Para llevar')
BEGIN
insert into TipoOrdenes (Nombre) values ('Para llevar')
END

IF not exists (select * From TipoOrdenes Where Nombre = 'Consumo Local')
BEGIN
insert into TipoOrdenes (Nombre) values ('Consumo Local')
END

IF not exists (select * From TipoDenominaciones Where Nombre = 'Billete')
BEGIN
insert into TipoDenominaciones values ('Billete')
END

IF not exists (select * From TipoDenominaciones Where Nombre = 'Moneda')
BEGIN
insert into TipoDenominaciones values('Moneda')
END

IF not exists (select * From Denominaciones Where Valor = 50)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 50)
END

IF not exists (select * From Denominaciones Where Valor = 100)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 100)
END

IF not exists (select * From Denominaciones Where Valor = 200)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 200)
END

IF not exists (select * From Denominaciones Where Valor = 500)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 500)
END

IF not exists (select * From Denominaciones Where Valor = 1000)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 1000)
END

IF not exists (select * From Denominaciones Where Valor = 2000)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Billete'), 2000)
END

IF not exists (select * From Denominaciones Where Valor = 1)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 1)
END

IF not exists (select * From Denominaciones Where Valor = 5)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 5)
END

IF not exists (select * From Denominaciones Where Valor = 10)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 10)
END

IF not exists (select * From Denominaciones Where Valor = 25)
BEGIN
insert into Denominaciones values ((select Id from TipoDenominaciones where Nombre = 'Moneda'), 25)
END