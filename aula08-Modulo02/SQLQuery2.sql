-- INSERINDO DADOS NAS TABELAS 
/*INSERT INTO ACL (tipo, descricao) 
	VALUES ('Master', 'Acesso total, configurações de servidores e segurança.'); */ 
-- Limpando toda a tabela 
-- TRUNCATE TABLE ACL; 
/*DELETE FROM ACL; 
DBCC CHECKIDENT ('ACL', RESEESD, 0); */ 

/*INSERT INTO ACL (tipo, descricao) 
	VALUES ('Funcionario', 'Acesso administrativo interno e suporte.'); 
INSERT INTO ACL (tipo, descricao) 
	VALUES ('Cliente', 'Usuário final da plataforma zapTito.'); */ 
-- SELECT * FROM ACL; 

/*INSERT INTO STATUS (tipo, descricao) 
	VALUES ('Inativo', 'Sem accesso ao sistema ou algum item.'); 
INSERT INTO STATUS (tipo, descricao) 
	VALUES ('Ativo', 'Operando normalmente.'), 
			('Bloqueado', 'Accesso permanentemente revogado.'); */ 
-- SELECT * FROM STATUS; 

/*INSERT INTO PERFIL (tipo, descricao) 
	VALUES ('Comum', 'Perfil padrão para postagem e interação.'); 
INSERT INTO PERFIL (tipo, descricao) 
	VALUES ('Moderador', 'Perfil com ferramentas para reportar e revisar conteúdo.'), 
			('Administrador', 'Perfil com accesso administrativo podendo promover ou revogar usuários.'); */ 
-- SELECT * FROM PERFIL; 

INSERT INTO DISPOSITIVO (dispositivo) 
	VALUES ('Admin'); 
INSERT INTO DISPOSITIVO (dispositivo) 
	VALUES ('Moderador'), 
			('Geral'); 
SELECT * FROM DISPOSITIVO; 

-- SELECT * FROM USUARIO; 

-- SELECT * FROM VERIFICACAO; 


-- SELECT * FROM ACL; 
-- SELECT * FROM STATUS; 
-- SELECT * FROM PERFIL; 
-- SELECT * FROM DISPOSITIVO; 
-- SELECT * FROM USUARIO; 
-- SELECT * FROM VERIFICACAO; 
GO
