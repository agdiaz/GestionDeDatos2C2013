GO
CREATE PROCEDURE [TOP_4].[sp_Especialidad_select_all]

AS
BEGIN
SELECT [id_especialidad]
      ,[id_tipo_especialidad]
      ,[nombre]
  FROM [TOP_4].[Especialidad]
  END
GO

