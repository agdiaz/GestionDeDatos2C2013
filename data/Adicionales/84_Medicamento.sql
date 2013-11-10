CREATE PROCEDURE [TOP_4].[sp_Medicamento_filter]
(@p_nombre varchar(255))
AS
BEGIN
	SELECT [id_medicamento]
      ,[nombre]
      ,[habilitado]
	FROM [TOP_4].[Medicamento]
	WHERE ((@p_nombre IS NULL) OR (nombre like '%' + @p_nombre + '%'))
	AND habilitado = '1'

END
GO