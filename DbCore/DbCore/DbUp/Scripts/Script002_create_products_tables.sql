if not exists (select * from information_schema.tables where table_schema = 'dbo' and table_name = 'Products')
begin
create table dbo.Products
(
    ProductId int identity(1,1) primary key,
    Name nvarchar(100) not null,
    Price decimal(18, 2) not null
);
end;
