GO
CREATE PROCEDURE [TOP_4].[sp_Afiliado_filter](
	@p_numero_afiliado numeric(18),
	@p_id_plan_medico numeric(18),
	@p_tipo_documento int,
	@p_nombre varchar(255),
	@p_apellido varchar(255),
	@p_documento numeric(18)
)

AS
BEGIN

SELECT a.[id_afiliado]
      ,a.[nro_principal]
      ,a.[nro_secundario]
      ,a.[id_usuario]
      ,a.[id_plan_medico]
      ,a.[tipo_documento]
      ,a.[documento]
      ,a.[nombre]
      ,a.[apellido]
      ,a.[direccion]
      ,a.[telefono]
      ,a.[mail]
      ,a.[fecha_nacimiento]
      ,a.[sexo]
      ,a.[estado_civil]
      ,a.[cantidad_familiares]
      ,a.[fecha_baja]
      ,a.[habilitado]
  FROM [TOP_4].[Afiliado] a
  WHERE ((@p_numero_afiliado IS NULL) OR (@p_numero_afiliado = a.nro_principal))
  AND ((@p_id_plan_medico IS NULL) OR (@p_id_plan_medico = a.id_plan_medico ))
  AND ((@p_tipo_documento IS NULL) OR (@p_tipo_documento = a.tipo_documento))
  AND ((@p_documento IS NULL) OR (@p_documento = a.documento))
  AND ((@p_nombre IS NULL) OR (@p_nombre like '%'+ a.nombre +'%'))
  AND ((@p_apellido IS NULL) OR (@p_apellido like '%'+ a.apellido +'%'))

END
GO
