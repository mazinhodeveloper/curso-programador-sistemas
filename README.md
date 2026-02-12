# Programador de Sistemas 
Período: 02/02/2026 a 27/04/2026    
Horário: Segunda, Terça, Quarta, Quinta e Sexta - 13:30 às 17:30    
https://www.sp.senac.br/senac-lapa-tito/cursos-livres/curso-de-programador-de-sistemas    

## Programador de Sistemas - 200 horas  
- Desenvolver sistemas de informação    
- Implementar banco de dados    
- Realizar testes e manutenção do sistema de informação    
- Planejar o desenvolvimento do software seguindo análise de requisitos    
- Especificar as fases do desenvolvimento de acordo com o planejamento realizado    
- Criar algoritmos utilizando padrões de lógica de programação    
- Selecionar a metodologia e a linguagem de programação para o desenvolvimento do software    
- Definir a arquitetura de banco de dados    
- Desenvolver estruturas e modelar o banco de dados    
- Avaliar a persistência dos dados gerados pelo software, verificando sua funcionalidade    
- Utilizar diferentes metodologias para testes, de acordo com funcionalidade do sistema    
- Tabular o resultado e realizar ajustes e ações corretivas    

### Objetivo 
Aprender a desenvolver, especificar, testar e implantar sistema de informação e soluções de programação, contemplando requisitos de segurança, especificações e implementação de banco de dados.    

### Programa 
Aulas práticas e dinâmicas que conectam você às inovações da área, sempre com espaço para tirar dúvidas e trocar experiências.    
Também poderá participar de exercícios, projetos e atividades colaborativas no Laboratório de Informática do Senac, utilizando equipamentos e softwares específicos, com estímulo ao raciocínio lógico e simulação de situações do dia a dia profissional.    


### Público 
Este curso é para pessoas que se identificam com a área de tecnologia da informação, desenvolvimento, testes e manutenção do sistema de informação e banco de dados.    

#### Docente  
Nerildo Viana da Silva   

## GitHub / Curso Banco de Dados para Web 
https://github.com/mazinhodeveloper/curso-programador-sistemas   

### Projeto   
| Requisitos do Projeto      | URL                           |   
|--------------------------- | ----------------------------- |   
| C#                         | https://dotnet.microsoft.com/pt-br/languages/csharp |   
| .NET SDK                   | https://learn.microsoft.com/en-us/dotnet/core/install/windows |   
| Docker                     | https://www.docker.com        |   
| Docker Dotnet/sdk:10.0     | docker compose exec dotnet dotnet new console -n MyApp |   
| Docker MySQL               | docker run -d --name some-mysql -v /my/own/datadir:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=my-secret-pw mysql:tag |   


### Rodando o Projeto com Docker 
docker compose up --build -d 

### Criando um novo projeto C# 
docker compose exec dotnet dotnet new console -n MyApp 

### Rodando o projeto 
docker compose exec dotnet dotnet run --project MyApp 

### Autorizações de diretório - Linux,Terminal
sudo chmod -R 777 /home/user/workspace/docker/dotnet 
