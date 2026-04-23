USE TransporteEscolar2; 

INSERT INTO ACL 
    (tipo, descricao) 
VALUES 
    ('Master', 'Acesso total ao sistema, especifica para o administrador do sistema.'); 
INSERT INTO ACL 
    (tipo, descricao) 
VALUES 
    ('Administrador', 'Acesso administrativo, para suporte tecnico.');
INSERT INTO ACL 
    (tipo, descricao) 
VALUES 
    ('Cliente', 'Acesso ao sistema para uso.');
INSERT INTO ACL 
    (tipo, descricao) 
VALUES 
    ('Funcion�rio', 'Acesso ao sistema para gest�o.');
SELECT * FROM ACL; 


INSERT INTO STATUS 
    (tipo, descricao) 
VALUES 
    ('Ativo', 'Operando normalmente.'); 
INSERT INTO STATUS 
    (tipo, descricao) 
VALUES 
    ('Inativo', 'Sem acesso ao sistema ou algum item.'); 
INSERT INTO STATUS 
    (tipo, descricao) 
VALUES  
    ('Bloqueado', 'Acesso permanentemente revogado.');  
INSERT INTO STATUS 
    (tipo, descricao) 
VALUES  
    ('Pendente', 'Aguardando ação do usuário.');  
SELECT * FROM STATUS; 


INSERT INTO PERFIL 
    (tipo, descricao) 
VALUES 
    ('Moderador', 'Perfil com ferramentas para reportar e revisar conteúdo.'); 
INSERT INTO PERFIL 
    (tipo, descricao) 
VALUES 
    ('Comum', 'Perfil padrão para postagem e interação.'); 
INSERT INTO PERFIL 
    (tipo, descricao) 
VALUES 
    ('Administrador', 'Perfil com accesso administrativo podendo promover ou revogar usuários.');  
INSERT INTO PERFIL 
    (tipo, descricao) 
VALUES 
    ('Desenvolvedor', 'Perfil com acesso desenvolvedor, podendo promover ou revogar usuários quando necessário.');  
SELECT * FROM PERFIL; 

