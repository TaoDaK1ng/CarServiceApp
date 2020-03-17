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
('Toyota','Corolla','�009��',1000,1596),
('Mazda','2', '�228��',2000,2564),
('Nissan','Almera','�042��',10000,1290),
('Subaru','Legacy','�987��',52000,989),
('Toyota','Camry','�342��',31000,2100),
('Chevrolet','Aveo','�567��',5000,1409),
('Toyota','RAV4','�765��',8000,893),
('Mazda','3','�634��',11000,1023),
('Mercedes-Benz','GLC','�123��',111000,1890),
('Nissan','Juke','�904��',81000,1323)

INSERT INTO Owners(First_Name, Second_Name, Middle_Name, Phone_Number, Address_Of_Residence, Passport_Data) VALUES 
('����','���������','��������','+79652380175','������ 43 ��.25','3914935349'),
('����','�������','����������','+79245670375','������������ 23 ��.3','6788730945'),
('���������','������','���������','+79143215481','����������� 2 ��.76','9834321734'),
('��������','�������','������������','+79651871023','��������� 15 ��.34','6452451249'),
('Ը���','���������','��������','+79246540243','��������� 17 ��.46','4321355049'),
('�������','�������','��������','+79248740015','������ 39 ��.54','5334915309'),
('����','��������','���������','+79658247654','���� 5 ��.56','3117458729'),
('����','������','��������','+79146457732','���������� 12 ��.1','9470985212'),
('�����','����������','����������','+79146664375','�������� 22 ��.65','1789032276'),
('������','��������','�������','+79658769930','����������� 43 ��.88','7673457632')

INSERT INTO Masters(First_Name, Second_Name, Middle_Name, Phone_Number, Work_Experience) VALUES 
('��������','�������','��������','+79654530213',5),
('����','�������','����������','+79247770490',2),
('������','��������','�����������','+79249343254',8),
('�������','�������','����������','+79247459090',1),
('�������','�������','����������','+79652281950',3),
('���������','������','����������','+79658542146',7),
('������','������','�������������','+79147268814',10),
('����','��������','���������','+79144347887',4),
('������','������','��������','+79145136510',9),
('�����','��������','��������','+79651583190',6)

INSERT INTO RepairCars(Master_Id, Car_Id, Malfunction, Production_Date, Expiration_Date, Cost) VALUES 
(1, 1, '��������������','2020-05-12',null,2000),
(2, 2, '����������� �����','2020-05-02',null,1500),
(3, 3, '��������� �������','2020-03-28','2020-03-31',3000),
(4, 4, '������� ����������','2020-04-21','2020-04-24',2100),
(5, 5, '������� �����','2020-03-05','2020-03-08',1200),
(6, 6, '������� ����������','2020-04-18','2020-04-21',1800),
(7, 7, '��������� �������','2020-02-07','2020-02-10',5000),
(8, 8, '������� ��������','2020-02-12','2020-02-15',7000),
(1, 9, '������� �������','2020-05-23',null,4300),
(10, 10, '���������������','2020-03-12','2020-03-15',3700)

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
