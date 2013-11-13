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

GO
CREATE PROCEDURE [TOP_4].[sp_Especialidad_filter](
	@p_nombre varchar(255) = NULL,
	@p_id_tipo_especialidad numeric(18) = NULL
)

AS
BEGIN
SELECT 
	e.[id_especialidad], 
	e.id_tipo_especialidad, 
	e.nombre,
	ISNULL(te.id_tipo_especialidad, 0)
  FROM [TOP_4].[Especialidad] e
  LEFT JOIN [TOP_4].[Tipo_especialidad] te on e.id_tipo_especialidad = te.id_tipo_especialidad
  WHERE ((@p_nombre IS NULL) OR (e.nombre like '%' + @p_nombre + '%'))
  AND ((@p_id_tipo_especialidad IS NULL) OR (te.id_tipo_especialidad = @p_id_tipo_especialidad ))
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Especialidad_select_by_profesional]
(@p_id numeric(18))
AS
BEGIN
	SELECT e.id_especialidad, e.nombre, te.id_tipo_especialidad
	FROM [TOP_4].Especialidad e
	INNER JOIN [TOP_4].tipo_especialidad te
		ON e.id_tipo_especialidad = te.id_tipo_especialidad 
	INNER JOIN [TOP_4].[Profesional_especialidad] pe
		ON e.id_especialidad = pe.id_especialidad
		AND pe.id_profesional = @p_id
	INNER JOIN [TOP_4].Profesional p
		ON pe.id_profesional = p.id_profesional
		AND p.habilitado = '1'
	--WHERE e.habilitado = '1' 
END
GO