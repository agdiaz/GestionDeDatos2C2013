GO
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
 
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_limpiar_funcionalidades](
	@p_id_rol numeric(18))

AS
BEGIN
	DELETE FROM [TOP_4].Rol_Funcionalidad
	WHERE id_rol = @p_id_rol
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Funcionalidad_select_by_rol](
	@p_id_rol numeric(18))

AS
BEGIN
SELECT f.[id_funcionalidad]
      ,f.[nombre]
      ,f.[habilitado]
  FROM [TOP_4].[Funcionalidad] f
INNER JOIN [TOP_4].Rol_Funcionalidad rf on rf.id_rol = @p_id_rol
AND f.id_funcionalidad = rf.id_funcionalidad
WHERE f.habilitado = '1'
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Rol_delete](
	@p_id numeric(18))

AS
BEGIN

DELETE FROM [TOP_4].Rol
WHERE id_rol = @p_id

END
GO