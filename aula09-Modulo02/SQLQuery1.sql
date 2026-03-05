-- Comentario 
-- 1. Criar o banco de dados com o nome 
-- do projeto dbZapTito 
--CREATE DATABASE dbZapTito; 

-- 2. Usar o banco de dados 
USE dbZapTito; 
GO 

-- 3. Criar as tabelas de dependencias 
/* 
CREATE TABLE ztACL ( 
	idACL INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Master, Admin, Cliente, Funcionario 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
/* 
CREATE TABLE ztSTATUS ( 
	idStatus INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Inativo, Ativo, Bloqueado, Pendente 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
/* 
CREATE TABLE ztPERFIL ( 
	idPerfil INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) UNIQUE NOT NULL, -- ex: Admin, Moderador, Geral 
	descricao VARCHAR(100) NOT NULL 
); 
*/ 
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
		-- Não deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Usuario_Status FOREIGN KEY (idStatus) 
		REFERENCES ztSTATUS(idStatus) 
		-- Não deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (idPerfil) 
		REFERENCES ztPERFIL(idPerfil) 
		-- Não deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE 
); 
*/ 
/* 
CREATE TABLE ztDISPOSITIVO ( 
	idDispositivo INT IDENTITY(1,1) PRIMARY KEY, 
	dispositivo VARCHAR(20) UNIQUE NOT NULL -- ex: Smartphone, Desktop, Web 
); 
*/ 
/* 
CREATE TABLE ztVERIFICACAO ( 
	idVerificacao INT IDENTITY(1,1) PRIMARY KEY, 
	idDispositivo INT NOT NULL, 
	idUsuario INT NOT NULL, 
	numero CHAR(6) NOT NULL, 
	CONSTRAINT FK_Verificacao_Dispositivo FOREIGN KEY (idDispositivo) 
		REFERENCES ztDISPOSITIVO(idDispositivo) 
		-- Não deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE, 
	CONSTRAINT FK_Verificacao_Usuario FOREIGN KEY (idUsuario) 
		REFERENCES ztUSUARIO(idUsuario) 
		-- Não deixa deletar a ACL em uso 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE 
); 
*/ 

-- 4. Seleciona a tabela 
-- SELECT * FROM ztACL; 
-- SELECT * FROM ztSTATUS; 
-- SELECT * FROM ztPERFIL; 
-- SELECT * FROM ztDISPOSITIVO; 
-- SELECT * FROM ztUSUARIO; 
-- SELECT * FROM ztVERIFICACAO; 
GO 
