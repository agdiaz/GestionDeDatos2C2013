GO
CREATE PROCEDURE [TOP_4].[sp_Plan_medico_select_all]

AS
BEGIN
SELECT [id_plan_medico]
      ,[descripcion]
      ,[precio_bono_farmacia]
      ,[precio_bono_consulta]
      ,[habilitado]
  FROM [TOP_4].[Plan_medico]
  WHERE habilitado = '1'
END
GO

