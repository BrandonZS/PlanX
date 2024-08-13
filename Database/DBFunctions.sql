
--SP para registrar el usuario en la DB ////Ultima Actualizacion 8/8/2024 14:23
Create OR Alter PROCEDURE SP_REGISTRO_USUARIO_REGULAR(
    @NOMBRE nvarchar(255),
    @APELLIDOS nvarchar(255),
    @CORREO_ELECTRONICO nvarchar(max),
    @PASSWORD nvarchar(max),
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
                    [email],
                    [idPais],
                    [contrasenha],
                    [userReg],
					[estado]
                )
                VALUES
                (
                    @NOMBRE,
                    @APELLIDOS,
                    @CORREO_ELECTRONICO,
                    @IDPAIS,
                    @PASSWORD,
                    1,
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

CREATE OR ALTER PROCEDURE SP_ACTUALIZAR_USUARIO_REGULAR
	@NOMBRE NVARCHAR(255),
	@APELLIDO NVARCHAR(255),
	@CONTRA_ANTIGUA NVARCHAR(255),
	@CONTRA_NUEVA NVARCHAR(255),
	@ID_USER INT
AS
BEGIN

	IF @NOMBRE IS NOT NULL
	BEGIN
		UPDATE  [dbo].[Usuario]
		SET [nombre] = @NOMBRE
		WHERE [idUsuario] = @ID_USER
	END
	IF @APELLIDO IS NOT NULL
	BEGIN
		UPDATE  [dbo].[Usuario]
		SET [apellido] = @APELLIDO
		WHERE [idUsuario] = @ID_USER
	END
	IF @CONTRA_ANTIGUA IS NOT NULL AND @CONTRA_NUEVA IS NOT NULL
	BEGIN
		if(SELECT [contrasenha] FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER ) = @CONTRA_ANTIGUA
		BEGIN
			UPDATE [dbo].[Usuario]
			SET [contrasenha] = @CONTRA_NUEVA
			WHERE [idUsuario] = @ID_USER
		END
	END 
END
GO

CREATE OR ALTER PROCEDURE SP_ELIMINAR_USUARIO_REGULAR
	@ID_USER INT,
	@PASSWORD NVARCHAR(max),
	@IDRETURN int output,
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS 
BEGIN
	IF EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER)
	BEGIN
		if(SELECT [contrasenha] FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER ) = @PASSWORD
		BEGIN
			UPDATE [dbo].[Usuario]
			SET [estado] = 0
			WHERE [idUsuario] = @ID_USER
		END
		ELSE
		BEGIN
			SET @IDRETURN = 0;
            SET @ERRORID = 2;
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: CONTRASEÑA INCORRECTA';
		END
	END
	ELSE
	BEGIN 
	        SET @IDRETURN = 0;
            SET @ERRORID = 1;
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: USUARIO NO ENCONTRADO';
	END
END
GO

--SP para el login de usuario ////Ultima Actualizacion 8/8/2024 14:23

CREATE PROCEDURE SP_LOGIN
    @CORREO_ELECTRONICO nVARCHAR(50), 
    @PASSWORD NVARCHAR(max),           
    @id_usuario INT OUTPUT,
    @nombre NVARCHAR(50) OUTPUT,
    @apellidos NVARCHAR(50) OUTPUT
AS
BEGIN
    SET @id_usuario = 0;
    SET @nombre = '';
    SET @apellidos = '';
    
    IF EXISTS (
        SELECT [idUsuario], [nombre], [apellido]
        FROM [dbo].[Usuario]
        WHERE [email] = @CORREO_ELECTRONICO
            AND [contrasenha] = @PASSWORD
    )
    BEGIN
        SELECT @id_usuario = [idUsuario], @nombre = nombre, @apellidos = [apellido]
        FROM [dbo].[Usuario]
        WHERE  [email] =  @CORREO_ELECTRONICO
            AND [contrasenha] = @PASSWORD;
    END
END
GO

--SP para insertar un evento ////Ultima Actualizacion 8/8/2024 20:46

CREATE or alter PROCEDURE SP_INSERTAR_EVENTO
	@NOMBRE NVARCHAR(255),
	@DESCRIPCION NVARCHAR(255),
	@FECHORA_INICIO DATETIME,
	@FECHORA_FIN DATETIME,
	@LIMITE_USUARIO INT,
	@DURACION FLOAT,
	@ID_USER INT,
	@IDRETURN int output,
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS
BEGIN
	
	DECLARE @CodigoAlfanumerico NVARCHAR(6)
	DECLARE @Existe BIT = 1

	BEGIN TRY
		WHILE @Existe = 1
		BEGIN

			SET @CodigoAlfanumerico = SUBSTRING(CONVERT(VARCHAR(40), NEWID()), 1, 6)

			-- Verificar si el código ya existe en la tabla Evento y si la fechaHoraFin ha pasado
			IF NOT EXISTS (
				SELECT 1 
				FROM [dbo].[Evento] 
				WHERE [codInvitacion] = @CodigoAlfanumerico 
				AND [fechaHoraInicio] > GETDATE()
			)
			BEGIN
				-- Si no existe o existe pero la fechaHoraFin ya ha pasado, salir del ciclo
				SET @Existe = 0
			END
		END

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
			SET @IDRETURN = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
        SET @IDRETURN = -1;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZAR_EVENTO
	@TITULO NVARCHAR(255),
	@DESCRIPCION NVARCHAR(255),
	@ID_USER INT,
	@COD_INVI NVARCHAR (6),
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER)
	BEGIN
        SET @ERRORID = 1;
		SET @ERRORDESCRIPCION = 'ERROR DESDE BD: USUARIO NO ENCONTRADO';
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Evento]
		SET [nombre] = @TITULO, [descripcion] = @DESCRIPCION
		WHERE [idUsuario] = @ID_USER AND [codInvitacion] = @COD_INVI AND [fechaHoraInicio] < GETDATE()
	END
