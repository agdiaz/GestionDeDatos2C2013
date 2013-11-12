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