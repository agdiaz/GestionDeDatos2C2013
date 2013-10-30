-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_select_by_name](
	@p_nombre varchar(255))
AS
BEGIN
SELECT [id_usuario]
      ,[username]
      ,[password]
      ,[cant_intentos_fallidos]
      ,[habilitado]
  FROM [TOP_4].[Usuario]
  WHERE username = @p_nombre
  AND habilitado = '1'
 END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_select_all]

AS
BEGIN
SELECT [id_usuario]
      ,[username]
      ,[password]
      ,[cant_intentos_fallidos]
      ,[habilitado]
  FROM [GD2C2013].[TOP_4].[Usuario]
  WHERE habilitado = '1'
END
GO

GO
CREATE PROCEDURE [TOP_4].sp_usuario_select_roles 
	@p_usuario_nombre varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT R.[id_rol]
      ,R.[nombre]
      ,R.[habilitado]
      ,R.[activo]
   FROM [TOP_4].[Rol] R
   INNER JOIN [TOP_4].[Usuario_Rol] UR
	ON R.id_rol = UR.id_rol
   INNER JOIN [TOP_4].[Usuario] U
	ON (UR.id_usuario = U.id_usuario AND U.username = @p_usuario_nombre)
   WHERE R.[habilitado] = '1'
   AND U.[habilitado] = '1'

END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_filter](
	@p_username varchar(255),
	@p_id_rol numeric(18))
AS
BEGIN

SELECT u.[id_usuario]
      ,u.[username]
      ,u.[password]
      ,u.[cant_intentos_fallidos]
      ,u.[habilitado]
  FROM [TOP_4].[Usuario] u
  LEFT JOIN [TOP_4].[Usuario_Rol] ur on ur.id_usuario = u.id_usuario
  LEFT JOIN [TOP_4].[Rol] r on r.id_rol = ur.id_rol
  WHERE ((@p_username IS NULL) OR (u.username like '%'+@p_username+'%'))
  AND ((@p_id_rol IS NULL) OR (r.id_rol = @p_id_rol))
  AND u.habilitado = '1'
  AND r.habilitado = '1'
END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_Insert](
	@p_username varchar(255),
	@p_password varbinary(32),
	@p_id numeric(18) output
)
AS
BEGIN
INSERT INTO [GD2C2013].[TOP_4].[Usuario]
           ([username]
           ,[password]
           ,[cant_intentos_fallidos]
           ,[habilitado])
     VALUES
           (@p_username
           ,@p_password
           ,'0'
           ,'1')

SET @p_id = SCOPE_IDENTITY()

END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[realizar_identificacion](
	@userName nvarchar(50),
	@passwordHash varbinary(32),
	@resultado int OUTPUT
	)
AS
BEGIN
	--  0 Exito
	--  1 Bloqueado
	--  2 Usuario invalido o contrasena falsa
	SET NOCOUNT ON;
	
	DECLARE @hashReal varbinary(32)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.[password], @fallidos=us.cant_intentos_fallidos
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
-----------------------------------------------------