GO
CREATE PROCEDURE [TOP_4].[sp_Funcionalidad_select_all]
AS
BEGIN
	SELECT [id_funcionalidad]
      ,[nombre]
      ,[habilitado]
      ,[descripcion]
	FROM [GD2C2013].[TOP_4].[Funcionalidad]
	WHERE [habilitado] = 1
END
GO

