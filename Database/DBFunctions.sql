
--SP para registrar el usuario en la DB ////Ultima Actualizacion 8/8/2024 14:23
Create OR Alter PROCEDURE SP_REGISTRO_USUARIO_REGULAR(
    @NOMBRE nvarchar(50),
    @APELLIDOS nvarchar(50),
    @CORREO_ELECTRONICO nvarchar(max),
    @PASSWORD nvarchar(max),
    @FECNACIMIENTO DATETIME,
    @CODPAIS nvarchar(2),
    @IDRETURN int output,
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
)
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT * FROM [dbo].[Usuario] WHERE [email] = @CORREO_ELECTRONICO)	
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 1; --correo ya registrada
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: CORREO YA REGISTRADO';

        END
        ELSE
        BEGIN
            DECLARE @IDPAIS int
            SELECT @IDPAIS = [idPais] FROM [dbo].[PAIS] WHERE [codigo] = @CODPAIS
            
            IF @IDPAIS IS NULL
            BEGIN
                SET @IDRETURN = -1;
                SET @ERRORID = 2; --Código de país inválido
                SET @ERRORDESCRIPCION = 'ERROR DESDE BD: CÓDIGO DE PAÍS INVÁLIDO';

            END
            ELSE
            BEGIN
                INSERT INTO Usuario 
                (
                    [nombre],
                    [apellido],
                    [fecNacimiento],
                    [email],
                    [idPais],
                    [contrasenha],
                    [userReg]
                )
                VALUES
                (
                    @NOMBRE,
                    @APELLIDOS,
                    @FECNACIMIENTO,
                    @CORREO_ELECTRONICO,
                    @IDPAIS,
                    @PASSWORD,
                    1
                );

                SET @IDRETURN = SCOPE_IDENTITY();                
            END
        END
    END TRY
    
    BEGIN CATCH
        SET @IDRETURN = -1;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END
GO

--SP para el login de usuario ////Ultima Actualizacion 8/8/2024 14:23
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Login]
    @CORREO_ELECTRONICO nVARCHAR(50), -- Tamaño típico para un email
    @PASSWORD NVARCHAR(max),           -- Tamaño puede variar dependiendo de tu esquema de encriptación
    @id_usuario INT OUTPUT,
    @nombre NVARCHAR(50) OUTPUT,
    @apellidos NVARCHAR(50) OUTPUT
AS
BEGIN
    SET @id_usuario = 0; -- Inicializar el valor en cero
    SET @nombre = '';
    SET @apellidos = '';
    
    IF EXISTS (
        SELECT idUsuario, nombre, apellidos
        FROM TB_USUARIO
        WHERE CORREO_ELECTRONICO = @CORREO_ELECTRONICO
            AND PASSWORD = @PASSWORD
    )
    BEGIN
        SELECT @id_usuario = id_usuario, @estado = estado, @nombre = nombre, @apellidos = apellidos
        FROM TB_USUARIO
        WHERE CORREO_ELECTRONICO = @CORREO_ELECTRONICO
            AND PASSWORD = @PASSWORD;
    END
END;

--SP para insertar un evento ////Ultima Actualizacion 8/8/2024 19:04

CREATE or alter PROCEDURE SP_CREAR_EVENTO
	@NOMBRE NVARCHAR(255),
	@DESCRIPCION NVARCHAR(255),
	@FECHORA_INICIO DATETIME,
	@FECHORA_FIN DATETIME,
	@LIMITE_USUARIO INT,
	@DURACION FLOAT,
	@EMAIL NVARCHAR(255)
AS
BEGIN
	
	DECLARE @CodigoAlfanumerico NVARCHAR(6)
	DECLARE @Existe BIT = 1

	-- Ciclo DO WHILE
	WHILE @Existe = 1
	BEGIN

		-- Generar el código alfanumérico
		PRINT 'Este es un mensaje de prueba';
		SET @CodigoAlfanumerico = SUBSTRING(CONVERT(VARCHAR(40), NEWID()), 1, 6)

		-- Verificar si el código ya existe en la tabla Evento y si la fechaHoraFin ha pasado
		IF NOT EXISTS (
			SELECT 1 
			FROM [dbo].[Evento] 
			WHERE [codInvitacion] = @CodigoAlfanumerico 
			AND [fechaHoraFin] > GETDATE()
		)
		BEGIN
			-- Si no existe o existe pero la fechaHoraFin ya ha pasado, salir del ciclo
			SET @Existe = 0
		END
	END

	DECLARE @ID_USER INT
	SELECT @ID_USER =  [idUsuario] FROM [dbo].[Usuario] WHERE [email] = @EMAIL

		        INSERT INTO [dbo].[Evento]
                (
                    [codInvitacion],
					[nombre],
					[descripcion],
					[fechaHoraInicio],
					[fechaHoraFin],
					[limiteUsuarios],
					[duracion],
					[idUsuario]
                )
                VALUES
                (
                    @CodigoAlfanumerico,
					@NOMBRE,
					@DESCRIPCION,
					@FECHORA_INICIO,
					@FECHORA_FIN,
					@LIMITE_USUARIO,
					@DURACION,
					@ID_USER
                );
END;


--SP para insertar una Tarea ////Ultima Actualizacion 8/8/2024 19:16

CREATE PROCEDURE SP_INSERTAR_TAREA
	@TITULO VARCHAR(255),
	@DESCRIPCION VARCHAR(255),
	@FECHORA_INICIO DATETIME,
	@FECHORA_FIN DATETIME,
	@EMAIL VARCHAR(255),
	@PRIORIDAD VARCHAR(50)
AS
BEGIN
	DECLARE @ID_USER INT
	SELECT @ID_USER =  [idUsuario] FROM [dbo].[Usuario] WHERE [email] = @EMAIL
	DECLARE @ID_PRIORIDAD INT
	SELECT @ID_PRIORIDAD =  [idPrioridad] FROM [dbo].[Prioridad] WHERE [descripcion] = @PRIORIDAD

			        INSERT INTO [dbo].[Tarea]
                (
                    [titulo],
					[descripcion],
					[fechaHoraInicio],
					[fechaHoraFinal],
					[idUsuario],
					[idPrioridad]

                )
                VALUES
                (
                    @TITULO,
					@DESCRIPCION,
					@FECHORA_INICIO,
					@FECHORA_FIN,
					@ID_USER,
					@ID_PRIORIDAD
                );

END