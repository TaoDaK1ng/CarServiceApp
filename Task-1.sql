CREATE DATABASE CarServiceDB;
ALTER DATABASE CarServiceDB COLLATE Cyrillic_General_CI_AS;
GO

USE CarServiceDB;

CREATE TABLE Cars 
(
	Id INT CONSTRAINT PK_Car_Id PRIMARY KEY IDENTITY(1,1),
	Brand NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	Government_Number NVARCHAR(20) NOT NULL CONSTRAINT UQ_Car_Government_Number UNIQUE,
	Mileage INT NOT NULL,
	Engine_Capacity INT NOT NULL, 	
)

CREATE TABLE Owners
(
	Id INT CONSTRAINT PK_Owner_Id PRIMARY KEY IDENTITY(1,1),
	First_Name NVARCHAR(20) NOT NULL,
	Second_Name NVARCHAR(20) NOT NULL,
	Middle_Name NVARCHAR(20) NOT NULL,
	Phone_Number NVARCHAR(20) NOT NULL,
	Address_Of_Residence NVARCHAR(100) NULL,
	Passport_Data NVARCHAR(50) NULL CONSTRAINT UQ_Owner_Passport_Data UNIQUE
)

CREATE TABLE Masters 
(
	Id INT CONSTRAINT PK_Master_Id PRIMARY KEY IDENTITY(1,1),
	First_Name NVARCHAR(20) NOT NULL,
	Second_Name NVARCHAR(20) NOT NULL,
	Middle_Name NVARCHAR(20) NOT NULL,
	Phone_Number NVARCHAR(20) NOT NULL,
	Work_Experience INT NOT NULL
)

CREATE TABLE RepairCars 
(
	Id INT CONSTRAINT PK_RepairCar_Id PRIMARY KEY IDENTITY(1,1),
	Master_Id INT NOT NULL,
	Car_Id INT NOT NULL,
	Malfunction NVARCHAR(100) NOT NULL,
	Production_Date DATE NOT NULL,
	Expiration_Date DATE NULL,
	Cost INT NOT NULL,
	CONSTRAINT FK_RepairCars_To_Masters FOREIGN KEY (Master_Id) REFERENCES Masters(Id) 
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	CONSTRAINT FK_RepairCars_To_Cars FOREIGN KEY (Car_Id) REFERENCES Cars(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE OwnerCars
(
	Owner_Id INT NOT NULL,
	Car_Id INT NOT NULL,
	CONSTRAINT FK_OwnerCars_To_Owners FOREIGN KEY (Owner_Id) REFERENCES Owners(Id) 
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	CONSTRAINT FK_OwnerCars_To_Cars FOREIGN KEY (Car_Id) REFERENCES Cars(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
GO

INSERT INTO Cars (Brand, Model, Government_Number, Mileage, Engine_Capacity) VALUES 
('Toyota','Corolla','С009СТ',1000,1596),
('Mazda','2', 'А228КТ',2000,2564),
('Nissan','Almera','В042КА',10000,1290),
('Subaru','Legacy','Е987РО',52000,989),
('Toyota','Camry','У342КМ',31000,2100),
('Chevrolet','Aveo','Я567ТС',5000,1409),
('Toyota','RAV4','Н765ЕК',8000,893),
('Mazda','3','И634ОР',11000,1023),
('Mercedes-Benz','GLC','А123ЕН',111000,1890),
('Nissan','Juke','П904ДВ',81000,1323)

INSERT INTO Owners(First_Name, Second_Name, Middle_Name, Phone_Number, Address_Of_Residence, Passport_Data) VALUES 
('Артём','Чагалысов','Игоревич','+79652380175','Ленина 43 кв.25','3914935349'),
('Иван','Мазепов','Валерьевич','+79245670375','Орджоникидзе 23 кв.3','6788730945'),
('Александр','Иванов','Сергеевич','+79143215481','Космонавтов 2 кв.76','9834321734'),
('Владимир','Федоров','Владимирович','+79651871023','Молодёжная 15 кв.34','6452451249'),
('Фёдор','Григорьев','Иванович','+79246540243','Советская 17 кв.46','4321355049'),
('Алексей','Сергеев','Игоревич','+79248740015','Лесная 39 кв.54','5334915309'),
('Яков','Алексеев','Ринатович','+79658247654','Мира 5 кв.56','3117458729'),
('Петр','Петров','Павлович','+79146457732','Набережная 12 кв.1','9470985212'),
('Павел','Ефременков','Максимович','+79146664375','Школьная 22 кв.65','1789032276'),
('Максим','Пермяков','Кимович','+79658769930','Центральная 43 кв.88','7673457632')

INSERT INTO Masters(First_Name, Second_Name, Middle_Name, Phone_Number, Work_Experience) VALUES 
('Григорий','Соколов','Петрович','+79654530213',5),
('Иван','Новиков','Валерьевич','+79247770490',2),
('Сергей','Михайлов','Григорьевич','+79249343254',8),
('Василий','Лебедев','Евгеньевич','+79247459090',1),
('Евгений','Семенов','Васильевич','+79652281950',3),
('Александр','Павлов','Михаилович','+79658542146',7),
('Михаил','Козлов','Александрович','+79147268814',10),
('Петр','Степанов','Артемович','+79144347887',4),
('Максим','Волков','Павлович','+79145136510',9),
('Павел','Васильев','Петрович','+79651583190',6)

INSERT INTO RepairCars(Master_Id, Car_Id, Malfunction, Production_Date, Expiration_Date, Cost) VALUES 
(1, 1, 'Электропитание','2020-05-12',null,2000),
(2, 2, 'Контрольные лампы','2020-05-02',null,1500),
(3, 3, 'Тормозная система','2020-03-28','2020-03-31',3000),
(4, 4, 'Рулевое управление','2020-04-21','2020-04-24',2100),
(5, 5, 'Ходовая часть','2020-03-05','2020-03-08',1200),
(6, 6, 'Система охлаждения','2020-04-18','2020-04-21',1800),
(7, 7, 'Топливная система','2020-02-07','2020-02-10',5000),
(8, 8, 'Рабочие жидкости','2020-02-12','2020-02-15',7000),
(1, 9, 'Коробка передач','2020-05-23',null,4300),
(10, 10, 'Электропроводка','2020-03-12','2020-03-15',3700)

INSERT INTO OwnerCars(Owner_Id, Car_Id) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10)
