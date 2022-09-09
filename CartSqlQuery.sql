use BookStoreDB

Create Table CartTable
(
CartId int identity(1,1) primary key,
Book_Quantity int default 1,
UserId int not null foreign key (UserId) references Users(ID),
BookId int not null Foreign key (BookId) references BookTable(BookId)
);

select * from CartTable

--------------- For adding the cart ---------
Create procedure AddToCart
( 
  @BookQuantity int,
  @UserId int,
  @BookId int
)
As
Begin
	insert into CartTable(Book_Quantity,UserId,BookId)
	values ( @BookQuantity,@UserId, @BookId);
End;

--------- Update BookQuantity in Cart --------

create procedure UpdateCart
(
	@BookQuantity int,@BookId int,@UserId int,@CartId int
)
as
begin
update CartTable set BookId=@BookId,UserId=@UserId,Book_Quantity=@BookQuantity where CartId=@CartId;
end

-------------- For Remove Books From Cart ----------

create procedure RemoveCart
(
@CartId int
)
as
begin

	delete from CartTable where CartId = @CartId;
end;


