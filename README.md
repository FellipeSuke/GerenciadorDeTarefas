# Gerenciador de Tarefas - Teste Prático para o CREA

Este repositório contém o código-fonte de uma aplicação web simples de gerenciamento de tarefas, desenvolvida como parte de um teste prático para o CREA. A aplicação foi construída utilizando o padrão MVC no ASP.NET Core, com o objetivo de avaliar a capacidade do desenvolvedor em criar uma aplicação funcional, organizada e com boas práticas de codificação.

## Como Rodar o Projeto

### Requisitos

- **.NET 8.0** ou superior
- **SQL Server** (conexão de exemplo):
  ```plaintext
  Server=sukeserver.ddns.net,1433;
  Database=GerenciadorDeTarefas;
  User Id=sa;
  Password=avaliacaoJoao@123;
  TrustServerCertificate=True;
Passos para rodar o projeto

Clone este repositório:

cmd
```plaintext
  git clone https://github.com/FellipeSuke/GerenciadorDeTarefas
```
Navegue até o diretório do projeto:

cmd
```plaintext
cd gerenciador-de-tarefas
```
Restaure as dependências:

cmd
```plaintext
dotnet restore
```
cmd
```plaintext
dotnet ef database update
```
Execute o projeto:

cmd
```plaintext
dotnet run
```

Abra o navegador e acesse o endereço:

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
