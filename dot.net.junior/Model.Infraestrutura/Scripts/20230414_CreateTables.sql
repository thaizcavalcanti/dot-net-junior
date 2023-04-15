CREATE TABLE Endereco(
    IdEndereco   UNIQUEIDENTIFIER NOT NULL,
    Rua          NVARCHAR(100)    NOT NULL,
    Numero       NVARCHAR(10)     NOT NULL,
    Cep          NVARCHAR(8)      NOT NULL,
    Bairro       NVARCHAR(100)    NOT NULL,
    Cidade       NVARCHAR(100)    NOT NULL,
    TipoEndereco INTEGER      NOT NULL,
    PRIMARY KEY(IdEndereco),
    CHECK (TipoEndereco IN (1, 2))
)
GO

CREATE TABLE TelefoneCelular(
    IdTelefoneCelular UNIQUEIDENTIFIER NOT NULL,
    DDD               VARCHAR(3)       NOT NULL,
    Numero            VARCHAR(11)       NOT NULL,
    TipoContato       INTEGER      NOT NULL,
    PRIMARY KEY(IdTelefoneCelular),
    CHECK (TipoContato IN (1, 2))
)
GO

CREATE TABLE Cliente(
    IdCliente     UNIQUEIDENTIFIER NOT NULL,
    NomeCliente   NVARCHAR(150)    NOT NULL,
    CPF           NVARCHAR(11)     NULL,
    CNPJ          NVARCHAR(14)     NULL,
    IdEndereco    UNIQUEIDENTIFIER NOT NULL,
    IdTelefoneCelular UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (IdCliente),
    FOREIGN KEY (IdEndereco) REFERENCES Endereco(IdEndereco),
    FOREIGN KEY (IdTelefoneCelular) REFERENCES TelefoneCelular(IdTelefoneCelular)
)
GO






