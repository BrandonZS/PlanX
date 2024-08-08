CREATE PROCEDURE SP_REGISTRO_USUARIO_REGULAR(
	@NOMBRE nvarchar(50),
	@APELLIDOS nvarchar(50),
	@CORREO_ELECTRONICO nvarchar(max),
	@PASSWORD nvarchar(max),
	@FECNACIMIENTO DATE,
	@PAISRESIDENCIA TINYINT,
	@IDRETURN int output,
	@ERRORID int output,
	@ERRORDESCRIPCION nvarchar(max) output
)
AS
BEGIN
	BEGIN TRY
	IF EXISTS (SELECT * FROM USUARIO WHERE email = @CORREO_ELECTRONICO) --¿el correo está registrada?
		-- Si, el correo si está registrada. Devolver error.
		BEGIN
			SET @IDRETURN = -1;
			SET @ERRORID = 1; --correo ya registrada
			SET @ERRORDESCRIPCION = 'ERROR DESDE BD: CORREO YA REGISTRADO';
		END
	ELSE
		-- No, la el correo no está registrada.
		--¡TODO BIEN! El correo no está registrados
				BEGIN
					
					INSERT INTO Usuario 
					(
						[nombre],
						[apellido],
						[fecNacimiento],
						[email],
						[idPais],
						[contrasenia],
						[userReg]
					)
				VALUES
					(
						@NOMBRE,
						@APELLIDOS,
						@FECNACIMIENTO,
						@CORREO_ELECTRONICO,
						@PAISRESIDENCIA,
						@PASSWORD,
						1
						
					);

					set @idReturn = scope_identity();
			END
		

	END TRY
	
	BEGIN CATCH
		set @idReturn = -1;
		set @errorId = ERROR_NUMBER();
		set @errorDescripcion = ERROR_MESSAGE();
		
	END CATCH
END
GO