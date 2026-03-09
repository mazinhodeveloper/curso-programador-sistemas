-- Comentario 
-- 1. Criar o banco de dados com o nome 
-- do projeto dbTeste 
--CREATE DATABASE dbTeste; 
--GO 

-- 1. Usar o banco de dados 
USE dbTeste; 
GO 

-- 2. Criar as tabelas de dependencias 
CREATE TABLE USUARIO (
	idUsuario INT IDENTITY(1,1) PRIMARY KEY, 
	idAcl INT NOT NULL, 
	idStatus INT NOT NULL, 
	idPerfil INT NOT NULL, 
	nome VARCHAR(60) NOT NULL, 
	dataNascimento DATE NOT NULL, 
	numeroTelefone CHAR(14) UNIQUE NOT NULL, 
	senha VARCHAR(150) NOT NULL, -- Lembre-se: senha usndo no futuro HASH 
	-- Criando o relacionamento entre as tabelas 
	-- Relacionamento da ACL 
	CONSTRAINT FK_Usuario_Acl FOREIGN KEY (idAcl) 
	REFERENCES ACL(idAcl), 
	CONSTRAINT FK_Usuario_Status FOREIGN KEY (idStatus) 
	REFERENCES STATUS(idStatus), 
	CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (idPerfil) 
	REFERENCES PERFIL(idPerfil) 
); 
CREATE TABLE ztCONTATO ( 
	idContato INT IDENTITY(1,1) PRIMARY KEY, 
	idUsuario INT NOT NULL, 
	idStatus INT NOT NULL, 
	nome VARCHAR(60) NOT NULL, 
	numeroTelefone CHAR(14) UNIQUE NOT NULL, 
	email VARCHAR(200) NOT NULL, 
	-- Relacionamento com Cascata (Cascateamento) 
	CONSTRAINT FK_Contato_Usuario FOREIGN KEY (idUsuario) 
		REFERENCES ztUSUARIO(idUsuario) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Contato_Status FOREIGN KEY (idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
); 
CREATE TABLE ztLISTACONTATO ( 
	idListaContato INT IDENTITY(1,1) PRIMARY KEY, 
	idGrupo INT NOT NULL, 
	idContato INT NOT NULL, 
	idPerfil INT NOT NULL, 
	idStatus INT NOT NULL, 
	-- Relacionamento com Cascata (Cascateamento) 
	CONSTRAINT FK_ListaContato_Grupo FOREIGN KEY (idGrupo) 
		REFERENCES ztGRUPO(idGrupo) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_ListaContato_Contato FOREIGN KEY (idContato) 
		REFERENCES ztCONTATO(idContato) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_ListaContato_Perfil FOREIGN KEY (idPerfil) 
		REFERENCES ztPERFIL(idPerfil) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_ListaContato_Status FOREIGN KEY (idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
); 
CREATE TABLE ztCHAMADA ( 
	idChamada INT IDENTITY(1,1) PRIMARY KEY, 
	idUsuario INT NOT NULL, 
	idContato INT NOT NULL, 
	idStatus INT NOT NULL, 
	dataHoraIniciada DATETIME DEFAULT GETDATE(), 
	Duracao DATETIME DEFAULT GETDATE(), 
	dataFinalizada DATETIME DEFAULT GETDATE(), 
	dataHoraExcluida DATETIME DEFAULT GETDATE(), 
	localizaContato VARCHAR(300) NOT NULL, 
	-- Relacionamento com Cascata (Cascateamento) 
	CONSTRAINT FK_Chamada_Usuario FOREIGN KEY (idUsuario) 
		REFERENCES ztUSUARIO(idUsuario) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Chamada_Contato FOREIGN KEY (idContato) 
		REFERENCES ztCONTATO(idContato) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Chamada_Status FOREIGN KEY (idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
); 

-- Início - Compartilhado 
CREATE TABLE ztGRUPO(
	idGrupo INT IDENTITY(1,1) PRIMARY KEY,
	tipo VARCHAR(20) UNIQUE  NOT NULL, 
	descricao VARCHAR(100) NOT NULL
	CONSTRAINT FK_Grupo_Usuario FOREIGN KEY(idUsuario) 
		REFERENCES ztUSUARIO(idusuario) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Grupo_STATUS FOREIGN KEY(idSTATUS) 
		REFERENCES ztSTATUS(idSTATUS) 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE 
);

CREATE TABLE ztCHAT(
	idChat INT IDENTITY(1,1) PRIMARY KEY, 
	idSTATUS INT NOT NULL,
	idGrupo INT NOT NULL, 
	dataHoraCriada DATETIME DEFAULT GETDATE(),
	duracao DATETIME DEFAULT GETDATE(),
	dataHoraIniciada DATETIME DEFAULT GETDATE(),
	dataHoraFinalizada DATETIME DEFAULT GETDATE(),
	CONSTRAINT FK_Chat_Grupo FOREIGN KEY(idGrupo) 
		REFERENCES ztGRUPO(idGrupo)
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Chat_STATUS FOREIGN KEY(idSTATUS) 
		REFERENCES ztSTATUS(idSTATUS)
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
);
 
 
CREATE TABLE ztENVIA(
	idEnvia INT IDENTITY(1,1) PRIMARY KEY, 
	idUsuario INT NOT NULL,
	idSTATUS INT NOT NULL, 
	idChat INT NOT NULL,
	dataHoraEntregue DATETIME DEFAULT GETDATE(),
	dataHoraLido DATETIME DEFAULT GETDATE(),
	dataHoraEnviada DATETIME DEFAULT GETDATE(),
	mensagem VARCHAR(300) NOT NULL,
	CONSTRAINT FK_Envia_Usuario FOREIGN KEY(idUsuario) 
	REFERENCES ztUSUARIO(idUsuario)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION,
	
	CONSTRAINT FK_Envia_STATUS
	FOREIGN KEY(idSTATUS) 
	REFERENCES ztSTATUS(idSTATUS)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION,
	
	CONSTRAINT FK_Envia_Chat
	FOREIGN KEY(idChat) 
	REFERENCES ztCHAT(idChat)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
);
 
 
CREATE TABLE ztRECEBE(
	idRecebe INT IDENTITY(1,1) PRIMARY KEY, 
	idContato INT NOT NULL,
	idSTATUS INT NOT NULL, 
	idChat INT NOT NULL,
	dataHoraEntregue DATETIME DEFAULT GETDATE(),
	dataHoraLido DATETIME DEFAULT GETDATE(),
	dataHoraEnviada DATETIME DEFAULT GETDATE(),
	mensagem VARCHAR(300) NOT NULL,
	CONSTRAINT FK_Recebe_Contato
	FOREIGN KEY(idContato) 
	REFERENCES ztCONTATO(idContato)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION,
	
	CONSTRAINT FK_Envia_STATUS
	FOREIGN KEY(idSTATUS) 
	REFERENCES ztSTATUS(idSTATUS)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION, 
	
	CONSTRAINT FK_Envia_Chat FOREIGN KEY(idChat) 
	REFERENCES ztCHAT(idChat)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
);
 
 
 
MERGE INTO ztGRUPO AS Target
USING (
VALUES
('Administrador', 'O usuário que irá administrar o grupo'),
('Moderador','O auxiliar do administrador do grupo'),
('Comum','Apenas um participante do grupo')
)
AS Source (tipo,descricao)
ON Target.tipo = Source.tipo
WHEN NOT MATCHED BY TARGET THEN 
INSERT (tipo,descricao)
Values (Source.tipo, Source.descricao)
WHEN MATCHED THEN
	UPDATE SET Target.descricao = Source.descricao;
GO
 
select * from ztGRUPO
 
GO
-- Fim - Compartilhado 


-- 3. Consulta geral de uma tabela 
SELECT * FROM ztCONTATO; 
GO 
SELECT * FROM ztLISTACONTATO; 
GO 
SELECT * FROM ztCHAMADA; 
GO 

/* 
SELECT * FROM ztGRUPO; 
GO 
SELECT * FROM ztCHAT; 
GO 
SELECT * FROM ztENVIA; 
GO 
*/ 
