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