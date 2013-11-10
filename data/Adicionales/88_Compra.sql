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
	@p_id_compra NUMERIC(18)
	,@p_id_plan_medico NUMERIC(18)
	,@p_fecha_impresion DATETIME
)
AS
BEGIN
	INSERT INTO [TOP_4].[Bono_Consulta]
	(id_compra, id_turno, id_plan_medico, fecha_impresion, habilitado)
	VALUES (@p_id_compra, NULL, @p_id_plan_medico, @p_fecha_impresion, '1')
END
GO

CREATE PROCEDURE [TOP_4].[sp_Compra_bono_farmacia]
(
	@p_id_compra NUMERIC(18)
	,@p_id_plan_medico NUMERIC(18)
	,@p_fecha_vencimiento DATETIME
	,@p_fecha_impresion DATETIME
)
AS
BEGIN
	INSERT INTO [TOP_4].[Bono_Farmacia]
	(id_compra, id_plan_medico, id_receta, fecha_vencimiento, fecha_impresion, habilitado)
	VALUES (@p_id_compra, @p_id_plan_medico, null, @p_fecha_vencimiento, @p_fecha_impresion, '1')
END
GO