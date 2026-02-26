> Aula 05 / Módulo 02    
> Docente: Nerildo Viana da Silva     
> Data: 26/02/2026    

# Atividade de Aula   
Nome    
  -> Label ou Rotulo    
    
Joao Silva -> Dado     
  -> Campo       
     
Entidade      
  -> Objeto (UML)        
    
## Modelo Conceitual    
USUARIO <--- Tem que ter <--- ACL    
USUARIO <--- Tem que ter <--- PERFIL    
USUARIO <--- Tem que ter <--- STATUS    
     
Entidade  (Tabela)      
  -> Objeto (UML)    

## Modelo Logico   
| USUARIO                    |    
|--------------------------- |    
| id: INT(10)                | PK |     
| nome: VARCHAR(60)          |         
| dataNascimento: DATE()     |      
| numeroTelefone: CHA(14)    |          
| senha: VARCHAR(150)        |    
| verificacao: CHAR(6)       |         
| idACL: INT(10)             | FK |         
| idSTATUS: INT(10)          | FK |   
| idPERFIL: INT(10)          | FK |   
