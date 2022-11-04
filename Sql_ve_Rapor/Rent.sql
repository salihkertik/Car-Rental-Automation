Create database AracKiralama

create table Arac
(
AracId int IDENTITY (1,1) PRIMARY KEY not null,
ModelID int null foreign key references Model (ModelID),
ruhsatNo int null,
renk nchar (15) null,
vites int null,
km int null,
NumberID int null foreign key references AracSay�s� (SayiID),
)
alter table Arac 
			add unique (ruhsatNo)
insert into Arac values 
	(
		1,1,100,'MAV�',7,25120,4,
		2,2,101,'KIRMIZI',5,17512,3,
		3,3,102,'YE��L',5,451254,9,
		5,4,103,'BEYAZ',6,2000,7,
		6,5,104,'BEYAZ',5,5214,4,
		7,6,105,'KIRMIZI',6,324534,3,
		8,7,106,'BORDO',5,3234,2,
		9,8,107,'MOR',5,245344,4

	)



create table AracSay�s�
(
SayiID int IDENTITY (1,1) PRIMARY KEY not null,
AracSayi smallint null,
)
insert into AracSay�s� values 
	(
		1,4,
		2,3,
		3,9,
		4,7,
		5,4,
		6,3,
		7,2,
		8,4
	)


create table Fatura
(
FaturaId int IDENTITY (1,1) PRIMARY KEY not null,
RentID int null foreign key references Kira (KiraId),
)
insert into Fatura values
	(
		1,1,
		2,2,
		3,3,
		4,4,
		5,5,
		6,6
	)


create table Kira
(
KiraId int PRIMARY KEY not null,
Kira�cret money null,
CarID int null foreign key references Arac (AracId),
PersonID int null foreign key references M��teri (Ki�iId),
)
insert into Kira values
	(
		1,2500,1,1,
		2,2850,2,3,
		3,1950,3,5,
		4,5420,5,2,
		5,7500,6,4,
		6,2550,7,6
	)


create table Marka
(
MarkaId int IDENTITY (1,1) PRIMARY KEY not null,
MarkaAd varchar(20) null
)
insert into Marka values
	(
		1,'BMW',
		2,'Mercedes',
		3,'AUD�',
		4,'WOLKSWAGEN',
		5,'PEUGEOT',
		6,'F�AT',
		7,'RANGE ROWER',
		8,'PORSCHE'
	)


create table Model
(
ModelId int IDENTITY (1,1) PRIMARY KEY not null,
ModelAd varchar(20) null,
BrandID int null foreign key references Marka (MarkaId),
)
insert into Model values
	(
		1,'F30',
		2,'CLA180',
		3,'A6',
		4,'GOLF',
		5,'PARTNER',
		6,'EGEA',
		7,'WOGG',
		8,'TURB�TO'
	)


create table M��teri
(
Ki�iId int IDENTITY (1,1) PRIMARY KEY not null,
AdSoyad varchar(50) null,
Adres varchar(150) null,
Telefon int null,
Ehliyet varchar(2) null,
)
insert into M��teri values 
	(
		1,'Salih Kertik','Emirgazi Mah','530494871','B',
		2,'Orhan �lmez','Kumk�pr� Mah','545845214','B',
		3,'M�sl�m G�RSES','Ulukap� Mah','531652415','B',
		4,'Kibariye','Etiler Mah','539695845','B'
	)


Create table �deme
(
�demeId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
�denecekTutar money null,
�deme�ekli varchar(10) null,
InvoiceID int null foreign key references Fatura (FaturaId),
)
insert into Arac values
	(
	   1,2550,'KART',1,
	   2,2850,'NAK�T',2,
	   3,1950,'NAK�T',3,
	   4,5450,'KART',4,
	   5,7500,'KART',5
	)


	UPDATE AracSay�s�
	SET AracSayi=5
	Where SayiId=1

	SELECT AracId, ruhsatNo, renk FROM Arac

	ALTER TABLE Arac DROP COLUMN renk

	DELETE FROM Arac
	WHERE AracId=12

	SELECT * FROM �deme
	WHERE �denecekTutar BETWEEN 2000 AND 6000






