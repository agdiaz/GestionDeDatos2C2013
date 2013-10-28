GO
CREATE PROCEDURE [TOP_4].[sp_Tipo_Especialidad_select_all]

AS
BEGIN
SELECT [id_tipo_especialidad]
      ,[nombre]
  FROM [TOP_4].[Tipo_especialidad]
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Tipo_especialidad_filter](
	@p_nombre varchar(255),
	@p_id_tipo_especialidad numeric(18)
)

AS
BEGIN
SELECT te.[id_tipo_especialidad]
      ,te.[nombre]
  FROM [TOP_4].[Tipo_especialidad] te
  WHERE ((@p_nombre IS NULL) OR (@p_nombre like '%' + te.nombre))
  AND ((@p_id_tipo_especialidad IS NULL) OR (@p_id_tipo_especialidad = id_tipo_especialidad))
END
GO