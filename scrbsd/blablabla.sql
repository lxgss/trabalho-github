create database blabla
use blabla
create table xpto(
numeroID int not null identity,
nome varchar(10),
idade int,
primary key (numeroID)
)

insert into xpto (nome,idade) values('Gonçalo', 10)
select * from xpto

