# desafioONS
Utilizado nesse desafio:
- .NET Core 8
- Entity Framework
- Clean Architeture
- MediatR
- CQRS
- FluentValidator
- JWT
- Logging
- BD SQLServer

Camada de API
- Criados os controller para Usuário e para Contato;
- Implementados endpoints para as operações CRUD (Create, Read, Update, Delete);
- Implementados endpoints para registro e login de usuários;
- Protegidos os endpoints CRUD com autenticação JWT.

Camada Business
- Implementados serviços de negócio para lidar com a lógica de criação, atualização, listagem e deleção de usuários e contatos;
- Implementada a lógica de criptografia de senha;
- Criados os DTOs e Models necessários para a transferência de dados entre as camadas. Nessa arquitetura são desenvolvidos nessa camada para que ocorra o desacoplamento;
- Implementadas as validações para garantir que os dados enviados para a API sejam válidos, com FluentValidator;
- Implementada a autenticação com JWT.

Camada Common
- Para organização das injeções de dependência.

Camada Entities
- Criadas as classes de entidade (Usuário e Contato).

Camada Repository
- Configurado o mapeamento das entidades com Entity Framework;
- Implementados os repositórios para realizar as operações no banco de dados;
- Implementado controle de transação com UnitOfWork, garantindo que as transações sejam confirmadas (commit) ou revertidas (rollback) corretamente em caso de sucesso ou falha.

-----------------------------------------------------------------------------------------------------------
Script BD

CREATE DATABASE DesafioONS;
GO

USE DesafioONS;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Login NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL, 
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Contacts (
    Id INT PRIMARY KEY IDENTITY,
    PhoneNumber NVARCHAR(15) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

