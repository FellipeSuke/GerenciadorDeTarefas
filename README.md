# Gerenciador de Tarefas - Teste Prático para o CREA

Este repositório contém o código-fonte de uma aplicação web simples de gerenciamento de tarefas, desenvolvida como parte de um teste prático para o CREA. A aplicação foi construída utilizando o padrão MVC no ASP.NET Core, com o objetivo de avaliar a capacidade do desenvolvedor em criar uma aplicação funcional, organizada e com boas práticas de codificação.

## Objetivo do Teste

Avaliar a capacidade do desenvolvedor em criar uma aplicação web funcional utilizando o padrão MVC no ASP.NET Core, com foco em boas práticas de codificação, organização do código e implementação de funcionalidades básicas.

## Descrição do Problema

Você foi contratado para desenvolver uma aplicação simples de gerenciamento de tarefas. A aplicação deve permitir que os usuários realizem as seguintes ações:

1. Listar tarefas cadastradas.
2. Adicionar uma nova tarefa.
3. Editar uma tarefa existente.
4. Excluir uma tarefa.
5. Alterar o status da tarefa (Pendente/Concluída).

## Funcionalidades Implementadas

- **Listagem de Tarefas**: O usuário pode visualizar todas as tarefas cadastradas.
- **Cadastro de Tarefas**: O usuário pode adicionar novas tarefas, fornecendo título, descrição e data de vencimento.
- **Edição de Tarefas**: O usuário pode editar uma tarefa existente, alterando as informações conforme necessário.
- **Exclusão de Tarefas**: O usuário pode excluir uma tarefa da lista.
- **Alteração de Status**: O usuário pode alterar o status de uma tarefa entre "Pendente" e "Concluída".

## Requisitos Funcionais

- Um usuário deve ser capaz de visualizar a lista de tarefas.
- Um usuário deve ser capaz de adicionar novas tarefas com os campos: título, descrição e data de vencimento.
- Um usuário deve ser capaz de editar as informações de uma tarefa existente.
- Um usuário deve ser capaz de excluir uma tarefa.
- Um usuário deve ser capaz de alterar o status da tarefa entre "Pendente" e "Concluída".

## Requisitos Não Funcionais

- O projeto foi desenvolvido utilizando **ASP.NET Core MVC**.
- A persistência de dados é feita com **Entity Framework Core**.
- Foi utilizado um banco de dados **SQL Server** (ou InMemoryDatabase para simplificação de execução).
- As interfaces (Views) são responsivas e amigáveis.

## Funcionalidades Adicionais

- **Modais e AJAX**: Utilização de modais e chamadas AJAX para melhorar a experiência do usuário.
  - Formulários de criação e edição de tarefas são carregados dinamicamente via AJAX.
  - A alteração de status das tarefas é feita diretamente na lista, sem a necessidade de recarregar a página.

## Como Rodar o Projeto

### Requisitos

- **.NET 6.0** ou superior
- **SQL Server** ou **InMemoryDatabase**

### Passos para rodar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/SEU-USUARIO/gerenciador-de-tarefas.git
Navegue até o diretório do projeto:

bash
Copiar código
cd gerenciador-de-tarefas
Restaure as dependências:

bash
Copiar código
dotnet restore
Execute a migração do banco de dados (caso esteja usando o SQL Server):

bash
Copiar código
dotnet ef database update
Execute o projeto:

bash
Copiar código
dotnet run
Abra o navegador e acesse o endereço:

arduino
Copiar código
http://localhost:5000
Estrutura do Projeto
Controllers: Contém os controladores que gerenciam a lógica de negócios e interagem com as Views e Models.
Models: Representação das entidades do sistema, incluindo a classe Tarefa.
Views: Contém as páginas HTML que são renderizadas ao usuário.
wwwroot: Contém arquivos estáticos como CSS, JavaScript e imagens.
Tecnologias Utilizadas
ASP.NET Core MVC: Framework principal para construção da aplicação web.
Entity Framework Core: ORM utilizado para a persistência de dados.
SQL Server (ou InMemoryDatabase): Banco de dados utilizado para armazenamento das tarefas.
AJAX: Tecnologia utilizada para melhorar a experiência do usuário sem recarregar a página.
Bootstrap: Framework CSS para tornar as interfaces responsivas e visualmente agradáveis.
