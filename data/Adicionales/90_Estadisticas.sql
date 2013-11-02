CREATE PROCEDURE [TOP_4].[sp_topcancelacionesprofesionales]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
SELECT 'ads' as especialidad,1 as cantidad_cancelaciones
END

CREATE PROCEDURE [TOP_4].[sp_topbonosfarmaciavencidosporafiliado]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
SELECT 5 as id_afiliado,100 as bonos_vencidos
END
