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
  AND ((@p_nombre IS NULL) OR (a.nombre like '%'+ @p_nombre +'%'))
  AND ((@p_apellido IS NULL) OR (a.apellido like '%'+ @p_apellido +'%'))

END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Afiliado_insert](
	 @p_id numeric(18) output
	,@p_nro_principal numeric(18)
    ,@p_nro_secundario numeric(18,0)
	,@p_id_plan_medico numeric(18,0)
	,@p_tipo_documento int
	,@p_documento numeric(18,0)
	,@p_nombre varchar(255)
	,@p_apellido varchar(255)
	,@p_direccion varchar(255)
	,@p_telefono numeric(18)
	,@p_mail varchar(255)
	,@p_fecha_nacimiento datetime
	,@p_sexo int
	,@p_estado_civil int
)
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
	
	-- Creo el usuario del afiliado:
	DECLARE @p_id_usuario numeric(18)
	DECLARE @p_username varchar(255) = CONVERT(varchar, @p_documento)
	DECLARE @p_password varbinary(32)
	
	SELECT @p_password = P.[Password] from [TOP_4].[Password] P WHERE P.Id = 'AFILIADO'
	
	EXECUTE [TOP_4].[sp_Usuario_Insert] @p_username, @p_password, @p_id_usuario OUTPUT
	
	-- Creo el registro del afiliado
	
	INSERT INTO [TOP_4].[Afiliado]
           ([nro_principal]
           ,[nro_secundario]
           ,[id_usuario]
           ,[id_plan_medico]
           ,[tipo_documento]
           ,[documento]
           ,[nombre]
           ,[apellido]
           ,[direccion]
           ,[telefono]
           ,[mail]
           ,[fecha_nacimiento]
           ,[sexo]
           ,[estado_civil]
           ,[cantidad_familiares]
           ,[fecha_baja]
           ,[habilitado])
     VALUES
           (
           @p_nro_principal
           ,@p_nro_secundario
           ,@p_id_usuario
           ,@p_id_plan_medico
           ,@p_tipo_documento
           ,@p_documento
           ,@p_nombre
           ,@p_apellido
           ,@p_direccion
           ,@p_telefono
           ,@p_mail
           ,@p_fecha_nacimiento
           ,@p_sexo
           ,@p_estado_civil
           ,0
           ,null
           ,'1')
	
	SET @p_id = SCOPE_IDENTITY()
	
	COMMIT TRAN
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

END
