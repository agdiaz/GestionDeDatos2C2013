GO
CREATE PROCEDURE [TOP_4].[sp_topcancelacionesprofesionales]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
SELECT 'ads' as especialidad,1 as cantidad_cancelaciones
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
SELECT 5 as id_afiliado,100 as bonos_vencidos
END
GO

CREATE PROCEDURE [TOP_4].[sp_topafiliadosconbonossincomprarporellos]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
SELECT 2 as id_afiliado,200 as bonos_utilizados
END

GO

CREATE PROCEDURE [TOP_4].[sp_topespecialidadesbonosfarmaciarecetados]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
SELECT 'zxcv' as especialidad,200 as bonos_farmacia_recetados
END

GO