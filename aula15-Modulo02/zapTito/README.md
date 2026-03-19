# As PASTAS  
## 1. Models  
-- Classes puras (POCO) que representa as tabelas do banco de dados ou o diagrama de classes   
    
## 2. Repositories  
-- Onde fica o SQL puro (sqlCommand, sqlDataReader). É que toca no banco   
    
## 3. Services  
-- Onde fica a 'Regra de negócio' (valida usuário é maior de idade antes de salvar)   
    
## 4. Controllers  
-- No contexto de um App, eles vão orquestrar as chamadas entre View e o Service.   
    
## 5. Views   
-- Suas telas em XAML   
   
## Pacotes NuGet     
-- Tabs: Ferramentas/Gerenciador de Pacotes do NuGet/Console do Gerenciador de Pacotes    
### instalar o Azure     
Install-Package Azure.Identity    
   
### Atualizar o Azure   
Update-Package Azure.Identity    
    
### Install o SqlClient    
Install-Package Microsoft.Data.SqlClient    
    
### Instalar o Swagger    
Install-Package Swashbuckle.AspNetCore    

### Instalar Application Insights     
Install-Package Microsoft.ApplicationInsights    
Install-Package Microsoft.ApplicationInsights.AspNetCore    

### Instalar BCrypt    
Install-Package BCrypt.Net-Next  

## Pacotes NuGet     
-- Abrir o terminal      
### Adicionar pacotes usando Visual Studio Code (Terminal)     
dotnet add package Azure.Identity     
dotnet add package Microsoft.Data.SqlClient     
dotnet add package Swashbuckle.AspNetCore     
dotnet add package Microsoft.ApplicationInsights    
dotnet add package Microsoft.ApplicationInsights.AspNetCore     
dotnet add package BCrypt.Net-Next     
    
### Listar pacotes desatualizados usando Visual Studio Code (Terminal)       
dotnet list package --outdated    

##### URL Example (Terminal)     
https://localhost:XXXX/swagger     
   
##### Json (Cadastro)    
https://localhost:7191/swagger/index.html     
{     
  "nome": "Edmar",    
  "dataNascimento": "1988-06-27",    
  "numeroTelefone": "5511948006909",    
  "senha": "MangaComLeite"    
},       
{     
  "nome": "Roberto",    
  "dataNascimento": "1988-06-25",    
  "numeroTelefone": "5511999800910",    
  "senha": "MangaELeite"    
}     
     