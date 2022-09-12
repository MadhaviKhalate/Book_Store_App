USE BookStoreDB

CREATE TABLE Orders(
	OrderId int identity(1,1) primary key,
	OrderQty int not null,
	TotalPrice float not null,
	OrderDate Date not null,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookId INT NOT NULL FOREIGN KEY REFERENCES BookTable(BookId),
	AddressId int not null FOREIGN KEY REFERENCES AddressTable(AddressID)
	)

SELECT * FROM Orders

CREATE PROCEDURE AddOrder
	@UserId int,
	@BookId int,
	@AddressId int,
	@TotalPrice int,
	@OrderQty int
AS
BEGIN
	SET @TotalPrice = (SELECT DiscountPrice FROM BookTable WHERE BookId = @BookId); 
	SET @OrderQty = (SELECT Book_Quantity FROM CartTable WHERE BookId = @BookId);
	BEGIN	
		BEGIN TRY
			BEGIN Transaction
				IF((SELECT BookQuantity FROM BookTable WHERE BookId = @BookId)>= @OrderQty)
				BEGIN
					INSERT INTO Orders VALUES(@OrderQty,@TotalPrice*@OrderQty,GETDATE(),@UserId,@BookId,@AddressId);
					UPDATE BookTable SET BookQuantity = (BookQuantity - @OrderQty) WHERE BookId = @BookId;
					DELETE FROM CartTable WHERE BookId = @BookId and UserId = @UserId; 
				END
			COMMIT TRANSACTION
		End try

		BEGIN Catch
				ROLLBACK;
		End Catch
	End
End

CREATE PROCEDURE RemoveOrder
	@OrderId int
AS
BEGIN
	DELETE FROM Orders WHERE OrderId=@OrderId
END
