create procedure up_InsertVillage
@CustomerID nchar(14),@CustomerName nvarchar(20),
@Surname nvarchar(20),@Phone char(14),
@VillageID int
as insert into Customer values(@CustomerID,@CustomerName,@Surname,@Phone,@VillageID)

create procedure up_UpdateVillage
@CustomerID nchar(14),@CustomerName nvarchar(20),
@Surname nvarchar(20),@Phone char(14),
@VillageID int
as Update Customer Set CustomerName=@CustomerName,Surname=@Surname,Phone=@Phon
e,VillageID=@VillageID where CustomerID=@CustomerID

create procedure up_DeleteVillage
@CustomerID nchar(14)
as Delete from Customer where CustomerID=@CustomerID

Create Proc up_SelectCategory
as select * from Category 

Create Proc up_SelectUnit
as select * from Unit

Create Proc up_SelectProduct
as select P.ProductID,P.productName,P.price,p.Qty,U.UnitName,
C.CategoryName from Product P inner join Unit U ON P.UnitID=U.UnitID
inner join Category C ON P.CategoryID=C.CategoryID

Create Proc up_InsertProduct
@ProductID char(14),@ProductName nvarchar(30),
@Price int,@Qty int,@UnitID int,@CategoryID int, 
@Condition int
as insert into Product values(@ProductID,@ProductName,@Price,@Qty,@UnitID,@CategoryID,@Condition)

drop proc up_InsertProduct