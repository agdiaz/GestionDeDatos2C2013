GO
CREATE PROCEDURE [TOP_4].[sp_Afiliado_filter](
	@p_nro_principal numeric(18)=NULL,
	@p_nro_secundario numeric(18)=NULL,
	@p_id_plan_medico numeric(18)=NULL,
	@p_tipo_documento int=NULL,
	@p_nombre varchar(255)=NULL,
	@p_apellido varchar(255)=NULL,
	@p_documento numeric(18)=NULL,
	@p_direccion varchar(255)=NULL,
	@p_telefono numeric(18)=NULL,
	@p_mail varchar(255)=NULL,
	@p_fecha_nac datetime=NULL,
	@p_sexo int=NULL,
	@p_estado_civil int=NULL
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
      ,a.[fecha_baja]
      ,a.[habilitado]
  FROM [Afiliado] a
  WHERE ((@p_nro_principal IS NULL) OR (a.nro_principal = @p_nro_principal))
  AND ((@p_nro_secundario IS NULL) OR (a.nro_secundario = @p_nro_secundario))
  AND ((@p_id_plan_medico IS NULL) OR (a.id_plan_medico = @p_id_plan_medico ))
  AND ((@p_tipo_documento IS NULL) OR (a.tipo_documento = @p_tipo_documento ))
  AND ((@p_documento IS NULL) OR (a.documento = @p_documento))
  AND ((@p_nombre IS NULL) OR (a.nombre like '%'+ @p_nombre +'%'))
  AND ((@p_apellido IS NULL) OR (a.apellido like '%'+ @p_apellido +'%'))
  AND ((@p_direccion IS NULL) OR (a.direccion like '%'+ @p_direccion +'%' ))
  AND ((@p_telefono IS NULL) OR (a.telefono = @p_telefono))
  AND ((@p_fecha_nac IS NULL) OR (a.fecha_nacimiento = @p_fecha_nac))
  AND ((@p_sexo IS NULL) OR (a.sexo = @p_sexo))
  AND ((@p_estado_civil IS NULL) OR (a.estado_civil = @p_estado_civil))
  AND ((@p_mail IS NULL) OR (a.mail like '%'+@p_mail+'%'))

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
           ,null
           ,'1')
	
	SET @p_id = SCOPE_IDENTITY()
	
	COMMIT TRAN
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

END

------------------------------------------------------------

