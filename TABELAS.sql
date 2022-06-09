CREATE TABLE Cliente(
IdCliente int not null primary key identity,
Nome varchar(200) not null,
UF char(2) not null,
Celular varchar(14) not null
)

CREATE Table Financiamento(
IdFinanciamento int not null primary key identity,
IdCliente int not null,
TipoFinanciamento char(1),
ValorTotal money,
DataVencimento Datetime,
CONSTRAINT FK_IdCliente foreign key(IdCliente) references dbo.Cliente(IdCliente)
)

CREATE TABLE Parcela(
IdParcela int not null identity primary key,
IdFinanciamento int not null,
NumeroParcela int not null,
ValorParcela money not null,
DataVencimento datetime not null,
DataPagamento datetime null,
CONSTRAINT FK_IdFinanciamento foreign key(IdFinanciamento) references dbo.Financiamento(IdFinanciamento)
)