END
GO

CREATE OR ALTER PROCEDURE SP_ELIMINAR_EVENTO
    @ID_USER INT,
	@COD_INV NVARCHAR(6),
	@ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS
BEGIN
    -- Iniciar la transacción
    BEGIN TRANSACTION;
    DECLARE @ID_EVENTO INT 
	SELECT @ID_EVENTO = [idEvento] FROM [dbo].[Evento] WHERE [codInvitacion] = @COD_INV AND [fechaHoraInicio] < GETDATE()
    BEGIN TRY
        DELETE FROM [dbo].[EventoUsuario]
        WHERE [idEvento] = @ID_EVENTO;
        DELETE FROM Evento
        WHERE [idEvento] = @ID_EVENTO;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_OBTENER_EVENTO
    @ID_USER INT,
	@COD_INVI VARCHAR(255) OUTPUT,
	@NOMBRE VARCHAR(255) OUTPUT, 
	@DESCRIPCION VARCHAR(255) OUTPUT,
	@FECINICIO DATETIME OUTPUT,
	@FECFIN DATETIME OUTPUT,
	@LIM_USERS INT OUTPUT,
	@DURACION FLOAT OUTPUT
AS
BEGIN

    SELECT 
        @COD_INVI = [codInvitacion],
        @NOMBRE = [nombre],
        @DESCRIPCION = [descripcion],
        @FECINICIO = [fechaHoraInicio],
        @FECFIN = [fechaHoraFin],
        @LIM_USERS = [limiteUsuarios],
        @DURACION = [duracion]
    FROM [dbo].[Evento]
    WHERE [idUsuario] = @ID_USER;
END;
GO
--SP para insertar una Tarea ////Ultima Actualizacion 8/8/2024 19:16
CREATE OR ALTER PROCEDURE SP_INSERTAR_TAREA
	@TITULO VARCHAR(255),
	@DESCRIPCION VARCHAR(255),
	@FECHORA_INICIO DATETIME,
	@FECHORA_FIN DATETIME,
	@ID_USER INT,
	@PRIORIDAD VARCHAR(50),
	@IDRETURN int output,
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS
BEGIN
	BEGIN TRY

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
			SET @IDRETURN = SCOPE_IDENTITY();    
			
	END TRY
	BEGIN CATCH
        SET @IDRETURN = -1;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE SP_OBTENER_TAREA
    @ID_USER INT,
	@TITULO VARCHAR(255) OUTPUT,
	@DESCRIPCION VARCHAR(255) OUTPUT,
	@FECINICIO DATETIME OUTPUT,
	@FECFIN DATETIME OUTPUT,
	@ID_PRIORIDAD INT OUTPUT
AS
BEGIN
	DECLARE @PRIORIDAD VARCHAR(255)
	SELECT @PRIORIDAD = [descripcion] FROM [dbo].[Prioridad] WHERE [idPrioridad] = @ID_PRIORIDAD
    SELECT 
        @TITULO = [titulo],
        @DESCRIPCION = [descripcion],
        @FECINICIO = [fechaHoraInicio],
        @FECFIN = [fechaHoraFinal],
        @PRIORIDAD = [idPrioridad]
    FROM [dbo].[Tarea]
    WHERE [idUsuario] = @ID_USER;
END;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZAR_TAREA
	@TITULO NVARCHAR(255),
	@DESCRIPCION NVARCHAR(255),
	@ID_USER INT,
	@ID_TAREA INT,
    @ERRORID int output,
    @ERRORDESCRIPCION nvarchar(max) output
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER)
	BEGIN
        SET @ERRORID = 1;
		SET @ERRORDESCRIPCION = 'ERROR DESDE BD: USUARIO NO ENCONTRADO';
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Tarea]
		SET [titulo] = @TITULO, [descripcion]= @DESCRIPCION
		WHERE [idUsuario] = @ID_USER AND [idTarea] = @ID_TAREA
	END
END
GO

