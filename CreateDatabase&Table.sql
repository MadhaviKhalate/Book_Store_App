CREATE DATABASE BookStoreDB;
use BookStoreDB

create table Users (
    ID int IDENTITY(1,1) PRIMARY KEY (ID),
    FullName varchar(50),
    EmailId varchar(50),
    Password varchar(100),
    MobileNumber varchar(12));

    
    SELECT * FROM Users;