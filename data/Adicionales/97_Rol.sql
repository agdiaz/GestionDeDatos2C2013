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
	@p_id_rol numeric(18)
)
AS
BEGIN

UPDATE [TOP_4].[Rol]
   SET [nombre] = @p_nombre,
   [activo] = @p_activo
 WHERE id_rol = @p_id_rol
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