CREATE OR ALTER PROCEDURE SP_ELIMINAR_TAREA
	@ID_USER INT,
	@ID_TAREA INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [dbo].[Tarea] WHERE [idTarea]= @ID_TAREA AND [idUsuario] = @ID_USER)
	BEGIN
	DELETE FROM [dbo].[Tarea]
	WHERE [idTarea] = @ID_TAREA
	END
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRO_EVENTO_REGULAR
    @ID_USER INT,
    @COD_INVI VARCHAR(6),
    @FEC_INICIO DATETIME,
    @FEC_FIN DATETIME,
    @IDRETURN INT OUTPUT,
    @ERRORID INT OUTPUT,
    @ERRORDESCRIPCION NVARCHAR(MAX) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verifica si el usuario existe
        IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE [idUsuario] = @ID_USER)
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 1;
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: USUARIO NO ENCONTRADO';
            RETURN;
        END

        -- Verifica si el código de invitación es válido y la fecha de inicio es anterior a la actual
        IF NOT EXISTS (SELECT 1 FROM [dbo].[Evento] WHERE [codInvitacion] = @COD_INVI AND [fechaHoraInicio] > GETDATE())
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 2;
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: INVITACION NO VALIDA';
            RETURN;
        END

        -- Obtiene las fechas de inicio y fin del evento
        DECLARE @INICIO_EVENTO DATETIME;
        DECLARE @FINAL_EVENTO DATETIME;
        DECLARE @ID_EVENTO INT;

        SELECT 
            @INICIO_EVENTO = [fechaHoraInicio], 
            @FINAL_EVENTO = [fechaHoraFin], 
            @ID_EVENTO = [idEvento]
        FROM 
            [dbo].[Evento] 
        WHERE 
            [codInvitacion] = @COD_INVI AND [fechaHoraInicio] > GETDATE();

        -- Verifica si las fechas de inicio y fin proporcionadas son válidas dentro del rango del evento
        IF (@FEC_INICIO < @INICIO_EVENTO OR @FEC_FIN > @FINAL_EVENTO)
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 3;
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: HORARIOS NO VALIDOS';
            RETURN;
        END

        -- Inserta el registro en la tabla EventoUsuario
        INSERT INTO [dbo].[EventoUsuario]
        (
            [idUsuario],
            [idEvento],
            [fechaHoraInicio],
            [fechaHoraFinal]
        )
        VALUES
        (
            @ID_USER,
            @ID_EVENTO,
            @FEC_INICIO,
            @FEC_FIN
        );

        -- Devuelve el ID del registro insertado
        SET @IDRETURN = SCOPE_IDENTITY();
        SET @ERRORID = 0;
        SET @ERRORDESCRIPCION = 'Registro exitoso';
    END TRY

    BEGIN CATCH
        -- Manejo de errores
        SET @IDRETURN = 0;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_REGISTRO_EVENTO_INVITADO
    @NOMBRE VARCHAR(255),
    @APELLIDO VARCHAR(255),
    @COD_INVI VARCHAR(6),
    @FEC_INICIO DATETIME,
    @FEC_FIN DATETIME,
    @IDRETURN int OUTPUT,
    @ERRORID int OUTPUT,
    @ERRORDESCRIPCION nvarchar(MAX) OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        IF NOT EXISTS (SELECT 1 FROM [dbo].[Evento] WHERE [codInvitacion] = @COD_INVI)
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 2; -- Invitación no válida
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: INVITACION NO VALIDA';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Inserción en la tabla Usuario
        INSERT INTO [dbo].[Usuario] ([nombre], [apellido], [userReg])
        VALUES (@NOMBRE, @APELLIDO, 0);

        DECLARE @ID_USER INT;
        SET @ID_USER = SCOPE_IDENTITY();

        -- Obtener los tiempos de inicio y fin del evento
        DECLARE @INICIO_EVENTO DATETIME;
        DECLARE @FINAL_EVENTO DATETIME;

        SELECT @INICIO_EVENTO = [fechaHoraInicio], @FINAL_EVENTO = [fechaHoraFin]
        FROM [dbo].[Evento]
        WHERE [codInvitacion] = @COD_INVI AND [fechaHoraInicio] > GETDATE();

        IF (@FEC_INICIO < @INICIO_EVENTO OR @FEC_FIN > @FINAL_EVENTO)
        BEGIN
            SET @IDRETURN = 0;
            SET @ERRORID = 3; -- Horarios no válidos
            SET @ERRORDESCRIPCION = 'ERROR DESDE BD: HORARIOS NO VALIDOS';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Inserción en la tabla EventoUsuario
        DECLARE @ID_EVENTO INT;
        SELECT @ID_EVENTO = [idEvento] FROM [dbo].[Evento] WHERE [codInvitacion] = @COD_INVI;

        INSERT INTO [dbo].[EventoUsuario] ([idUsuario], [idEvento], [fechaHoraInicio], [fechaHoraFinal])
        VALUES (@ID_USER, @ID_EVENTO, @FEC_INICIO, @FEC_FIN);

        -- Confirmar la transacción
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Manejo de errores
        SET @IDRETURN = 0;
        SET @ERRORID = ERROR_NUMBER();
        SET @ERRORDESCRIPCION = ERROR_MESSAGE();
    END CATCH
END;

