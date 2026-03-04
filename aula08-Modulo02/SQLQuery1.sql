-- Comentario 
-- 1. Criar o banco de dados com o nome 
-- do projeto dbZapTito 
-- CREATE DATABASE dbZapTito; 

-- 2. Usar o banco de dados 
USE dbZapTito; 
GO 
-- 3. Criar as tabelas de dependencias 
/*CREATE TABLE ACL ( 
	idAcl INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) NOT NULL, -- ex: Admin, Usuario, Funcionario 
	descricao VARCHAR(100) NOT NULL 
); */ 
/*CREATE TABLE STATUS (
	idStatus INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) NOT NULL, -- ex: Inativo, Ativo, Bloqueado 
	descricao VARCHAR(100) NOT NULL 
); 
CREATE TABLE PERFIL (
	idPerfil INT IDENTITY(1,1) PRIMARY KEY, 
	tipo VARCHAR(20) NOT NULL, -- ex: Admin, Moderador, Geral 
	descricao VARCHAR(100) NOT NULL 
); 
CREATE TABLE DISPOSITIVO (
	idDispositivo INT IDENTITY(1,1) PRIMARY KEY, 
	dispositivo VARCHAR(20) NOT NULL -- ex: Smartphone, Desktop, Web 
); 
-- ACL, STATUS, PERFIL, DISPOSITIVO */ 
/*CREATE TABLE USUARIO (
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
	CONSTRAINT FK_Usuario_Acl FOREIGN KEY (idAcl) REFERENCES ACL(idAcl), 
	CONSTRAINT FK_Usuario_Status FOREIGN KEY (idStatus) REFERENCES STATUS(idStatus), 
	CONSTRAINT FK_Usuario_Perfil FOREIGN KEY (idPerfil) REFERENCES PERFIL(idPerfil) 
); */ 
/*CREATE TABLE VERIFICACAO (
	idVerificacao INT IDENTITY(1,1) PRIMARY KEY, 
	idDispositivo INT NOT NULL, 
	idUsuario INT NOT NULL, 
	numero CHAR(6) NOT NULL, 
	CONSTRAINT FK_Verificacao_Dispositivo FOREIGN KEY (idDispositivo) REFERENCES DISPOSITIVO(idDispositivo), 
	CONSTRAINT FK_Verificacao_Usuario FOREIGN KEY (idUsuario) REFERENCES USUARIO(idUsuario) 
); */ 
-- SELECT * FROM ACL; 
-- SELECT * FROM STATUS; 
-- SELECT * FROM PERFIL; 
-- SELECT * FROM DISPOSITIVO; 
-- SELECT * FROM USUARIO; 
-- SELECT * FROM VERIFICACAO; 
GO
