# Rhitmo Estacionamento

## O que a solução faz?
A solução é capaz de realizar a solicitação de um pedido de extração na ReceitaWS dos dados de cadastro de uma empresa.

## Arquitetura do Projeto
A solução foi feita em uma API em .NET 6, estruturada de forma simples, separando as responsabilidades por camada.

## Execução do código
Para executar o teste do código, será necessário clonar o repositório em sua máquina, executar, atráves do Entity Framework, a criação da tabela com os dados necessários, tanto da empresa, como do usuário (ambos já estão prontos para rodar o Entity). Támbém é necessário a troca da string de conexão, localizada no arquivo "appsettings.json". Após isso, só executar o projeto.

A aplicação inicia-se em uma tela de login, onde, para o primeiro acesso será necessário criar um usuário, não sendo possível criar dois uários com o mesmo email, o mesmo acusa um erro, informando que o usuário já possui cadastro.
Ao realizar o login, a view apresentada será uma Home, onde terá a opção de: realizar uma nova consulta, realizar o download do arquivo extraido da consulta e realizar o logout.

Não é possível acessar outras telas, antes de realizar o login.
