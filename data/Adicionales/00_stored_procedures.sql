GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_select_all]
AS
BEGIN
	SELECT [id_rol]
      ,[nombre]
      ,[activo]
      ,[habilitado]
	FROM [GD2C2013].[TOP_4].[Rol]
	WHERE [habilitado] = '1'
END
GO


GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_insert](
	@p_id numeric(18) output,
	@p_nombre varchar(255),
	@p_activo bit)
	 
AS
BEGIN
INSERT INTO [TOP_4].[Rol]
           ([nombre]
           ,[habilitado]
           ,[activo])
     VALUES
           (@p_nombre
           ,'1'
           ,@p_activo)
SET @p_id = SCOPE_IDENTITY()
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].sp_asociar_rol_funcionalidad(
	@p_id_rol numeric(18),
	@p_id_funcionalidad numeric(18))
	
AS
BEGIN
INSERT INTO [TOP_4].[Rol_Funcionalidad]
           ([id_rol]
           ,[id_funcionalidad])
     VALUES
           (@p_id_rol,
            @p_id_funcionalidad)
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_update](
	@p_nombre varchar(255),
	@p_activo bit,
	@p_id numeric(18)
)
AS
BEGIN

UPDATE [TOP_4].[Rol]
   SET [nombre] = @p_nombre,
   [activo] = @p_activo
 WHERE id_rol = @p_id
 AND habilitado = '1'

IF @p_activo = '0' 
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
			-- Le quito ese rol a todos los usuarios
			DELETE FROM [TOP_4].Usuario_Rol
			WHERE id_rol = @p_id
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END -- if

END -- sp
GO

---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_limpiar_funcionalidades](
	@p_id_rol numeric(18))

AS
BEGIN
	DELETE FROM [TOP_4].Rol_Funcionalidad
	WHERE id_rol = @p_id_rol
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Funcionalidad_select_by_rol](
	@p_id_rol numeric(18))

AS
BEGIN
SELECT f.[id_funcionalidad]
      ,f.[nombre]
      ,f.[habilitado]
      ,f.[descripcion]
  FROM [TOP_4].[Funcionalidad] f
INNER JOIN [TOP_4].Rol_Funcionalidad rf on rf.id_rol = @p_id_rol
AND f.id_funcionalidad = rf.id_funcionalidad
WHERE f.habilitado = '1'
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_delete](
	@p_id numeric(18))

AS
BEGIN

BEGIN TRY
	BEGIN TRAN
	
	-- Baja lógica del rol:
	UPDATE [TOP_4].Rol
	SET habilitado = '0'
	WHERE id_rol = @p_id

	-- Le quito ese rol a todos los usuarios
	DELETE FROM [TOP_4].Usuario_Rol
	WHERE id_rol = @p_id
	
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_filter](
	@p_nombre varchar(255),
	@p_id_funcionalidad numeric(18))

AS
BEGIN

SELECT r.[id_rol]
      ,r.[nombre]
      ,r.[activo]
      ,r.[habilitado]
  FROM [TOP_4].[Rol] r
  LEFT JOIN [TOP_4].Rol_Funcionalidad rf on rf.id_rol = r.id_rol
  LEFT JOIN [TOP_4].Funcionalidad f on f.id_funcionalidad = rf.id_funcionalidad
  WHERE ((@p_nombre IS NULL)OR (r.nombre like '%'+@p_nombre+'%'))
AND ((@p_id_funcionalidad IS NULL) OR (f.id_funcionalidad = @p_id_funcionalidad))
AND f.habilitado = '1'
AND r.habilitado = '1'
END
GO

GO
---------------------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Rol_asociar_Usuario](
	@p_id_rol numeric(18),
	@p_id_usuario numeric(18)
)
AS
BEGIN
	INSERT INTO [TOP_4].Usuario_Rol (id_usuario, id_rol)
	VALUES (@p_id_usuario, @p_id_rol)
END
GO

