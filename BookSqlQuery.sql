use BookStoreDB

----Create table for book -----
Create Table BookTable
(
BookId int identity(1,1) not null primary key,
BookName varchar(270) not null,
AuthorName varchar(200) not null,
Rating  varchar(10) not null,
RatingCount int ,
DiscountPrice varchar(10) not null,
ActualPrice varchar(10) not null,
Description varchar(max) not null,
BookImage varchar(250),
BookQuantity int not null
);

select * from BookTable


--------Adding book--------
Create proc AddBook
(
@BookName varchar(270),
@AuthorName varchar(200),
@Rating varchar(10),
@RatingCount int,
@DiscountPrice varchar(10),
@ActualPrice varchar(10),
@Description varchar(max),
@BookImage varchar(250),
@BookQuantity int
)
as
begin
	insert into BookTable(BookName,AuthorName,Rating,RatingCount,DiscountPrice,ActualPrice,Description,BookImage,BookQuantity)
	values(@BookName,@AuthorName,@Rating,@RatingCount,@DiscountPrice,@ActualPrice,@Description,@BookImage,@BookQuantity);
end;
