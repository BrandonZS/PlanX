CREATE DATABASE PLANXAPP
GO

/** SE SELECCIONA LA BASE DE DATOS CREADA**/
USE PLANXAPP
GO

/** INSTRUCCION QUE PERMITE CREAR LOS DIAGRAMAS**/
Alter authorization on database::PLANXAPP to sa 

/** SE ESTABLECE LA FECHA DE LA BASE DE DATOS EN ESPA OL**/
SET DATEFORMAT dmy
SET LANGUAGE spanish

CREATE TABLE PAIS (
	idPais tinyInt	NOT NULL,
	nombre varchar(50) NOT NULL,
	codigo varchar(2) NOT NULL,
	horarioUTC tinyINT NOT NULL,
	CONSTRAINT [PK_Pais] PRIMARY KEY (idPais ASC)
);


-- Table: Usuario
CREATE TABLE Usuario (
    idUsuario int NOT NULL,
    nombre varchar(255) NOT NULL,
    apellido varchar(255) NULL,
    fecNacimiento date NULL,
    email varchar(255) NULL,
    idPais tinyInt NULL,
    contrasenia varchar(255) NULL,
    userReg bit NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY (idUsuario ASC),
	CONSTRAINT FK_Pais_Usuario FOREIGN KEY (idPais) REFERENCES PAIS(idPais)
);
GO

-- Table: Evento
CREATE TABLE Evento (
    idEvento int NOT NULL,
    codInvitacion varchar(255) NULL,
    nombre varchar(255) NULL,
    descripcion varchar(255) NULL,
    fechaHoraInicio datetime NOT NULL,
    fechaHoraFin datetime NOT NULL,
    limiteUsuarios int NOT NULL,
    duracion float NOT NULL,
    idUsuario int NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY (idEvento ASC),
    CONSTRAINT FK_UsuarioAdministrador FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
);
GO
-- Table: Prioridad
CREATE TABLE Prioridad (
    idPrioridad int NOT NULL,
    descripcion varchar(255) NULL,
    CONSTRAINT [PK_Prioridad] PRIMARY KEY (idPrioridad ASC)
);
GO
-- Table: Tarea
CREATE TABLE Tarea (
    idTarea int NOT NULL,
    titulo varchar(255) NOT NULL,
    descripcion varchar(255) NULL,
    fechaHoraInicio datetime NOT NULL,
    fechaHoraFinal datetime NOT NULL,
    idUsuario int NOT NULL,
    idPrioridad int NOT NULL,
    CONSTRAINT [PK_Tarea] PRIMARY KEY (idTarea ASC),
    CONSTRAINT FK_Tarea_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT FK_Tarea_Prioridad FOREIGN KEY (idPrioridad) REFERENCES Prioridad(idPrioridad)
);
GO



-- Table: EventoUsuario
CREATE TABLE EventoUsuario (
    idUsuario int NOT NULL,
    idEvento int NOT NULL,
    horaInicial datetime NOT NULL,
    horaFinal datetime NOT NULL,
    CONSTRAINT [PK_EventoUsuario] PRIMARY KEY (idUsuario ASC, idEvento ASC),
    CONSTRAINT FK_EventoUsuario_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT FK_EventoUsuario_Evento FOREIGN KEY (idEvento) REFERENCES Evento(idEvento)
);
GO

-- Table: Sesion
CREATE TABLE Sesion (
    idSesion int NOT NULL,
    sesion varchar(255) NULL,
    usuario varchar(255) NULL,
    Origen varchar(255) NULL,
    fechaInicio datetime NOT NULL,
    fechaFin datetime NOT NULL,
    Estado varchar(50) NULL,
    CONSTRAINT [PK_Sesion] PRIMARY KEY (idSesion ASC)
);
GO

-- Table: ErrorBD
CREATE TABLE ErrorBD (
    idErrorBD int NOT NULL,
    Severidad int NOT NULL,
    SP varchar(255) NULL,
    Numero int NOT NULL,
    Descripcion varchar(255) NULL,
    Linea int NOT NULL,
    fechaHora datetime NOT NULL,
    CONSTRAINT [PK_ErrorBD] PRIMARY KEY (idErrorBD ASC)
);
GO