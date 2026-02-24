# UML    
Contato    

## Diagrama de Classe (Contato)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Contato                    | ID                            |   
|                            | Nome                          |   
|                            | Número do Telefone            |   
|                            | USUARIO:USUARIO               |   
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Contato)   
|--------------------------- | ----------------------------- |  
| Contato                    | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir                       |   
|                            | Bloquear                      |   
|                            | Desbloquear                   |   
    
# UML    
Grupo    

## Diagrama de Classe (Grupo)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Grupo                      | ID                            |   
|                            | Tipo                          |   
|                            | Descricao                     |   
|                            | USUARIO:USUARIO               |   
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Grupo)    
|--------------------------- | ----------------------------- |  
| Grupo                      | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir                       |   
|                            | Bloquear                      |   
|                            | Desbloquear                   |   
    
## Diagrama de Classe (ListaContato)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| ListaContato               | ID                            |   
|                            | GRUPO:GRUPO                   |   
|                            | CONTATO:CONTATO               |   
|                            | PERFIL:PERFIL                 |   
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (ListaContato)    
|--------------------------- | ----------------------------- |  
| ListaContato               | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir (Contato)             |   
|                            | Bloquear (Contato)            |   
|                            | desbloquear (Contato)         |   
    
# UML    
Chat    
   
## Metodos de Classe (Chat)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Chat                       | ID                            |   
|                            | Data Hora criacao             |   
|                            | Data Hora Fim                 |   
|                            | GRUPO:GRUPO                   |  
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Chat)    
|--------------------------- | ----------------------------- |  
| Chat                       | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir                       |   
|                            | Bloquear                      |   
|                            | Desbloquear                   |   
|                            | Arquivar                      |   
|                            | Desarquivar                   |   
    
## Metodos de Classe (Chat - Recebe)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Chat - Recebe              | ID                            |   
|                            | Mensagem                      |  
|                            | Data Hora Enviado             |   
|                            | Data Hora Entregue            |   
|                            | Data Hora Lido                |   
|                            | CONTATO:CONTATO               |  
|                            | CHAT:CHAT                     |   
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Chat - Recebe)    
|--------------------------- | ----------------------------- |  
| Chat - Recebe              | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir                       |   

## Metodos de Classe (Chat - Envia)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Chat - Envia               | ID                            |   
|                            | Mensagem                      |  
|                            | Data Hora Enviado             |   
|                            | Data Hora Entregue            |   
|                            | Data Hora Lido                |   
|                            | USUARIO:USUARIO               |  
|                            | CHAT:CHAT                     |   
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Chat - Envia)    
|--------------------------- | ----------------------------- |  
| Chat - Envia               | Criar                         |  
|                            | Consultar                     |    
|                            | Editar                        |    
|                            | Excluir                       |    












#### Aula Anterior     


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


