# Orientação a Objetos 
ACL    
  - Contato   
    - Status (Ativo/Inativo)   
    - Perfil   

## Diagrama de Classe 
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Contato                    | ID                            |   
|                            | Nome                          |   
|                            | Número do Telefone            |  
|                            | Verificação (Se encontra)     |  
|                            | Status (Ativo/Inativo/Convite)|  
|                            | Descrição                     |   
|                            | Usuario:Usuario               | 
|--------------------------- | ----------------------------- |   
| Grupo                      | ID                            |   
|                            | Nome                          |   
|                            | Tipo (Ativo/inativo)          |  
|                            | Descrição                     |   
|                            | Status:Status                 |   
|                            | Contato:Contato               |   
|--------------------------- | ----------------------------- |   
| Chat                       | Contato:Contato               |   
|                            | ID                            |   
|                            | Nome                          |   
|                            | Tipo (Ativo/inativo)          |  
|                            | Descrição                     |   
|                            | Status:Status                 |   
|                            | Contato:Contato               |   
|--------------------------- | ----------------------------- |   
| Chamada                    | Contato:Contato               |   
|                            | ID                            |   
|                            | Descrição                     |   
|                            | Status:Status                 |  
|                            | Contato:Contato               |   

## Metodos de Classe 
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Usuario                    | Criar                         |   
|                            | Editar                        |  
|                            | Consultar                     |   
|                            | Editar (Excluir)              |   
  
|--------------------------- | ----------------------------- |  
| Contato                    | Criar                         |   
|                            | Editar                        |  
|                            | Consultar                     |   
|                            | Editar (Excluir)              |    
|--------------------------- | ----------------------------- |  
| Chat                       | Criar                         |   
|                            | Enviar Mensagem               |  
|                            | Receber Mensagem              |  
|                            | Ligar                         |  
|                            | Receber                       |  
|                            | Consultar                     |   
|                            | Editar (Excluir)              |  
|--------------------------- | ----------------------------- |  
| Messagem                   | Criar                         |   
|                            | Editar                        |  
|                            | Consultar                     |   
|                            | Editar (Excluir)              |  
   

### Sinais 
| Público                    | Privado                       | Protegido                  |   
|--------------------------- | ----------------------------- |--------------------------- |   
| +                          | -                             | #                          |   

### Sinais Classe Atributos 
| Público                    | Privado                       | Protegido                  |   
|--------------------------- | ----------------------------- |--------------------------- |   
| +                          | - ID                          | #                          |   
| +                          | - Nome                        | #                          |   
| +                          | - Data de Nascimento          | #                          |   
| +                          | -                             | # Número de Telefone       |   
| +                          | - Senha                       | #                          |   
| +                          | - Verificação de 2 etapas     | #                          |   
| +                          | - ACL:ACL                     | #                          |  
| +                          | - Usuario:Usuario             | #                          |   
| +                          | - Status:Status               | #                          |  
| +                          | - Perfil:Perfil               | #                          |  

### Sinais Metodos de Classe 
| Classe Nome                | Classe Atributos              | Sinais                     |   
|--------------------------- | ----------------------------- | -------------------------- |   
| Contato                    | + Criar                       | Público                    |   
|                            | - Enviar Mensagem             | Privado                    |    
|                            | - Ligar                       | Privado                    |   
|                            | - Editar                      | Privado                    |   
|                            | + Consultar                   | Público                    |    
|                            | - Editar (Excluir)            | Privado                    |    

### Classe ACL 
| ACL (Privado)              | Sinais                     |     
| -------------------------- | -------------------------- |    
| - ID                       | Privado                    |    
| - Tipo                     | Privado                    |    
| - Descrição                | Privado                    |    
| -------------------------- | -------------------------- |   
| - Consulta                 | Privado                    |    

### Classe Status 
| Status (Privado)           | Sinais                     |     
| -------------------------- | -------------------------- |    
| - ID                       | Privado                    |    
| - Tipo                     | Privado                    |    
| - Descrição                | Privado                    |    
| -------------------------- | -------------------------- |   
| - Consulta                 | Privado                    |    

### Classe Perfil 
| Perfil (Privado)           | Sinais                     |     
| -------------------------- | -------------------------- |    
| - ID                       | Privado                    |    
| - Tipo                     | Privado                    |    
| - Descrição                | Privado                    |    
| -------------------------- | -------------------------- |   
| - Consulta                 | Privado                    |    