---------------------------------------------------------------
GO
CREATE PROCEDURE [TOP_4].[sp_Funcionalidad_select_all]
AS
BEGIN
	SELECT [id_funcionalidad]
      ,[nombre]
      ,[habilitado]
      ,[descripcion]
	FROM [GD2C2013].[TOP_4].[Funcionalidad]
	WHERE [habilitado] = 1
END
GO


-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_select_by_name](
	@p_nombre varchar(255))
AS
BEGIN
SELECT [id_usuario]
      ,[username]
      ,[password]
      ,[cant_intentos_fallidos]
      ,[habilitado]
  FROM [TOP_4].[Usuario]
  WHERE username = @p_nombre
  AND habilitado = '1'
 END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_select_all]

AS
BEGIN
SELECT [id_usuario]
      ,[username]
      ,[password]
      ,[cant_intentos_fallidos]
      ,[habilitado]
  FROM [GD2C2013].[TOP_4].[Usuario]
  WHERE habilitado = '1'
END
GO

GO
CREATE PROCEDURE [TOP_4].sp_usuario_select_roles 
	@p_usuario_nombre varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT R.[id_rol]
      ,R.[nombre]
      ,R.[habilitado]
      ,R.[activo]
   FROM [TOP_4].[Rol] R
   INNER JOIN [TOP_4].[Usuario_Rol] UR
	ON R.id_rol = UR.id_rol
   INNER JOIN [TOP_4].[Usuario] U
	ON (UR.id_usuario = U.id_usuario AND U.username = @p_usuario_nombre)
   WHERE R.[habilitado] = '1'
   AND U.[habilitado] = '1'

END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_filter](
	@p_username varchar(255),
	@p_id_rol numeric(18))
AS
BEGIN

SELECT u.[id_usuario]
      ,u.[username]
      ,u.[password]
      ,u.[cant_intentos_fallidos]
      ,u.[habilitado]
  FROM [TOP_4].[Usuario] u
  LEFT JOIN [TOP_4].[Usuario_Rol] ur on ur.id_usuario = u.id_usuario
  LEFT JOIN [TOP_4].[Rol] r on r.id_rol = ur.id_rol
  WHERE ((@p_username IS NULL) OR (u.username like '%'+@p_username+'%'))
  AND ((@p_id_rol IS NULL) OR (r.id_rol = @p_id_rol))
  AND u.habilitado = '1'
  AND r.habilitado = '1'
END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Usuario_Insert](
	@p_username varchar(255),
	@p_password varbinary(32),
	@p_id numeric(18) output
)
AS
BEGIN
INSERT INTO [GD2C2013].[TOP_4].[Usuario]
           ([username]
           ,[password]
           ,[cant_intentos_fallidos]
           ,[habilitado])
     VALUES
           (@p_username
           ,@p_password
           ,'0'
           ,'1')

SET @p_id = SCOPE_IDENTITY()

END
GO

-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[realizar_identificacion](
	@userName nvarchar(50),
	@passwordHash varbinary(32),
	@resultado int OUTPUT
	)
AS
BEGIN
	--  0 Exito
	--  1 Bloqueado
	--  2 Usuario invalido o contrasena falsa
	SET NOCOUNT ON;
	
	DECLARE @hashReal varbinary(32)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.[password], @fallidos=us.cant_intentos_fallidos
	FROM [TOP_4].Usuario us
	WHERE us.username = @userName
	
	IF @@ROWCOUNT = 0
	BEGIN
		--Usuario invalido
		SET @resultado = -2
		RETURN
	END
	
	IF @fallidos >= 3
	BEGIN
		--Usuario bloqueado
		SET @resultado = -1
		RETURN
	END
	
	IF @hashReal = @passwordHash
	BEGIN
		--Exito
		UPDATE [TOP_4].Usuario
		SET cant_intentos_fallidos = 0
		WHERE username = @userName
		
		SET @resultado = 0
		
		RETURN
	END
	
	--Password incorrecto
	UPDATE [TOP_4].Usuario
	SET cant_intentos_fallidos = (cant_intentos_fallidos + 1)
	WHERE username = @userName
	
	SET @resultado = -2
	RETURN
		
