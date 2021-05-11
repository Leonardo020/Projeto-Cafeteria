
create database dbCafeteria;
use dbCafeteria;

create table Funcionario(
cod_func int primary key auto_increment,
nome_func varchar(50),
cpf_func varchar(11),
email_func varchar(50),
senha_func varchar(20),
nivel_login int
);


create table Cliente(
cod_cli int primary key auto_increment,
nome_cli varchar(50),
cpf_cli varchar(11),
email_cli varchar(50)
);

create table Gerente(
cod_gerente int primary key auto_increment,
nome_gerente varchar(50),
cpf_gerente varchar(11),
email_gerente varchar(50),
senha_gerente varchar(20),
nivel_login int
);

create table Login(
cod_login int primary key auto_increment,
email_login varchar(50),
nome_login varchar(50),
senha_login varchar(20),
nivel_login int,
cod_gerente int references Gerente,
cod_func int references Funcionario
);

create table Produto(
cod_prod int primary key auto_increment,
nome_prod varchar(50),
img_prod varchar(255),
qtd_prod int,
valor_unitario float,
cod_fornecedor int references Fornecedor
);

create table Fornecedor(
cod_fornecedor int primary key auto_increment,
nome_fornecedor varchar(50),
cnpj_fornecedor varchar(14)
);

create table Venda(
cod_venda int primary key auto_increment,
valor_total float,
qtd_venda int,
data_venda date,
cod_pagamento int references Pagamento
);

create table Pedido(
cod_pedido int primary key auto_increment,
qtd_item int,
cod_prod int references Produto,
cod_venda int references Venda
);

create table Pagamento(
cod_pagamento int primary key auto_increment,
tipo_pagamento varchar(20)
);

create table ArquivoMorto(
cod_arq int primary key auto_increment,
nome_prod varchar(50),
qtd_prod int,
valor_unitario float,
cod_prod int references Produto,
cod_fornecedor int references Fornecedor
);

/* Criando a proc de funcionario */

DELIMITER $$
create procedure inserirFuncionario(
nome varchar (50),
cpf varchar(11),
email varchar (50),
nivel int(2),
senha varchar (20)
)
BEGIN
insert into Funcionario (nome_func, cpf_func, email_func, nivel_login, senha_func)
values (nome, cpf, email, nivel, senha);

insert into Login (nome_login, email_login, senha_login, nivel_login)
values (nome, email, senha, nivel);
END $$
DELIMITER $$

call inserirFuncionario('Railson', 65898565831, 'railson@gmail.com', 2, 'rai123');

select * from Funcionario;

/* Criando a proc de gerente */
DELIMITER $$
create procedure inserirGerente(
nome varchar (50),
cpf varchar(11),
email varchar (50),
nivel int(2),
senha varchar (20)
)
BEGIN
insert into Gerente (nome_gerente, cpf_gerente, email_gerente, nivel_login, senha_gerente)
values (nome, cpf, email, nivel, senha);

insert into Login (email_login, nome_login, senha_login, nivel_login)
values (email, nome, senha, nivel);
END $$
DELIMITER $$

call inserirGerente('Leonardo', 98745612310, 'leonardo@gmail.com', 1, 'leo123');

select * from login; 

/* Criando a proc de cliente */

delimiter $$
create procedure inserirCliente(in nome varchar(50), in cpf varchar(11), in email varchar(50))
begin
	insert into Cliente(nome_cli, cpf_cli, email_cli) values (nome, cpf, email);
end $$
delimiter $$

call inserirCliente('Cleber', 44420566841, 'cleber@gmail.com');

/* Criando a proc de fornecedor */
delimiter $$
create procedure inserirFornecedor(in nome varchar(50), in cnpj varchar(14))
begin
	insert into Fornecedor(nome_fornecedor, cnpj_fornecedor) values (nome, cnpj);
end $$
delimiter $$

call inserirFornecedor('Café Santa Monica', '64968613000108');

/* Criando a proc de inserir produto */
delimiter $$
create procedure inserirProduto(in nome varchar(50), in qtd int, in valor float, cod int)
begin
	insert into Produto(nome_prod, qtd_prod, valor_unitario, cod_fornecedor) values (nome, qtd, valor, cod);
end $$
delimiter $$

call inserirProduto('Café Rico', 250, '15.90', 1);

/* Criando a proc de atualizar produto */
delimiter $$
create procedure alterarProduto(in codProd int, in nome varchar(50), in qtd int, in valor float, in codForn int)
begin
	update Produto set nome_prod = nome, qtd_prod = qtd, valor_unitario = valor, cod_fornecedor = codForn  where cod_prod = codProd;
end $$
delimiter $$

call alterarProduto (1, 'Café Nobre', '250', 15.90, 1);

/* Criando a proc de deletar produto */
 delimiter $$
 create procedure deletaProduto(in cod int)
 begin
    delete from Produto where cod_prod = cod;
 end $$
 delimiter $$;
 
  select * from Produto;
 
 /* Criando a trigger de arquivo morto */
 delimiter $$
 create trigger antes_deletar_produto
 
 before delete 
 on Produto for each row
 begin
	insert into ArquivoMorto(cod_prod, nome_prod, qtd_prod, valor_unitario, cod_fornecedor)
	values(old.cod_prod, old.nome_prod, old.qtd_prod, old.valor_unitario, old.cod_fornecedor);
 end $$
 delimiter ;
 
 select * from ArquivoMorto;

/* Criando a proc de carrinho */
delimiter $$
create procedure inserirPedido(in qtd int, in valor float, in cod_prod int, in cod_venda int)
begin
	insert into Pedido(qtd_item,valor_pedido, cod_prod, cod_venda) values (qtd, valor, cod_prod, cod_venda);
end $$
delimiter $$

call inserirCarrinho(1, 1);

select * from Pedido;

/* Criando a proc de carrinho */
delimiter $$
create procedure inserirPagamento(in tipo varchar(20))
begin
	insert into Pagamento(tipo_pagamento) values (tipo);
end $$
delimiter $$


call inserirPagamento('Débito');
call inserirPagamento('Crédito');
call inserirPagamento('Boleto');
call inserirPagamento('Dinheiro');


/* Criando a proc de venda*/
delimiter $$
create procedure inserirVenda(in valor float, in qtd int, in data date, in cod_cli int, in cod_pagamento int)
begin
	insert into Venda(valor_total, qtd_venda, data_venda, cod_cli, cod_pagamento) values (valor, qtd, data, cod_cli, cod_pagamento);
end $$
delimiter $$

drop procedure inserirVenda;

call inserirVenda(20.50, 1, 20210508);

select * from Venda;

select * from login;
select * from produto;
select * from funcionario;

select cod_prod, nome_prod, qtd_prod, valor_unitario, nome_fornecedor from Produto pd inner join Fornecedor fn on pd.cod_fornecedor = fn.cod_fornecedor;

