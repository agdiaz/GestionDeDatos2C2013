GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_select_all]
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activo]
      ,[habilitado]
	FROM [GD2C2013].[TOP_4].[Rol]
	WHERE [habilitado] = '1'
END
GO


GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_insert](
	@p_id numeric(18) output,
	@p_nombre varchar(255),
	@p_activo bit)
	 
AS
BEGIN
INSERT INTO [TOP_4].[Rol]
           ([nombre]
           ,[habilitado]
           ,[activo])
     VALUES
           (@p_nombre
           ,'1'
           ,@p_activo)
SET @p_id = SCOPE_IDENTITY()
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].sp_asociar_rol_funcionalidad(
	@p_id_rol numeric(18),
	@p_id_funcionalidad numeric(18))
	
AS
BEGIN
INSERT INTO [TOP_4].[Rol_Funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES
           (@p_id_rol,
            @p_id_funcionalidad)
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_update](
	@p_nombre varchar(255),
	@p_activo bit,
	@p_id numeric(18)
)
AS
BEGIN

UPDATE [TOP_4].[Rol]
   SET [nombre] = @p_nombre,
   [activo] = @p_activo
 WHERE id_rol = @p_id
 AND habilitado = '1'

IF @p_activo = '0' 
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
			-- Le quito ese rol a todos los usuarios
			DELETE FROM [TOP_4].Usuario_Rol
			WHERE id_rol = @p_id
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END -- if

END -- sp
GO

---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_limpiar_funcionalidades](
	@p_id_rol numeric(18))

AS
BEGIN
	DELETE FROM [TOP_4].Rol_Funcionalidad
	WHERE id_rol = @p_id_rol
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Funcionalidad_select_by_rol](
	@p_id_rol numeric(18))

AS
BEGIN
SELECT f.[id_funcionalidad]
      ,f.[nombre]
      ,f.[habilitado]
      ,f.[descripcion]
  FROM [TOP_4].[Funcionalidad] f
INNER JOIN [TOP_4].Rol_Funcionalidad rf on rf.id_rol = @p_id_rol
AND f.id_funcionalidad = rf.id_funcionalidad
WHERE f.habilitado = '1'
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_delete](
	@p_id numeric(18))

AS
BEGIN

BEGIN TRY
	BEGIN TRAN
	
	-- Baja lógica del rol:
	UPDATE [TOP_4].Rol
	SET habilitado = '0'
	WHERE id_rol = @p_id

	-- Le quito ese rol a todos los usuarios
	DELETE FROM [TOP_4].Usuario_Rol
	WHERE id_rol = @p_id
	
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_filter](
	@p_nombre varchar(255),
	@p_id_funcionalidad numeric(18))

AS
BEGIN

SELECT r.[id_rol]
      ,r.[nombre]
      ,r.[activo]
      ,r.[habilitado]
  FROM [TOP_4].[Rol] r
  LEFT JOIN [TOP_4].Rol_Funcionalidad rf on rf.id_rol = r.id_rol
  LEFT JOIN [TOP_4].Funcionalidad f on f.id_funcionalidad = rf.id_funcionalidad
  WHERE ((@p_nombre IS NULL)OR (r.nombre like '%'+@p_nombre+'%'))
AND ((@p_id_funcionalidad IS NULL) OR (f.id_funcionalidad = @p_id_funcionalidad))
AND f.habilitado = '1'
AND r.habilitado = '1'
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_asociar_Usuario](
	@p_id_rol numeric(18),
	@p_id_usuario numeric(18)
)
AS
BEGIN
	INSERT INTO [TOP_4].Usuario_Rol (id_usuario, id_rol)
	VALUES (@p_id_usuario, @p_id_rol)
END
GO

---------------------------------------------------------------