END
GO
-----------------------------------------------------

CREATE PROCEDURE [TOP_4].[sp_Usuario_update](
	@p_id numeric(18),
	@p_username varchar(255)
)
AS
BEGIN

UPDATE [TOP_4].[Usuario]
   SET [username]  = @p_username
 WHERE id_usuario = @p_id

END 

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
  WHERE ((@p_nombre IS NULL) OR (te.nombre like '%' + @p_nombre + '%'))
  AND ((@p_id_tipo_especialidad IS NULL) OR (@p_id_tipo_especialidad = id_tipo_especialidad))
END
GO
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
CREATE PROCEDURE [TOP_4].[sp_Afiliado_obtener_id_usuario]
(@p_id_usuario numeric(18))
AS
BEGIN
SELECT TOP 1[id_afiliado]
      ,[nro_principal]
      ,[nro_secundario]
      ,U.[id_usuario]
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
      ,A.[habilitado]
  FROM [TOP_4].[Afiliado] A
  INNER JOIN [TOP_4].Usuario U
  ON A.id_usuario = U.id_usuario
  WHERE A.habilitado = '1'
  AND U.habilitado = '1'
  AND U.id_usuario = @p_id_usuario
END

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
  AND habilitado = '1'
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
(	 @p_id numeric(18)
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
	,@p_fecha_hoy datetime
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
		DECLARE @v_plan_anterior numeric(18)
		SELECT @v_plan_anterior= a.id_plan_medico 
			FROM [TOP_4].Afiliado a 
			WHERE a.id_afiliado = @p_id
		
		IF (@v_plan_anterior <> @p_id_plan_medico)
		BEGIN 
			INSERT INTO [TOP_4].Plan_Historico_Afiliado (id_afiliado, id_plan_medico, fecha, habilitado)
			VALUES (@p_id, @v_plan_anterior, @p_fecha_hoy, '1')
		END	
		
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

CREATE PROCEDURE [TOP_4].[sp_Afiliado_delete]
(	@p_id numeric(18)
	,@p_fecha_baja datetime
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
		UPDATE IR
		SET IR.habilitado = '0'
		FROM [TOP_4].[Item_Receta] IR
		INNER JOIN [TOP_4].[Receta] R
			ON IR.id_receta = R.id_receta
		INNER JOIN [TOP_4].[Resultado_Turno] RT
			ON R.id_resultado_turno = RT.id_resultado_turno
		INNER JOIN [TOP_4].[Turno] T
			ON T.id_turno = RT.id_turno
			AND T.id_afiliado = @p_id
		
				
		UPDATE R
		SET R.Habilitado = '0'
		FROM [TOP_4].Receta R
		INNER JOIN [TOP_4].[Resultado_Turno] RT
			ON R.id_resultado_turno = RT.id_resultado_turno
		INNER JOIN [TOP_4].[Turno] T
			ON T.id_turno = RT.id_turno
			AND T.id_afiliado = @p_id
		
		
		UPDATE [TOP_4].[Turno]
			SET habilitado = '0'
			WHERE id_afiliado = @p_id

		UPDATE [TOP_4].[Afiliado]
			SET habilitado = '0',
			fecha_baja = @p_fecha_baja
			WHERE id_afiliado = @p_id
		

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
-----------------------------------------------------
CREATE PROCEDURE [TOP_4].[sp_Profesional_obtener_id_usuario]
(@p_id_usuario numeric(18))
AS
BEGIN
SELECT TOP 1 [id_profesional]
      ,P.[id_usuario]
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
      ,P.[habilitado]
  FROM [GD2C2013].[TOP_4].[Profesional] P
  INNER JOIN [TOP_4].Usuario U
  ON P.id_usuario = U.id_usuario
  WHERE P.habilitado = '1'
  AND U.habilitado = '1'
  AND U.id_usuario = @p_id_usuario
END
GO
-- -------------------------------------------
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
  AND p.habilitado = '1'
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
	
	SET @p_password = CONVERT(varbinary(32),'0x24AFE47D0BD302AE42643C5848D99B683264026CD12CC998E05E100BBF2DC30D', 1)
		
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
GO
CREATE PROCEDURE [TOP_4].[sp_topcancelacionesprofesionales]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 'ads' as especialidad,1 as cantidad_cancelaciones
	SELECT TOP 5 es.nombre as especialidad, COUNT(*) cantidad_cancelaciones
	FROM TOP_4.Especialidad es
	INNER JOIN TOP_4.Profesional_Especialidad pf
		ON pf.id_especialidad = es.id_especialidad
	INNER JOIN TOP_4.Profesional pro
		ON pro.id_profesional = pf.id_profesional
	INNER JOIN TOP_4.Turno tur
		ON tur.id_profesional = pro.id_profesional
	INNER JOIN TOP_4.Cancelacion can
		ON can.id_turno = tur.id_turno
	GROUP BY es.id_especialidad, es.nombre
	ORDER BY cantidad_cancelaciones DESC
END
GO
GO
CREATE PROCEDURE [TOP_4].[sp_topbonosfarmaciavencidosporafiliado]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 5 as id_afiliado,100 as bonos_vencidos
	SELECT TOP 5 af.nombre as nombre, af.apellido as apellido, COUNT(*) as bonos_vencidos
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Compra co
		ON co.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Bono_Farmacia bf
		ON bf.id_compra = co.id_compra
	WHERE bf.fecha_vencimiento BETWEEN @p_desde AND @p_fin
	AND bf.id_bono_farmacia NOT IN
	(
		SELECT bf.id_bono_farmacia
		FROM TOP_4.Turno tu2
		INNER JOIN TOP_4.Resultado_Turno rt2
			ON tu2.id_turno = rt2.id_turno
		INNER JOIN TOP_4.Receta re2
			ON rt2.id_resultado_turno = re2.id_resultado_turno
		INNER JOIN TOP_4.Bono_Farmacia bf2
			ON bf2.id_receta = re2.id_receta
		WHERE tu2.id_afiliado = af.id_afiliado
	)
	GROUP BY nombre, apellido
	ORDER BY bonos_vencidos DESC
END
GO

CREATE PROCEDURE [TOP_4].[sp_topafiliadosconbonossincomprarporellos]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 2 as id_afiliado,200 as bonos_utilizados
SELECT TOP 10 bonosConsulta.nombre as nombre, bonosConsulta.apellido as apellido, 
	(bonosConsulta.cantBonosAjenosCons + bonosFarmacia.cantBonosAjenosFarm) as bonos_utilizados
FROM
(
	SELECT af.id_afiliado, af.nombre, af.apellido, COUNT(*) as cantBonosAjenosCons
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Turno tu
		ON tu.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Bono_Consulta bc
		ON bc.id_turno = tu.id_turno
	INNER JOIN TOP_4.Compra co
		ON bc.id_compra = co.id_compra
	WHERE co.id_afiliado != af.id_afiliado
	AND tu.fecha_turno BETWEEN @p_desde AND @p_fin
	GROUP BY af.id_afiliado, af.nombre, af.apellido
) bonosConsulta
INNER JOIN
(
	SELECT af.id_afiliado, af.nombre, af.apellido, COUNT(*) as cantBonosAjenosFarm
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Turno tu
		ON tu.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Resultado_Turno rt
		ON rt.id_turno = tu.id_turno
	INNER JOIN TOP_4.Receta re
		ON re.id_resultado_turno = rt.id_resultado_turno
	INNER JOIN TOP_4.Bono_Farmacia bf
		ON bf.id_receta = re.id_receta
	INNER JOIN TOP_4.Compra co
		ON co.id_compra = bf.id_compra
	WHERE co.id_afiliado != af.id_afiliado
	AND tu.fecha_turno BETWEEN @p_desde AND @p_fin
	GROUP BY af.id_afiliado, af.nombre, af.apellido
) bonosFarmacia
ON bonosConsulta.id_afiliado = bonosFarmacia.id_afiliado
ORDER BY bonos_utilizados DESC

END




GO

CREATE PROCEDURE [TOP_4].[sp_topespecialidadesbonosfarmaciarecetados]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
	SELECT TOP 5 esp.nombre as especialidad, COUNT(*) as bonos_farmacia_recetados
	FROM TOP_4.Especialidad esp
	INNER JOIN TOP_4.Profesional_Especialidad pe
		ON pe.id_especialidad = esp.id_especialidad
	INNER JOIN TOP_4.Profesional pro
		ON pro.id_profesional = pe.id_profesional
	INNER JOIN TOP_4.Turno tu
		ON tu.id_profesional = pro.id_profesional
	INNER JOIN TOP_4.Resultado_Turno res
		ON res.id_turno = tu.id_turno
	INNER JOIN TOP_4.Receta rec
		ON rec.id_resultado_turno = res.id_resultado_turno
	INNER JOIN TOP_4.Bono_Farmacia bf
		ON bf.id_receta = rec.id_receta
	WHERE bf.fecha_impresion BETWEEN @p_desde AND @p_fin
	GROUP BY esp.id_especialidad, esp.nombre
	ORDER BY bonos_farmacia_recetados DESC
END

GO
GO
CREATE PROCEDURE [TOP_4].[sp_Agenda_insert](
	@p_id numeric(18) output,
	@p_id_profesional numeric(18),
	@p_fecha_desde datetime,
	@p_fecha_hasta datetime)
AS
BEGIN
INSERT INTO [TOP_4].[Agenda]
           ([id_profesional]
           ,[fecha_desde]
           ,[fecha_hasta])
     VALUES
           (@p_id_profesional
           ,@p_fecha_desde
           ,@p_fecha_hasta)
SET @p_id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [TOP_4].[sp_consultar_agenda_unica](
	@resultado int output,
	@p_id_profesional numeric(18),
	@p_fecha_desde datetime,
	@p_fecha_hasta datetime)
AS
BEGIN
SELECT @resultado = COUNT(*)
FROM Agenda
WHERE Agenda.id_profesional=@p_id_profesional AND
		(@p_fecha_desde BETWEEN Agenda.fecha_desde AND Agenda.fecha_hasta) OR
		(@p_fecha_hasta BETWEEN Agenda.fecha_desde AND Agenda.fecha_hasta) OR
		(Agenda.fecha_desde BETWEEN @p_fecha_desde AND @p_fecha_hasta) OR
		(Agenda.fecha_hasta BETWEEN @p_fecha_desde AND @p_fecha_hasta)
END
GO
GO
CREATE PROCEDURE [TOP_4].[sp_DiaAgenda_insert](
	@p_id numeric(18),
	@p_nro_dia_semana numeric(18),
	@p_nombre_dia_semana varchar(255),
	@p_hora_desde datetime,
	@p_hora_hasta datetime)
AS
BEGIN
INSERT INTO [TOP_4].[Dia_Agenda]
           ([id_agenda]
           ,[nro_dia_semana]
           ,[nombre_dia_semana]
           ,[hora_desde]
           ,[hora_hasta])
     VALUES
           (@p_id
           ,@p_nro_dia_semana
           ,@p_nombre_dia_semana
           ,CONVERT(time(7), @p_hora_desde)
           ,CONVERT(TIME(7), @p_hora_hasta))
END
GO
GO
CREATE PROCEDURE [TOP_4].[sp_Compra_registrar]
(
	@p_id numeric(18) output
	,@p_costo numeric(18)
	,@p_id_afiliado numeric(18)
	,@p_fecha_compra datetime
)
AS
BEGIN
	INSERT INTO [TOP_4].[Compra]
	(id_afiliado, fecha_compra, habilitado, costo)
	VALUES (@p_id_afiliado, @p_fecha_compra, '1', @p_costo)
	
	SET @p_id = SCOPE_IDENTITY()
END
GO


CREATE PROCEDURE [TOP_4].[sp_Compra_bono_consulta]
(
	@p_id numeric(18) output
	,@p_id_compra NUMERIC(18)
	,@p_id_plan_medico NUMERIC(18)
	,@p_fecha_impresion DATETIME
)
AS
BEGIN
	INSERT INTO [TOP_4].[Bono_Consulta]
	(id_compra, id_turno, id_plan_medico, fecha_impresion, habilitado)
	VALUES (@p_id_compra, NULL, @p_id_plan_medico, @p_fecha_impresion, '1')
	
	SET @p_id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [TOP_4].[sp_Compra_bono_farmacia]
(
	@p_id numeric(18) output
	,@p_id_compra NUMERIC(18)
	,@p_id_plan_medico NUMERIC(18)
	,@p_fecha_vencimiento DATETIME
	,@p_fecha_impresion DATETIME
)
AS
BEGIN
	INSERT INTO [TOP_4].[Bono_Farmacia]
	(id_compra, id_plan_medico, id_receta, fecha_vencimiento, fecha_impresion, habilitado)
	VALUES (@p_id_compra, @p_id_plan_medico, null, @p_fecha_vencimiento, @p_fecha_impresion, '1')
	
	SET @p_id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [TOP_4].[sp_BonoConsulta_registrar_llegada]
(
	@p_id_bono numeric(18),
	@p_id_turno numeric(18),
	@p_fecha datetime
)
AS
BEGIN 
	UPDATE [TOP_4].Bono_consulta
	SET id_turno = @p_id_turno
	WHERE id_bono_consulta = @p_id_bono
	
	UPDATE [TOP_4].[Turno]
	SET fecha_llegada = @p_fecha
	WHERE id_turno = @p_id_turno
	
END

GO
CREATE PROCEDURE [TOP_4].[sp_BonoConsulta_select]
(@p_id numeric(18))
AS
BEGIN
	SELECT [id_bono_consulta]
		  ,[id_compra]
		  ,[id_turno]
		  ,[id_plan_medico]
		  ,[fecha_impresion]
		  ,[habilitado]
	 FROM [GD2C2013].[TOP_4].[Bono_Consulta]
	 WHERE id_bono_consulta = @p_id
	 AND id_turno = NULL
	 AND habilitado = '1'
END
GO

GO
CREATE PROCEDURE [TOP_4].[sp_BonoConsulta_validar]
(@p_id numeric(18), @p_nro_principal numeric(18))
AS
BEGIN
        SELECT [id_bono_consulta]
                 ,BC.[id_compra]
                 ,BC.[id_turno]
                 ,BC.[id_plan_medico]
                 ,BC.[fecha_impresion]
                 ,BC.[habilitado]
         FROM [TOP_4].[Bono_Consulta] BC
         INNER JOIN [TOP_4].[Compra] C
         	ON BC.id_compra = C.id_compra
         INNER JOIN [TOP_4].[Afiliado] A
         	ON A.id_afiliado = C.id_afiliado
         WHERE BC.id_bono_consulta = @p_id
         AND BC.id_turno = NULL
         AND BC.habilitado = '1'
         AND C.habilitado = '1'
         AND A.nro_principal = @p_nro_principal
         AND A.habilitado = '1'
         AND A.id_plan_medico = BC.id_plan_medico
END

CREATE PROCEDURE [TOP_4].[sp_BonoFarmacia_select]
(@p_id numeric(18))
AS
BEGIN
	SELECT [id_bono_farmacia]
      ,[id_compra]
      ,[id_plan_medico]
      ,[id_receta]
      ,[fecha_vencimiento]
      ,[fecha_impresion]
      ,[habilitado]
  FROM [GD2C2013].[TOP_4].[Bono_Farmacia]
	 WHERE id_bono_farmacia = @p_id
	 AND [id_receta] = NULL
	 AND habilitado = '1'
END
GO

CREATE PROCEDURE [TOP_4].[sp_BonoFarmacia_validar]
(@p_id_bono numeric(18)
,@p_nro_principal numeric(18)
,@p_fecha datetime)
AS
BEGIN
	SELECT BF.[id_bono_farmacia]
      ,BF.[id_compra]
      ,BF.[id_plan_medico]
      ,BF.[id_receta]
      ,BF.[fecha_vencimiento]
      ,BF.[fecha_impresion]
      ,BF.[habilitado]
  FROM [GD2C2013].[TOP_4].[Bono_Farmacia] BF
  INNER JOIN [TOP_4].Compra C ON BF.id_compra = C.id_compra
  INNER JOIN [TOP_4].Afiliado A ON C.id_afiliado = A.id_afiliado
  WHERE id_bono_farmacia = @p_id_bono
  AND [id_receta] = NULL
  AND [fecha_impresion] <= @p_fecha
  AND BF.habilitado = '1'
  AND A.nro_principal = @p_nro_principal
  AND A.habilitado = '1'
END
GO
CREATE PROCEDURE [TOP_4].[sp_Turno_insert]
(
	@p_id numeric(18) output
	,@p_id_afiliado numeric(18)
	,@p_id_profesional numeric(18)
	,@p_fecha_turno datetime
)
AS
BEGIN

	INSERT INTO [TOP_4].[Turno]
			   ([id_afiliado]
			   ,[id_profesional]
			   ,[fecha_turno]
			   ,[habilitado])
		 VALUES
			   (@p_id_afiliado
			   ,@p_id_profesional
			   ,@p_fecha_turno
			   ,'1')
			   
		SET @p_id = SCOPE_IDENTITY()

END

GO
CREATE PROCEDURE [TOP_4].[sp_ResultadoTurno_insert]
(
	@p_id_turno numeric(18)
	,@p_sintoma varchar(255)
	,@p_diagnostico varchar(255)
	,@p_fecha_diagnostico datetime
)
AS
BEGIN
	INSERT INTO [TOP_4].Resultado_Turno
	(id_turno, sintoma, diagnostico, fecha_diagnostico, habilitado)
	VALUES(@p_id_turno, @p_sintoma, @p_diagnostico, @p_fecha_diagnostico, '1')
END



CREATE PROCEDURE [TOP_4].[sp_dias_disponibles_profesional]
(
	@p_fecha_hoy datetime,
	@p_id_profesional NUMERIC(18,0)
)
AS
BEGIN
	DECLARE @fechaDesde datetime
	SELECT TOP 1 @fechaDesde = ag.fecha_desde
	FROM TOP_4.Agenda ag
	INNER JOIN TOP_4.Profesional pro
		ON pro.id_profesional = ag.id_profesional
	WHERE pro.id_profesional = @p_id_profesional
	AND ag.fecha_hasta <= @p_fecha_hoy
	ORDER BY ag.fecha_desde DESC
	
	IF @fechaDesde > @p_fecha_hoy
	BEGIN
		SELECT TOP 1 ag.fecha_desde as fecha_desde, ag.fecha_hasta as fecha_hasta
		FROM TOP_4.Agenda ag
		INNER JOIN TOP_4.Profesional pro
			ON pro.id_profesional = ag.id_profesional
		WHERE pro.id_profesional = @p_id_profesional
		AND ag.fecha_hasta <= @p_fecha_hoy
		ORDER BY ag.fecha_desde DESC
	END
	ELSE
	BEGIN
		SELECT TOP 1 @p_fecha_hoy as fecha_desde, ag.fecha_hasta as fecha_hasta
		FROM TOP_4.Agenda ag
		INNER JOIN TOP_4.Profesional pro
			ON pro.id_profesional = ag.id_profesional
		WHERE pro.id_profesional = @p_id_profesional
		AND ag.fecha_hasta <= @p_fecha_hoy
		ORDER BY ag.fecha_desde DESC
	END
	
END
GO

CREATE PROCEDURE [TOP_4].[sp_turnos_disponibles_por_dia]
(
	@p_fecha datetime,
	@p_id_profesional NUMERIC(18,0)
)
AS
BEGIN
	CREATE TABLE #tmpTurnos(
		horaInicio time,
		horaFin	time
	)
	DECLARE @horaDesde time
	DECLARE @horaHasta time
	
	SELECT @horaDesde = da.hora_desde, @horaHasta = da.hora_hasta
	FROM TOP_4.Dia_Agenda da
	INNER JOIN TOP_4.Agenda ag
		ON ag.id_agenda = da.id_agenda
	WHERE ag.id_profesional = @p_id_profesional
	AND da.nro_dia_semana = DATEPART(weekday, @p_fecha)
	
	DECLARE @horaActual time
	SET @horaActual = @horaDesde
	
	WHILE @horaActual < @horaHasta
	BEGIN
		IF NOT EXISTS (
			SELECT * 
			FROM TOP_4.Turno tur
			WHERE tur.id_profesional = @p_id_profesional
			AND CAST(tur.fecha_turno as date) = CAST(@p_fecha as date)
			AND CAST(tur.fecha_turno as time) = @horaActual)
		BEGIN
			INSERT INTO #tmpTurnos (horaInicio, horaFin)
			VALUES (@horaActual, DATEADD(minute, 30, @horaActual))
		END
		set @horaActual = DATEADD(minute, 30, @horaActual)
	END
	
	SELECT horaInicio, horaFin FROM #tmpTurnos
	DROP TABLE #tmpTurnos
END 
GO

CREATE PROCEDURE [TOP_4].[sp_turnos_existentes_por_dia]
(
	@p_fecha datetime,
	@p_id_profesional NUMERIC(18,0)
)
AS
BEGIN
	CREATE TABLE #tmpTurnos(
		horaInicio time,
		horaFin	time,
		disponible bit
	)
	DECLARE @horaDesde time
	DECLARE @horaHasta time
	
	SELECT @horaDesde = da.hora_desde, @horaHasta = da.hora_hasta
	FROM TOP_4.Dia_Agenda da
	INNER JOIN TOP_4.Agenda ag
		ON ag.id_agenda = da.id_agenda
	WHERE ag.id_profesional = @p_id_profesional
	AND da.nro_dia_semana = DATEPART(weekday, @p_fecha)
	
	DECLARE @horaActual time
	SET @horaActual = @horaDesde
	
	WHILE @horaActual < @horaHasta
	BEGIN
		IF NOT EXISTS (
			SELECT * 
			FROM TOP_4.Turno tur
			WHERE tur.id_profesional = @p_id_profesional
			AND CAST(tur.fecha_turno as date) = CAST(@p_fecha as date)
			AND CAST(tur.fecha_turno as time) = @horaActual)
		BEGIN
			INSERT INTO #tmpTurnos (horaInicio, horaFin, disponible)
			VALUES (@horaActual, DATEADD(minute, 30, @horaActual), 1)
		END
		ELSE
		BEGIN
			INSERT INTO #tmpTurnos (horaInicio, horaFin, disponible)
			VALUES (@horaActual, DATEADD(minute, 30, @horaActual), 0)
		END
		set @horaActual = DATEADD(minute, 30, @horaActual)
	END
	
	SELECT horaInicio, horaFin FROM #tmpTurnos
	DROP TABLE #tmpTurnos
END 
CREATE PROCEDURE [TOP_4].[sp_Medicamento_filter]
(@p_nombre varchar(255))
AS
BEGIN
	SELECT [id_medicamento]
      ,[nombre]
      ,[habilitado]
	FROM [TOP_4].[Medicamento]
	WHERE ((@p_nombre IS NULL) OR (nombre like '%' + @p_nombre + '%'))
	AND habilitado = '1'

END
GO
CREATE PROCEDURE [TOP_4].[sp_TipoCancelacion_select_all]
AS
BEGIN
	SELECT [id_tipo_cancelacion]
      ,[nombre_tipo_cancelacion]
      ,[habilitado]
	FROM [TOP_4].[Tipo_Cancelacion]
END
