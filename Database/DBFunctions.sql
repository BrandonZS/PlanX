ALTER PROCEDURE SP_REGISTRO_USUARIO_REGULAR(
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
