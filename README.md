# Descrição do projeto

Foram utilizadas as tecnologias:
- Asp.net core
- .net core 3.1
- SQL Server
- Entity framework
- XUnit
- Docker
- Swagger

Padrões utilizados
- DDD
- Repository
- SOLID

Explicação dos módulos/pastas
- 01 - API: Resposável pelas APIs do projeto
- 02 - UI: Contém a interface do usuário para anexar e enviar o arquivo CNAB
- 03 - Domain: Todas as regras de negócio
- 04 - Infra: Implementações concretas do repositório do domínio(Nesse caso, utilizando o EF), classes auxiliares para envio HTTP
- 05 - Testes unitários, utilizando o Xunit
- 06 - Gerenciador abstrato do container de injeção de dependência (nesse caso está sendo implementado o autoFac)
- 07 - Contém partes de códigos usados por toda a aplicação
- docker-compose: temos 3 containers(API, WEB(UI) e SQLServer)


## Installation
- Tem como pré-requisito a instalação do docker no SO (Linux, Windows ou MAC)

Para rodar o projeto, basta entrar no diretório que está o arquivo docker-compose.yml (\desafio-dev\Desafio) e executar o comando:

 docker-compose up: cria e inicia os contêineres;
 docker-compose ps: lista os contêineres (opcional);

 - Após a inicialização dos containers, acessar a aplicação web no endereço:
 http://localhost:20000/
 
 - Para acessar a documentação da API entrar no endereço:
 http://localhost:20001/swagger/index.html
