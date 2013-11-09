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
ALTER PROCEDURE [TOP_4].[sp_Afiliado_insert](
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
	DECLARE @v_nro_principal numeric(18)
	DECLARE @v_nro_secundario numeric(18)
	
	IF (@p_nro_principal IS NOT NULL AND @p_nro_principal > 0)
		BEGIN
			SET @v_nro_principal = @p_nro_principal
			SELECT @v_nro_secundario = MAX(nro_secundario)+1 
				FROM [TOP_4].Afiliado 
				WHERE nro_principal = @p_nro_principal
		END
	ELSE	
		BEGIN
			SELECT @v_nro_principal = MAX(nro_principal)+100 FROM [TOP_4].Afiliado
			SET @v_nro_secundario = 1
		END
	
	SET @p_password = CONVERT(varbinary(32),'0x1AEAEBA4BDBF8907638434B60504B1037C01905BEC294FB2CD5348724F2FA64F', 1)
	
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
           @v_nro_principal
           ,@v_nro_secundario
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
		
		DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );

	END CATCH

END

-----------------------------------------------------------
GO
CREATE PROCEDURE [TOP_4].[sp_Afiliado_select]
(@p_id numeric(18))
AS
BEGIN
SELECT [id_afiliado]
      ,[nro_principal]
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
      ,[habilitado]
  FROM [GD2C2013].[TOP_4].[Afiliado]
  WHERE habilitado = 1
  AND id_afiliado = @p_id
END
GO

CREATE PROCEDURE [TOP_4].[sp_Afiliado_update]
(	 @p_id numeric(18) output
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
	BEGIN TRAN
	
	BEGIN TRY
		DECLARE @v_plan_anterior numeric(18) = (SELECT a.id_plan_medico FROM [TOP_4].Afiliado a WHERE a.id_afiliado = @p_id)
		
		--IF (@v_plan_anterior <> @p_id_plan_medico)
			--INSERT INTO [TOP_4].Afiliado_Plan
			--VALUES (@p_id, @v_plan_anterior)
				
		UPDATE [TOP_4].Afiliado
		SET id_plan_medico = @p_id_plan_medico,
			nombre = @p_nombre,
			apellido = @p_apellido,
			direccion = @p_direccion,
			telefono = @p_telefono,
			mail = @p_mail,
			fecha_nacimiento = @p_fecha_nacimiento,
			sexo = @p_sexo,
			estado_civil = @p_estado_civil
		WHERE id_afiliado = @p_id
		AND habilitado = '1'
		COMMIT TRAN
	END TRY
	BEGIN CATCH
	
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );

	END CATCH
END