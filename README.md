# aspnetcore-people-crud

Projeto criado para o processo seletivo da Stefanini contendo uma Web API construída com ASP .NET Core 3.1, com uso de padrões de projetos e uma arquitetura N-tier. 

Sobre a relação entre as entidades **Cidade** e **Pessoa**, tratei **Cidade** como uma entidade principal e **Pessoa** como uma entidade filha, de forma que para uma pessoa existir é necessário haver uma cidade cadastrada (nesse contexto, toda pessoa viveria em uma cidade, mas em outro contexto poderia funcionar de uma maneira diferente). Fazendo isso consegui explorar mais o design de rotas da entidade filha.


## Documentação da API:

https://localhost:44332/swagger/index.html

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET Core SDK 3.1
+ Visual Studio 2019 ou o Visual Studio Code
+ Privilégios de administrador no Sistema Operacional


## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Clone este repositório utilizando o GIT para um diretório na sua máquina: **git clone** https://github.com/luafalcaocode/aspnetcore-people-crud.git
2. Abra a solução no Visual Studio
3. Pressione F5 para rodar o projeto
4. Você deverá ver a página do Swagger com os endpoints disponíveis

## Configurando as migrations:

Para sincronizar o modelo de dados e mapear as classes OO para as tabelas em um banco de dados siga os passos abaixo:

1. Abra os arquivos appsettings.json e appsettings.Development.json e altere as configurações de string de conexão no objeto SqlServerConnection para refletir o seu próprio servidor de banco de dados
2. Abra o gerenciador de pacotes do Nuget e digite o comando Update-Database 
3. Ao final as tabelas deverão ser criadas no seu banco de dados 

Obs.: em caso de problemas para rodar o projeto verifique se seu anti-virus está bloqueando a execução do projeto

## Testando o Projeto

Você pode utilizar a interface do Swagger para testar alguns endpoints: https://localhost:44332/swagger/index.html

Ou utilizar os testes de integração que cobrem parcialmente algumas partes do projeto (o CRUD de Cidade).