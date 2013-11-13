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

GO

CREATE PROCEDURE [TOP_4].[sp_Plan_medico_filter](
	@p_descripcion varchar(255) = NULL,
	@p_precio_farmacia numeric(18)  = NULL,
	@p_precio_consulta numeric(18) = NULL
)

AS
BEGIN
SELECT [id_plan_medico]
      ,[descripcion]
      ,[precio_bono_farmacia]
      ,[precio_bono_consulta]
      ,[habilitado]
  FROM [TOP_4].[Plan_medico]
  WHERE ((@p_descripcion IS NULL) OR (descripcion like '%' + @p_descripcion + '%'))
  AND ((@p_precio_consulta IS NULL) OR (@p_precio_consulta = precio_bono_consulta ))
  AND ((@p_precio_farmacia IS NULL) OR ((@p_precio_farmacia = precio_bono_farmacia)))
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Plan_medico_select]
(@p_id numeric(18))
AS
BEGIN
	SELECT p.descripcion, p.habilitado, p.id_plan_medico, p.precio_bono_consulta, p.precio_bono_farmacia
	FROM [TOP_4].Plan_medico p
	WHERE p.id_plan_medico = @p_id
	AND p.habilitado = '1'
END
GO