GO
CREATE PROCEDURE [TOP_4].[sp_Rol_select_all]
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activo]
      ,[habilitado]
	FROM [GD2C2013].[TOP_4].[Rol]
	WHERE [habilitado] = 1
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
           ,1
           ,@p_activo)
SET @p_id = SCOPE_IDENTITY()
END
GO
