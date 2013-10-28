GO
CREATE PROCEDURE [TOP_4].[sp_Profesional_select_all]

AS
BEGIN

SELECT [id_profesional]
      ,[id_usuario]
      ,[nombre]
      ,[apellido]
      ,[tipo_documento]
      ,[documento]
      ,[direccion]
      ,[telefono]
      ,[mail]
      ,[fecha_nacimiento]
      ,[sexo]
      ,[matricula]
      ,[habilitado]
  FROM [TOP_4].[Profesional]
  WHERE habilitado = '1'

END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_Profesional_filter](
	@p_nombre varchar(255),
	@p_apellido varchar(255),
	@p_documento numeric(18),
	@p_matricula numeric(18),
	@p_id_especialidad numeric(18)
)

AS
BEGIN

SELECT p.[id_profesional]
      ,p.[id_usuario]
      ,p.[nombre]
      ,p.[apellido]
      ,p.[tipo_documento]
      ,p.[documento]
      ,p.[direccion]
      ,p.[telefono]
      ,p.[mail]
      ,p.[fecha_nacimiento]
      ,p.[sexo]
      ,p.[matricula]
      ,p.[habilitado]
  FROM [TOP_4].[Profesional] p
  LEFT JOIN [TOP_4].Profesional_Especialidad pe on p.id_profesional = pe.id_profesional
  LEFT JOIN [TOP_4].Especialidad e on pe.id_especialidad = e.id_especialidad 
  WHERE ((@p_nombre IS NULL) OR (p.nombre like '%' + @p_nombre + '%'))
  AND ((@p_apellido IS NULL) OR (p.apellido like '%' + @p_apellido + '%'))
  AND ((@p_documento IS NULL) OR (@p_documento = p.documento))
  AND ((@p_matricula IS NULL) OR (@p_matricula = p.matricula))
  AND ((@p_id_especialidad IS NULL) OR (@p_id_especialidad = e.id_especialidad))
END

GO

