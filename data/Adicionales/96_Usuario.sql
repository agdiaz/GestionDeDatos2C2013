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



