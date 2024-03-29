create database ResturantDB

use ResturantDB

create table Peoples(
personID int identity(1,1) primary key,
fristName nvarchar(20) not null,
secondName nvarchar(20) not null,
thirdName nvarchar(20) not null,
lastName nvarchar(20) not null,
brithday Datetime not null,
image nvarchar(max)  null,
phone nvarchar(15) not null,
)

create table Employees(
employeeID int identity(1,1) primary key,
personID int not null references Peoples(personID),
userName nvarchar(100) not null ,
password nvarchar(15) not null,
createdDate Datetime default getDate(),
isActive bit not null default 0,
)


create table Categories(
categoryID int identity(1,1) primary key,
name nvarchar(50) not null ,
addDate datetime default getdate(),
addBy int references Employees(employeeID)
)

create table Menus(
menuID int identity(1,1) primary key,
name nvarchar(max) not null,
categoryID int references Categories(categoryID),
image nvarchar(max),
addDate Datetime default getdate(),
addBy  int references Employees(employeeID))


create table Orders(
orderID int identity(1,1) primary key,
state smallint default 1,
totalPrice float not null,
inRestorant bit default 1,
addBy int references Employees(employeeID),
addDate datetime default getdate()
)



create view order_view as 
select 
  orderID,
  case 
     when state =1 then 'طلبية ناحجة'
     when state = 2 then 'الطلب معلقة'
  else 'تم الغاء الطلب'
  end as state,
  totalPrice,
  inRestorant,
  addBy ,
   CAST(DAY(addDate) AS nvarchar) + '-' + 
   CAST(MONTH(addDate) AS nvarchar) + '-' + 
   CAST(YEAR(addDate) AS nvarchar) + ' ' + 
   CAST(FORMAT(addDate, 'hh:mm tt') AS nvarchar) 
   AS addDate
from  Orders



select p.personID,(p.fristName+' '+p.secondName+' '+p.thirdName+' '+ p.lastName ) as fullName,
 CAST(DAY(p.brithday) AS nvarchar) + '-' + 
  CAST(MONTH(p.brithday) AS nvarchar) + '-' + 
 CAST(YEAR(p.brithday) AS nvarchar) + ' ' + 
 CAST(FORMAT(p.brithday, 'hh:mm tt') AS nvarchar) AS brithday,
p.image ,p.phone
 from Peoples p 
                                     
