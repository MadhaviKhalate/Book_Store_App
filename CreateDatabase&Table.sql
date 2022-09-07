CREATE DATABASE BookStoreDB;
use BookStoreDB

create table Users (
    ID int IDENTITY(1,1) PRIMARY KEY (ID),
    FullName varchar(50),
    EmailId varchar(50),
    Password varchar(100),
    MobileNumber varchar(12));

    
USE [BookStoreDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_User] @FullName VARCHAR(100), @EmailId VARCHAR(100), @Password VARCHAR(100), @MobileNumber BIGINT 
AS
BEGIN
INSERT INTO Users(FullName,EmailId,Password,MobileNumber) VALUES (@FullName, @EmailId, @Password, @MobileNumber)
END

   SELECT * FROM Users;


Go
CREATE PROCEDURE [dbo].[Login_User] @EmailId VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT EmailId,Password FROM Users WHERE EmailId= @EmailId AND Password=@Password
END

CREATE PROCEDURE ForgetPassword
(
@EmailId varchar(180)
)
As
Begin
	Select * from Users where EmailId=@EmailId
End;