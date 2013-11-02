CREATE PROCEDURE [TOP_4].[sp_topcancelacionesprofesionales]
	(
	@p_desde datetime,
	@p_fin datetime
	)

AS
BEGIN
SELECT 'ads' as especialidad,1 as cantidad_cancelaciones
END
