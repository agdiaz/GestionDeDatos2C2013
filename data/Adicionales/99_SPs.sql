SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [TOP_4].[realizar_identificacion] 
	-- Add the parameters for the stored procedure here
	@userName nvarchar(50),
	@passwordHash varbinary(32),
	@resultado int OUTPUT
AS
BEGIN
	--  0 Exito
	--  1 Bloqueado
	--  2 Usuario invalido o contrasena falsa
	SET NOCOUNT ON;
	
	DECLARE @hashReal varbinary(32)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.hash_password, @fallidos=us.cant_intentos_fallidos
	FROM [TOP_4].Usuario us
	WHERE us.username = @userName
	
	IF @@ROWCOUNT = 0
	BEGIN
		--Usuario invalido
		SET @resultado = -2
		RETURN
	END
	
	IF @fallidos >= 3
	BEGIN
		--Usuario bloqueado
		SET @resultado = -1
		RETURN
	END
	
	IF @hashReal = @passwordHash
	BEGIN
		--Exito
		UPDATE [TOP_4].Usuario
		SET cant_intentos_fallidos = 0
		WHERE username = @userName
		
		SET @resultado = 0
		
		RETURN
	END
	
	--Password incorrecto
	UPDATE [TOP_4].Usuario
	SET cant_intentos_fallidos = (cant_intentos_fallidos + 1)
	WHERE username = @userName
	
	SET @resultado = -2
	RETURN
		
END
GO