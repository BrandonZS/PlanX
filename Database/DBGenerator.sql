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
	idPais INT IDENTITY(1,1)	NOT NULL,
	nombre varchar(50) NOT NULL,
	codigo varchar(2) NOT NULL,
	horarioUTC INT NOT NULL,
	CONSTRAINT [PK_Pais] PRIMARY KEY (idPais ASC)
);


-- Table: Usuario
CREATE TABLE Usuario (
    idUsuario int IDENTITY(1,1)NOT NULL,
    nombre varchar(255) NOT NULL,
    apellido varchar(255) NULL,
    email varchar(255) NULL,
    idPais INT NULL,
    contrasenha varchar(255) NULL,
    userReg bit NOT NULL,
    fecRegistro datetime NOT NULL DEFAULT GETUTCDATE(),
    estado bit NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY (idUsuario ASC),
	CONSTRAINT FK_Pais_Usuario FOREIGN KEY (idPais) REFERENCES PAIS(idPais)
);
GO

-- Table: Evento
CREATE TABLE Evento (
    idEvento int IDENTITY(1,1) NOT NULL,
    codInvitacion varchar(255) NULL,
    nombre varchar(255) NULL,
    descripcion varchar(255) NULL,
    fechaHoraInicio datetime NOT NULL,
    fechaHoraFin datetime NOT NULL,
    limiteUsuarios int NOT NULL,
    duracion float NOT NULL,
    idUsuario int NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY (idEvento ASC),
    CONSTRAINT FK_UsuarioAdministrador FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT CHK_FechaHoraFin_Despues_FechaHoraInicio CHECK (fechaHoraFin > fechaHoraInicio),
    CONSTRAINT CHK_LimiteUsuarios_Positive CHECK (limiteUsuarios > 0),
    CONSTRAINT CHK_Duracion_Positive CHECK (duracion > 0),
    CONSTRAINT CHK_CodInvitacion_Format CHECK (codInvitacion LIKE '[A-Z0-9]%')
);
GO
-- Table: Prioridad
CREATE TABLE Prioridad (
    idPrioridad int IDENTITY(1,1) NOT NULL,
    descripcion varchar(255) NULL,
    CONSTRAINT [PK_Prioridad] PRIMARY KEY (idPrioridad ASC)
);
GO
-- Table: Tarea
CREATE TABLE Tarea (
    idTarea int IDENTITY(1,1) NOT NULL,
    titulo varchar(255) NOT NULL,
    descripcion varchar(255) NULL,
    fechaHoraInicio datetime NOT NULL,
    fechaHoraFinal datetime NOT NULL,
    idUsuario int NOT NULL,
    idPrioridad int NOT NULL,
    CONSTRAINT [PK_Tarea] PRIMARY KEY (idTarea ASC),
    CONSTRAINT FK_Tarea_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT FK_Tarea_Prioridad FOREIGN KEY (idPrioridad) REFERENCES Prioridad(idPrioridad),
    CONSTRAINT CHK_FechaHoraFin_Despues_FechaHoraInicio_Tarea CHECK (fechaHoraFinal > fechaHoraInicio)
);
GO



-- Table: EventoUsuario
CREATE TABLE EventoUsuario (
    idUsuario int NOT NULL,
    idEvento int NOT NULL,
    fechaHoraInicio datetime NOT NULL,
    fechaHoraFinal datetime NOT NULL,
    CONSTRAINT [PK_EventoUsuario] PRIMARY KEY (idUsuario ASC, idEvento ASC),
    CONSTRAINT FK_EventoUsuario_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT FK_EventoUsuario_Evento FOREIGN KEY (idEvento) REFERENCES Evento(idEvento),
    CONSTRAINT CHK_FechaHoraFin_Despues_FechaHoraInicio_Registro CHECK (fechaHoraFinal > fechaHoraInicio)
);
GO

-- Table: Sesion
CREATE TABLE Sesion (
    idSesion int IDENTITY(1,1) NOT NULL,
    sesion varchar(255) NULL,
    usuario varchar(255) NULL,
    Origen varchar(255) NULL,
    fechaInicio datetime NOT NULL,
    fechaFin datetime NOT NULL,
    Estado varchar(50) NULL,
    CONSTRAINT [PK_Sesion] PRIMARY KEY (idSesion ASC),
    CONSTRAINT CHK_fechaFin_Despues_fechaInicio CHECK (fechaFin > fechaInicio)
);
GO

-- Table: ErrorBD
CREATE TABLE ErrorBD (
    idErrorBD int IDENTITY(1,1) NOT NULL,
    Severidad int NOT NULL,
    SP varchar(255) NULL,
    Numero int NOT NULL,
    Descripcion varchar(255) NULL,
    Linea int NOT NULL,
    fechaHora datetime NOT NULL,
    CONSTRAINT [PK_ErrorBD] PRIMARY KEY (idErrorBD ASC)
);
GO