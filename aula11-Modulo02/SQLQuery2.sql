-- # 1. Usar o banco de dados 
USE dbZapTito; 
GO 
  
/* 
-- # 2. Inserir dado na tabela ztACL 
INSERT INTO ztACL (tipo, descricao) 
	VALUES 
	('Master', 'Acesso total ao sistema, especifica para o administrador do sistema.'); 
GO 
*/ 
/* 
-- # 3. Inserir multiplos dados na tabela ztACL 
MERGE INTO ztACL AS Target 
	USING (
		VALUES 
		('Administrador', 'Acesso administrativo, para suporte tecnico.'), 
		('Funcionário', 'Acesso ao sistema para gestão.'), 
		('Cliente', 'Acesso ao sistema para uso.') 
	) AS Source (tipo, descricao) 
	ON Target.tipo = Source.tipo -- Verifica se o tipo já existe 
	-- Se o 'tipo' não existir, insere apenas tipo e descricao (id é automático) 
	WHEN NOT MATCHED BY TARGET THEN 
		INSERT (tipo, descricao) 
		VALUES 
		(Source.tipo, Source.descricao) 
	WHEN MATCHED THEN 
		UPDATE SET Target.descricao = Source.descricao; 
GO 
*/ 
/* 
-- # 4. Inserir multiplos dados na tabela ztSTATUS 
MERGE INTO ztSTATUS AS Target 
	USING (
		VALUES 
		('Inativo', 'Sem accesso ao sistema ou algum item.'), 
		('Ativo', 'Operando normalmente.') 
	) AS Source (tipo, descricao) 
	ON Target.tipo = Source.tipo -- Verifica se o tipo já existe 
	-- Se o 'tipo' não existir, insere apenas tipo e descricao (id é automático) 
	WHEN NOT MATCHED BY TARGET THEN 
		INSERT (tipo, descricao) 
		VALUES 
		(Source.tipo, Source.descricao) 
	WHEN MATCHED THEN 
		UPDATE SET Target.descricao = Source.descricao; 
GO 
*/ 
/* 
-- # 5. Inserir multiplos dados na tabela ztPERFIL 
MERGE INTO ztPERFIL AS Target 
	USING (
		VALUES 
		('Comum', 'Perfil padrão para postagem e interação.'), 
		('Moderador', 'Perfil com ferramentas para reportar e revisar conteúdo.'), 
		('Administrador', 'Perfil com accesso administrativo podendo promover ou revogar usuários.') 
	) AS Source (tipo, descricao) 
	ON Target.tipo = Source.tipo -- Verifica se o tipo já existe 
	-- Se o 'tipo' não existir, insere apenas tipo e descricao (id é automático) 
	WHEN NOT MATCHED BY TARGET THEN 
		INSERT (tipo, descricao) 
		VALUES 
		(Source.tipo, Source.descricao) 
	WHEN MATCHED THEN 
		UPDATE SET Target.descricao = Source.descricao; 
GO 
*/ 
/* 
-- # 6. Inserir multiplos dados na tabela ztDISPOSITIVO 
MERGE INTO ztDISPOSITIVO AS Target 
	USING (
		VALUES 
		('Admin'), 
		('Moderador'), 
		('Geral') 
	) AS Source (dispositivo) 
	ON Target.dispositivo = Source.dispositivo -- Verifica se o dispositivo já existe 
	-- Se o 'dispositivo' não existir, insere apenas dispositivo (id é automático) 
	WHEN NOT MATCHED BY TARGET THEN 
		INSERT (dispositivo) 
		VALUES 
		(Source.dispositivo) 
	WHEN MATCHED THEN 
		UPDATE SET Target.dispositivo = Source.dispositivo; 
GO 
*/ 

-- # 7. Selecionando cada tabela individualmente 
SELECT * FROM ztACL; 
GO 
SELECT * FROM ztSTATUS; 
GO 
SELECT * FROM ztPERFIL; 
GO 
SELECT * FROM ztDISPOSITIVO; 
GO 


