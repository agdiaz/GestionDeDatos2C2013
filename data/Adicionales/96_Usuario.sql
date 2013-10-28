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

GO
CREATE PROCEDURE [TOP_4].[sp_Usuario_filter](
	@p_username varchar(255),
	@p_id_rol numeric(18))
AS
BEGIN

SELECT [id_usuario]
      ,[username]
      ,[password]
      ,[cant_intentos_fallidos]
      ,[habilitado]
  FROM [TOP_4].[Usuario] u
  LEFT JOIN [TOP_4].[Usuario_Rol] ur on ur.id_usuario = u.id_usuario
  LEFT JOIN [TOP_4].[Rol] r on r.id_rol = ur.id_rol
  WHERE ((@p_username IS NULL) OR (u.username like '%'+@p_username+'%'))
  AND ((@p_id_rol IS NULL) OR (r.id_rol = @p_id_rol))
  AND u.habilitado = '1'
  AND r.habilitado = '1'
END
GO






