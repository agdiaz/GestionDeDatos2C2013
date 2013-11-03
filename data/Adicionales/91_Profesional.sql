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
	@p_nombre varchar(255) = NULL,
	@p_apellido varchar(255)= NULL,
	@p_tipo_documento numeric(18)= NULL,
	@p_documento numeric(18)= NULL,
	@p_direccion varchar(255)= NULL,
	@p_telefono numeric(18) = NULL,
	@p_mail varchar(255) = NULL,
	@p_fecha_nacimiento datetime = NULL,
	@p_sexo int = NULL,
	@p_matricula numeric(18)= NULL,
	@p_id_especialidad numeric(18)= NULL
)
AS
BEGIN

SELECT DISTINCT p.[id_profesional]
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
  WHERE 
	  ((@p_nombre IS NULL)			OR (p.nombre like '%' + @p_nombre + '%'))
  AND ((@p_apellido IS NULL)		OR (p.apellido like '%' + @p_apellido + '%'))
  AND ((@p_tipo_documento IS NULL)	OR (p.tipo_documento = @p_tipo_documento))
  AND ((@p_documento IS NULL)		OR (p.documento = @p_documento))
  AND ((@p_direccion IS NULL)		OR (p.direccion like '%' + @p_direccion + '%'))
  AND ((@p_telefono IS NULL)		OR (p.telefono = @p_telefono))
  AND ((@p_mail IS NULL)			OR (p.mail like '%' + @p_mail + '%'))
  AND ((@p_fecha_nacimiento IS NULL) OR (CONVERT(VARCHAR(8), p.fecha_nacimiento, 112) = CONVERT(VARCHAR(8), @p_fecha_nacimiento, 112) ))
  AND ((@p_sexo IS NULL)			OR (p.sexo = @p_sexo))
  AND ((@p_matricula IS NULL)		OR (p.matricula = @p_matricula))
  AND ((@p_id_especialidad IS NULL) OR (@p_id_especialidad = e.id_especialidad))
  AND habilitado = '1'
END
GO
-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Profesional_insert](
	@p_id numeric(18) output,
	@p_nombre varchar(255),
	@p_apellido varchar(255),
	@p_tipo_documento int,
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
	DECLARE @p_id_rol numeric(18) = (SELECT TOP 1 id_rol FROM [TOP_4].[Rol] WHERE nombre = 'Profesional')
	
	SELECT @p_password = P.[Password] from [TOP_4].[Password] P WHERE P.Id = 'PROFESIONAL'
	
	EXECUTE [TOP_4].[sp_Usuario_Insert] @p_username, @p_password, @p_id_usuario OUTPUT
	EXECUTE [TOP_4].[sp_Rol_asociar_Usuario] @p_id_rol, @p_id_usuario
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
GO

CREATE PROCEDURE [TOP_4].[sp_Profesional_asociar_especialidad]
(	@p_id_profesional numeric(18), @p_id_especialidad numeric(18)
)
AS
BEGIN

	INSERT INTO [TOP_4].[Profesional_Especialidad]
	(id_especialidad, id_profesional)
	VALUES (@p_id_especialidad, @p_id_profesional)

END
GO

GO

CREATE PROCEDURE [TOP_4].[sp_Profesional_delete]
(
	@p_id numeric(18)
)
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		UPDATE [TOP_4].[Profesional]
		SET habilitado = 0
		WHERE id_profesional = @p_id

		-- Cancelar los turnos!
		UPDATE [TOP_4].[Turno] 
		SET habilitado = '0'
		WHERE id_profesional = @p_id
		
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
GO

GO

CREATE PROCEDURE [TOP_4].[sp_Profesional_limpiar_especialidades]
(@p_id_profesional numeric(18))
AS
BEGIN
	DELETE FROM [TOP_4].Profesional_Especialidad
	WHERE id_profesional = @p_id_profesional
END
GO

GO
-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Profesional_update](
	@p_id numeric(18),
	@p_nombre varchar(255),
	@p_apellido varchar(255),
	@p_tipo_documento int,
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
	--DECLARE @p_id_usuario numeric(18) = (SELECT TOP 1 id_usuario FROM [TOP_4].[Profesional] WHERE id_profesional = @p_id)
	--DECLARE @p_username varchar(255) = CONVERT(varchar, @p_documento)
	
	--EXECUTE [TOP_4].[sp_Usuario_Update] @p_id_usuario, @p_username
	
	-- Creo el registro del profesional
	
	UPDATE [TOP_4].[Profesional]
	SET			[nombre] = @p_nombre
			   ,[apellido] = @p_apellido
			   ,[tipo_documento] = @p_tipo_documento
			   ,[documento] = @p_documento
			   ,[direccion] = @p_direccion
			   ,[telefono]= @p_telefono
			   ,[mail] = @p_mail
			   ,[fecha_nacimiento] = @p_fecha_nacimiento
			   ,[sexo] = @p_sexo
			   ,[matricula] = @p_matricula
	WHERE id_profesional = @p_id

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
GO