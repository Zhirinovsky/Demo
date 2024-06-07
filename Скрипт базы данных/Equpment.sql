create database Equpment_Repair_Database;

use Equpment_Repair_Database;

create table Request_Type (
	ID int not null identity(1,1) primary key,
	Name varchar(30) not null unique
)
go

insert into Request_Type (Name)
values ('В ожидании'), ('В работе'), ('Выполнено')
go

create table Completion_Stage (
	ID int not null identity(1,1) primary key,
	Name varchar(30) not null unique
)
go

insert into Completion_Stage (Name)
values ('Выполнено'), ('В работе'), ('Не выполнено')
go

create table [Role] (
	ID int not null identity(1,1) primary key,
	Name varchar(30) not null unique
)
go

insert into [Role] (Name)
values ('Сотрудник'), ('Клиент')
go

create table [User] (
	ID int not null identity(1,1) primary key,
	Login varchar(50) not null unique,
	Password varchar(50) not null,
	Role_ID int not null foreign key references [Role] (ID)
	--constraint [CH_Password_Upper] check (Password like ('%[A-Z]%')),
	--constraint [CH_Password_Letter_Lower] check (Password like ('%[a-z]%')),
	--constraint [CH_Password_Symbols] check (Password like ('%[!@#$%^&amp;*()]%'))
)
go

insert into [User] (Login, Password, Role_ID)
values ('LoginE', 'PasswordE', 1),
('LoginK', 'PasswordK', 2)
go

create table Request (
	ID int not null identity(1,1) primary key,
	Number int not null unique,
	Addiction_Date date null default(getdate()),
	Equpment varchar(30) not null,
	Malfunction_Type varchar(50) not null,
	Problem_Description varchar(300) not null,
	Client_ID int not null foreign key references [User] (ID),
	Employee_ID int null foreign key references [User] (ID),
	Request_Type_ID int null foreign key references Request_Type (ID),
	Completion_Stage_ID int null foreign key references Completion_Stage (ID)
)
go