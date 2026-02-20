# Orientação a Objetos 
ACL    
  - Usuário   
    - Status   
    - Perfil   

## Diagrama de Classe 
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Usuario                    | ID                            |   
|                            | Nome                          |   
|                            | Data de Nascimento            |   
|                            | Número do Telefone            |  
|                            | Senha                         |  
|                            | Verificação de 2 etapas       |   
|                            | *Email                        |  
|                            | *CPF                          |  
|                            | *RG                           |  
|                            | *CEP                          |  
|                            | *Endereço                     |  
|                            | *Profissão                    |  
|                            | *Cartão de Credito            | 
|                            | *Sexualidade                  |  
|                            | *Estado Civil                 |   
* Não Obrigatório    

## Metodos de Classe 
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Usuario                    | Criar                         |   
|                            | Editar                        |  
|                            | Consultar                     |   
|                            | Editar (Excluir)              |  
|--------------------------- | ----------------------------- |  
| Chat                       | Criar                         |   
|                            | Editar                        |  
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
| +                          | - Status:Status               | #                          |  
| +                          | - Perfil:Perfil               | #                          |  

### Sinais Metodos de Classe 
| Classe Nome                | Classe Atributos              | Sinais                     |   
|--------------------------- | ----------------------------- | -------------------------- |   
| Usuario                    | + Criar                       | Público                    |   
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


