create database bdcadastro

use bdcadastro

create table pessoa (
id int not null identity(1,1),
nome varchar(50),
telefone varchar(50),
endereco varchar(50),
constraint PK_pessoa primary key(id)
);
