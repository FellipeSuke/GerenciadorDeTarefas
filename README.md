# Gerenciador de Tarefas - Teste Prático para o CREA

Este repositório contém o código-fonte de uma aplicação web simples de gerenciamento de tarefas, desenvolvida como parte de um teste prático para o CREA. A aplicação foi construída utilizando o padrão MVC no ASP.NET Core, com o objetivo de avaliar a capacidade do desenvolvedor em criar uma aplicação funcional, organizada e com boas práticas de codificação.

## **Link de teste**
https://sukeserver.ddns.net:7245/

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

# **Windows**

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

Execute o projeto:

cmd
```plaintext
dotnet run
```

Abra o navegador:

O servidor estará rodando localmente. Acesse o endereço:

```plaintext
http://localhost:5269
```

Se preferir, você também pode acessar a versão HTTPS do projeto:

```plaintext

https://localhost:7245
```
(Dependendo da sua configuração de perfil de execução.)

Configuração de Perfis de Execução
Este projeto contém diferentes perfis de execução configurados no arquivo launchSettings.json. Eles determinam como o projeto será executado em diferentes ambientes:

http: Disponibiliza a aplicação na URL http://localhost:5269.
https: Disponibiliza a aplicação tanto em HTTP quanto em HTTPS, nas URLs http://localhost:5269 e https://localhost:7245, respectivamente.
IIS Express: Executa o projeto usando o IIS Express, com a URL definida na configuração do perfil.

# **Docker**

Instale o Docker
Caso não tenha o Docker instalado, siga as instruções de acordo com o seu sistema operacional:

Docker para Windows
Docker para MacOS
Docker para Linux
Instale o Docker Compose
O Docker Compose geralmente já vem incluído com o Docker Desktop no Windows e Mac.
No Linux, você pode instalar seguindo este guia oficial.

Clone o repositório da aplicação

bash
```plaintext
git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/FellipeSuke/GerenciadorDeTarefas.git)
cd seu-repositorio
```
Certifique-se de que o arquivo docker-compose.yml está configurado corretamente

Execute o comando para subir os containers

bash
```plaintext
docker-compose up -d
```
Verifique se os containers estão rodando
Use o comando abaixo para verificar o status dos containers:

bash

```plaintext
docker ps
```
Acesse a aplicação
Abra o navegador e acesse o endereço configurado no docker-compose.yml. Geralmente é:

http://localhost:porta

Parar os containers
Caso precise parar a aplicação, use:

bash
```plaintext
docker-compose down
```



# Estrutura do Projeto
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


