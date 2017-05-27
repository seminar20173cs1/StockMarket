Create Database StockMarket
use StockMarket
Create table Province
(
	ProvinceID int not null,
	ProvinceName nvarchar(30)
	Constraint pk_ProvinceID primary key(ProvinceID)
)
Create table District
(
	DistrictID int not null,
	DistrictName nvarchar(30),
	ProvinceID int,
	Constraint pk_DistrictID Primary key(DistrictID),
	Constraint fk_ProvinceID foreign key(ProvinceID) references Province
	
)
Create table Village
(
	VillageID int not null identity,
	VillageName nvarchar(20),
	DistrictID int,
	Constraint pk_VillageID primary key(VillageID),
	Constraint fk_DistrictID foreign key(DistrictID) references District
)
Create table Customer
(
	CustomerID nchar(14) not null,
	CustomerName nvarchar(20),
	Surname nvarchar(20),
	Phone char(14),
	VillageID int
	Constraint pK_CustomerID primary key(CustomerID),
	Constraint fk_VillageID foreign key(VillageID) references Village
)
Create table Category
(	
	CategoryID int not null,
	CategoryName nvarchar(20)
	Constraint pk_CategoryID primary key(CategoryID)
)
Create table Unit
(	
	UnitID int not null,
	UnitName nvarchar(20)
	Constraint pk_UnitID primary key(UnitID)
)
Create table Product
(
	ProductID char(14) not null,
	ProductName nvarchar(30),
	Price int,
	Qty int,
	UnitID int,
	CategoryID int, 
	Condition int,
	constraint pk_ProductID primary key(ProductID),
	constraint fk_CategoryID foreign key(CategoryID) references Category,
	constraint fk_UnitID foreign key(UnitID) references Unit,
)
Create table tbUser
(
	UserName nvarchar(30) not null,
	UserPassword char(20),
	UserAuther Nvarchar(30),
	UserPhotoPath varchar(100)
	Constraint pk_UserName primary key(UserName),
	
)
Create table OrderProduct
(
	OrderBillNo char(5) not null,
	OrderDate date,
	OrderTime time,
	UserName nvarchar(30),
	Constraint pk_OrderBillNo primary key(OrderBillNo),
	Constraint fk_UserName foreign key(UserName) references tbUser 
)
Create table OrderDetail
(
	OrderID int not null identity,
	ProductID char(14),
	Qty int,
	OrderBillNo char(5)
	Constraint pk_OrderID primary key(OrderID),
	Constraint fk_OrderBillNo foreign key(OrderBillNo) references OrderProduct,
	constraint fk_ProductID foreign key(ProductID ) references Product
)
drop table orderDetail