create  database BookStore
create table Books(
Bookid int primary key identity(1,1),
Title varchar(50),
Author varchar(80),
Genere varchar(80),
Pub_year int,
Price int
)

create proc Sp_SaveBook
@Bookid int,
@Title varchar(50),
@Author varchar(80),
@Genere varchar(80),
@Pub_year int,
@Price int
as begin
insert into Books([Title], [Author], [Genere], [Pub_year], [Price])
values(@Title,@Author,@Genere,@Pub_year,@Price)
end

create proc Sp_GetBooks
as begin
select * from Books
end

create proc Sp_Delete
@Bookid int
as begin
delete from Books where @Bookid=Bookid
end
