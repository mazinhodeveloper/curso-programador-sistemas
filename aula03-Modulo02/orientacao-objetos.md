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
    
## Metodos de Classe (Chamada)    
| Classe Nome                | Classe Atributos              |   
|--------------------------- | ----------------------------- |   
| Chamada                    | ID                            |   
|                            | Data Hora Iniciada            |   
|                            | Duracao                       |   
|                            | Data Hora Finalizada          |   
|                            | Data Hora Exclusao            |   
|                            | Localiza Usuario              |   
|                            | Localiza Contato              |  
|                            | USUARIO:USUARIO               |  
|                            | CONTATO:CONTATO               |  
|                            | STATUS:STATUS                 |   
    
### Metodos de Classe (Chamada)    
|--------------------------- | ----------------------------- |  
| Chamada                    | Ligar                         |  
|                            | Consultar                     |    
|                            | Desligar                      |    
|                            | Excluir                       |    
    

