GO
CREATE PROCEDURE [TOP_4].[sp_Rol_select_all]
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[habilitado]
	FROM [GD2C2013].[TOP_4].[Rol]
	WHERE [habilitado] = 1
END
GO
