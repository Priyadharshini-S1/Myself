use database1

create table companies(id int identity(1,1) not null primary key,
name varchar(20),
address varchar(20),
country varchar(20))

create table employees(
id int identity(1,1) not null primary key,
name varchar(20),
age int,
position varchar(20),
companyid int not null foreign key references companies(id) on delete cascade)

insert into companies(name,address,country)
values
('iinterchange','Anna nagar','India'),
('vs&b','Anna nagar','India')

select * from companies

insert into employees(name,age,position,companyid)
values
('Amy',23,'Developer',1),
('Steve',24,'BA',2)

select * from employees

create procedure usp_select
@id int
as
select c.name,c.address,e.name,e.position
from companies c
join employees e
on c.id=e.companyid
where e.id=@id

exec dbo.usp_select @id=1

use cloth

select * from ClothDetails

ALTER TABLE ClothDetails
ADD Gender varchar(10);

--update
create procedure update_companies
@id int,
@name varchar(20),
@address varchar(20),
@country varchar(20)
as
begin
update companies 
set 
name=@name,
address=@address,
country=@country
where id=@id
end

create procedure usp_insert
@name varchar(20),
@address varchar(20),
@country varchar(20)
as
begin
insert into companies(name,address,country)
values(@name,@address,@country)
end

use cloth

create table clothings(productid int identity(1,1) not null primary key,
name varchar(20),
description varchar(20),
price int,
size varchar(20),
color varchar(20),
gender varchar(10))
select * from clothings
select * from customers
create table Customers(
customerid int identity(1,1) not null primary key,
customername varchar(20),
customerage int,
productid int not null foreign key references clothings(productid) on delete cascade)


alter procedure usp_insert
@name varchar(20),
@description varchar(20),
@price int,
@size varchar(5),
@color varchar(20),
@gender varchar(10),
@instock bit,
@count int,
@addeddate date
as
begin
insert into clothings(name,description,price,size,color,gender,instock,count,addeddate)
values(@name,@description,@price,@size,@color,@gender,@instock,@count,@addeddate)
end

alter procedure usp_update
@id int,
@name varchar(20),
@description varchar(20),
@price int,
@size varchar(5),
@color varchar(20),
@gender varchar(10),
@instock varchar(5),
@count int,
@addeddate date
as 
begin 
update Clothings
set name=@name,
description=@description,
price=@price,
size=@size,
color=@color,
gender=@gender,
instock=@instock,
count=@count,
addeddate=@addeddate
where productid=@id
end



alter table clothings alter column instock bit
alter table clothings add count int
alter table clothings alter column addeddate datetime

select * from clothings
select * from customers

insert into customers(customername,customerage,productid)values('priya',20,21)

alter procedure UpdateClothingCount
@ProductId INT
as
begin
declare @CustomerCount int;
select @CustomerCount = COUNT(*) from customers where productid = @ProductId;
update clothings SET count = count - @CustomerCount WHERE productid = @ProductId;
end

alter procedure UpdateClothingCount
@ProductId INT
as
begin
declare @Count int;
select @Count = count from customers where productid = @ProductId;
update clothings SET count = count - @Count WHERE productid = @ProductId;
end

alter procedure usp_insertc
@customername varchar(20),
@customerage int,
@productid int,
@count int
as
begin
insert into Customers(customername,customerage,productid,count)
values(@customername,
@customerage,
@productid,
@count)
end

create procedure usp_insertcart
@productid int ,@count int
as 
begin
create table #cart (productid int,productName varchar(20),price int,count int,totalprice int)
insert into #cart (productid,name,price,count,totalprice)
 values(@productid,productName,@price,@count,@totalprice)
end

create table admin (id int primary key identity(1,1),username varchar(20),password varchar(30))

alter table customers add count int


alter PROCEDURE usp_insertcart
    @productid INT,
    @count INT
AS
BEGIN
    DECLARE @productName varchar(20)
    DECLARE @productPrice int

    -- Get product name and price from Clothing table based on productid
    SELECT @productName = name, @productPrice = price
    FROM Clothings
    WHERE productid = @productid
	  -- Create a temporary table
    CREATE TABLE Cart (
       ProductId int , ProductName varchar(20), Count int , TotalPrice int)
    -- Insert record into Cart table
    INSERT INTO Cart (ProductId, ProductName, Count, TotalPrice)
    VALUES (@productid, @productName, @count, @count * @productPrice)

    -- Update count in Clothing table
    UPDATE Clothings
    SET count = count - @count
    WHERE productid = @productid
END
select * from cart
select * from clothings
exec usp_insertcart 

alter PROCEDURE usp_insertcart
    @productid INT,
    @count INT
AS
BEGIN

    -- Get product name and price from Clothing table based on productid
	  -- Create a temporary table
    CREATE TABLE Cart (
       ProductId int , ProductName varchar(20), Count int , TotalPrice int)
    -- Insert record into Cart table
    INSERT INTO Cart (ProductId,ProductName,Count,TotalPrice)
	select productid,name,count,price from clothings where productid=@productid
    
	update cart set TotalPrice=@count*TotalPrice,Count=@count where Productid=@productid
    -- Update count in Clothing table
    UPDATE Clothings
    SET count = count - @count
    WHERE productid = @productid
	select * from cart
END
exec usp_insertcart @productid=18,@count=2
drop table cart

select * from clothings
 