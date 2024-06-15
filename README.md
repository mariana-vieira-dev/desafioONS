# desafioONS
Utilizado nesse desafio:
- .NET Core 8
- Entity Framework
- Clean Architeture
- MediatR
- CQRS

Camada de API
- Criados os controller para Usuário e para Contato
- Implementados endpoints para as operações CRUD (Create, Read, Update, Delete)
- Implementados endpoints para registro e login de usuários
- Protegidos os endpoints CRUD com autenticação JWT

Camada Business
- Implementdos serviços de negócio para lidar com a lógica de criação, atualização,
listagem e deleção de usuários e contatos
- Implementada a lógica de criptografia de senha, se aplicável
- Criar DTOs e Models necessários para a transferência de dados entre as camadas. Nessa arquitetura são desenvolvidos nessa camada para que ocorra o desacoplamento.
- Implementar validações para garantir que os dados enviados para a API sejam válidos com FluentValidator

Camada Common
-Para organização das injeções de dependência

Camada Entities:
- Criadas as classes de entidade (Usuário e Contato)

Camada Repository:
- Implementados repositórios para realizar as operações no banco de dados
- Implementado controle de transação com UnitOfWork, garantindo que as transações sejam confirmadas (commit) ou revertidas (rollback) corretamente em caso de sucesso ou falh


