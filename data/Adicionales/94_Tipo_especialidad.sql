GO
CREATE PROCEDURE [TOP_4].[sp_Tipo_Especialidad_select_all]

AS
BEGIN
SELECT [id_tipo_especialidad]
      ,[nombre]
  FROM [TOP_4].[Tipo_especialidad]
END
GO