use master 
go
if exists ( select * from sys.databases where name ='Northwind')
drop database Northwind
go
create database Northwind
go
use Northwind
go

create table Categories(
  CategoryID int not null primary key,
  Discontinued int not null
)

create table Products(
  ProductID int not null primary key,
  ProductCode varchar(200) not null,
  ProductName nvarchar(300) not null,
  QuantityPerUnit nvarchar(200) not null,
  UnitPrice decimal not null,
  UnitPriceString varchar(200) ,
  UnitsInStock int,
  UnitsInStockString varchar(200),
  CategoryID int not null,
  constraint fk_Cate_Pro foreign key (CategoryID)
	references Categories(CategoryID)
)

insert into Categories values(1,0),
                             (2,1),
							 (3,1),
							 (4,1);
insert into Products values(1,'P01','Chair','30',30,'30$',12,'12$',1),
                           (2,'P02','Chair2','40',50,'50$',12,'12$',3);

			select * from Products;