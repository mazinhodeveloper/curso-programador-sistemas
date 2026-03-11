-- Comentario 
-- 1. Criar o banco de dados com o nome 
-- do projeto dbTeste 
--CREATE DATABASE dbZapTito; 
--GO 

-- 1. Usar o banco de dados 
USE dbZapTito; 
GO 

-- 2. Criar as tabelas de dependencias 
/* 
CREATE TABLE ztACL ( 
	idACL INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Master, Admin, Cliente, Funcionario 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
-- SELECT * FROM ztACL; 

/* 
CREATE TABLE ztSTATUS ( 
	idStatus INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Inativo, Ativo, Bloqueado, Pendente 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
-- SELECT * FROM ztSTATUS; 

/* 
CREATE TABLE ztPERFIL ( 
	idPerfil INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Admin, Moderador, Geral 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
-- SELECT * FROM ztPERFIL; 

/* 
CREATE TABLE ztUSUARIO ( 
	idUsuario INT IDENTITY(1,1) PRIMARY KEY, 
	idACL INT NOT NULL, 
	idStatus INT NOT NULL, 
	idPerfil INT NOT NULL, 
	nome VARCHAR(60) NOT NULL, 
	dataNascimento DATE NOT NULL, 
	numeroTelefone CHAR(14) UNIQUE NOT NULL, 
	senha VARCHAR(150) NOT NULL, -- Lembre-se: senha usndo no futuro HASH 
	-- Relacionamento com Cascata (Cascateamento) 
	CONSTRAINT FK_Usuario_ACL FOREIGN KEY (idACL) 
		REFERENCES ztACL(idACL) 
		-- N�o deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Usuario_Status FOREIGN KEY (idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		-- N�o deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (idPerfil) 
		REFERENCES ztPERFIL(idPerfil) 
		-- N�o deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE 
); 
*/ 
-- SELECT * FROM ztUSUARIO; 

/* 
CREATE TABLE ztDISPOSITIVO ( 
	idDispositivo INT IDENTITY(1,1) PRIMARY KEY, 
	dispositivo VARCHAR(20) UNIQUE NOT NULL -- ex: Smartphone, Desktop, Web 
); 
*/ 
-- SELECT * FROM ztDISPOSITIVO; 

/* 
CREATE TABLE ztVERIFICACAO ( 
	idVerificacao INT IDENTITY(1,1) PRIMARY KEY, 
	idDispositivo INT NOT NULL, 
	idUsuario INT NOT NULL, 
	numero CHAR(6) NOT NULL, 
	CONSTRAINT FK_Verificacao_Dispositivo FOREIGN KEY (idDispositivo) 
		REFERENCES ztDISPOSITIVO(idDispositivo) 
		-- N�o deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Verificacao_Usuario FOREIGN KEY (idUsuario) 
		REFERENCES ztUSUARIO(idUsuario) 
		-- N�o deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE 
); 
*/ 
-- SELECT * FROM ztVERIFICACAO; 

/* 
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
*/ 
-- SELECT * FROM ztCONTATO; 


-- Início - Compartilhado 
/* 
CREATE TABLE ztGRUPO(
	idGrupo INT IDENTITY(1,1) PRIMARY KEY, 
	idUsuario INT NOT NULL, 
	idStatus INT NOT NULL, 
	tipo VARCHAR(20) UNIQUE  NOT NULL, 
	descricao VARCHAR(100) NOT NULL
	CONSTRAINT FK_Grupo_Usuario FOREIGN KEY(idUsuario) 
		REFERENCES ztUSUARIO(idUsuario) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION, 
	CONSTRAINT FK_Grupo_STATUS FOREIGN KEY(idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
); 
*/ 
-- SELECT * FROM ztGRUPO; 
-- FIM - Compartilhado 

/* 
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
*/ 
-- SELECT * FROM ztLISTACONTATO;   

/* 
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
*/ 
-- SELECT * FROM ztCHAMADA; 


-- Início - Compartilhado 
/* 
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
	CONSTRAINT FK_Chat_Status FOREIGN KEY(idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		ON DELETE NO ACTION 
		ON UPDATE NO ACTION 
);
*/ 
-- SELECT * FROM ztCHAT; 
-- FIM - Compartilhado  

-- Início - Compartilhado 
/* 
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
	
	CONSTRAINT FK_Envia_Status
	FOREIGN KEY(idStatus) 
	REFERENCES ztSTATUS(idStatus)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION,
	
	CONSTRAINT FK_Envia_Chat
	FOREIGN KEY(idChat) 
	REFERENCES ztCHAT(idChat)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
);
*/ 
-- SELECT * FROM ztENVIA; 
-- FIM - Compartilhado  

-- Início - Compartilhado 
/* 
CREATE TABLE ztRECEBE(
	idRecebe INT IDENTITY(1,1) PRIMARY KEY, 
	idContato INT NOT NULL,
	idStatus INT NOT NULL, 
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
	
	CONSTRAINT FK_Recebe_Status 
	FOREIGN KEY(idStatus) 
	REFERENCES ztSTATUS(idStatus)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION, 
	
	CONSTRAINT FK_Recebe_Chat 
	FOREIGN KEY(idChat) 
	REFERENCES ztCHAT(idChat)
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
); 
*/ 
-- SELECT * FROM ztRECEBE; 
-- FIM - Compartilhado  
 
-- 3. Consulta geral de uma tabela 
SELECT * FROM ztACL; 
GO 
SELECT * FROM ztCHAMADA; 
GO 
SELECT * FROM ztCHAT; 
GO 
SELECT * FROM ztCONTATO; 
GO 
SELECT * FROM ztDISPOSITIVO; 
GO 
SELECT * FROM ztENVIA; 
GO 
select * FROM ztGRUPO; 
GO 
SELECT * FROM ztLISTACONTATO; 
GO 
SELECT * FROM ztPERFIL; 
GO 
SELECT * FROM ztRECEBE; 
GO 
SELECT * FROM ztSTATUS; 
GO 
SELECT * FROM ztUSUARIO; 
GO 
SELECT * FROM ztVERIFICACAO; 
GO 

