# Polícia Móvel (Backend)

Este repositório contém a implementação do serviço web da aplicação *Polícia Móvel*. Com o intuíto de ser um aplicativo de auxílio às forças policiais, nasceu como um TCC da Universidade Tecnológica Federal do Paraná e agora é um projeto público que pode ser expandido e adaptado por qualquer indivíduo.

## Funcionalidades

Atualmente, o projeto conta com as seguintes funcionalidades:

- Cadastro de usuários;
- Autenticação de usuários;
- Atualização da localização do usuário;
- Listagem de localizações dos usuários.

## Como Rodar

É necessário possuir o [.NET 6](https://dotnet.microsoft.com/en-us/) instalado e acesso à uma instância do [MongoDB](https://www.mongodb.com/).

- Defina as configurações do arquivo **appsettings.json** no projeto **UTFPR.PoliciaMovel.API**;
- Execute o comando no projeto **UTFPR.PoliciaMovel.API**:

```bash
dotnet run
```