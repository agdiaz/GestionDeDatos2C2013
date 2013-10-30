GO
-----------------------------------------------------
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

-----------------------------------------------------
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
-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Profesional_insert](
	@p_id numeric(18) output,
	@p_nombre varchar(255),
	@p_apellido varchar(255),
	@p_tipo_documento varchar(255),
	@p_documento numeric(18),
	@p_direccion varchar(255),
	@p_telefono numeric(18),
	@p_mail varchar(255),
	@p_fecha_nacimiento datetime,
	@p_sexo int,
	@p_matricula numeric(18,0)
)
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
	
	-- Creo el usuario del profesional:
	DECLARE @p_id_usuario numeric(18)
	DECLARE @p_username varchar(255) = CONVERT(varchar,@p_documento)
	DECLARE @p_password varbinary(32)
	
	SELECT @p_password = P.[Password] from [TOP_4].[Password] P WHERE P.Id = 'PROFESIONAL'
	
	EXECUTE [TOP_4].[sp_Usuario_Insert] @p_username, @p_password, @p_id_usuario OUTPUT
	
	-- Creo el registro del profesional
	INSERT INTO [GD2C2013].[TOP_4].[Profesional]
			   ([id_usuario]
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
			   ,[habilitado])
		 VALUES
			   (@p_id_usuario
			   ,@p_nombre
			   ,@p_apellido
			   ,@p_tipo_documento
			   ,@p_documento
			   ,@p_direccion
			   ,@p_telefono
			   ,@p_mail
			   ,@p_fecha_nacimiento
			   ,@p_sexo
			   ,@p_matricula
			   ,'1')
	
	SET @p_id = SCOPE_IDENTITY()

	COMMIT TRAN
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

END

