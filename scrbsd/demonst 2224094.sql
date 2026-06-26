CREATE DATABASE demosnet_nraluno;
go

USE demosnet_nraluno;

CREATE TABLE Produtos
(
ProdutoID int NOT NUll identity,
Codigo varchar (45) DEFAULT NULL,
Descricao varchar(45) DEFAULT NULL,
PRIMARY KEY (ProdutoID)
);
INSERT INTO Produtos (Codigo,Descricao) VALUES ('321','321 Xpto');
INSERT INTO Produtos (Codigo,Descricao) VALUES ('123','Xpto 123');
