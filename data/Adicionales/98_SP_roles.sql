
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
   FROM [TOP_4].[Rol] R
   INNER JOIN [TOP_4].[Usuario_Rol] UR
	ON R.id_rol = UR.id_rol
   INNER JOIN [TOP_4].[Usuario] U
	ON (UR.id_usuario = U.id_usuario AND U.username = @p_usuario_nombre)
   WHERE R.[habilitado] = '1'
   AND U.[habilitado] = '1'

END
GO
