CREATE PROCEDURE [TOP_4].[sp_Receta_insert]
(	@p_id numeric(18) output
	,@p_id_resultado_turno numeric(18)
	,@p_id_bono_farmacia numeric(18)
	,@p_fecha datetime
)
AS
BEGIN
INSERT INTO [TOP_4].[Receta]
           ([id_resultado_turno]
           ,[habilitado])
     VALUES
           (@p_id_resultado_turno
           ,'1')

SET @p_id = SCOPE_IDENTITY()

UPDATE [TOP_4].Bono_Farmacia
SET id_receta = @p_id, fecha_prescripcion = @p_fecha
WHERE id_bono_farmacia = @p_id_bono_farmacia
END

GO

CREATE PROCEDURE [TOP_4].[sp_ItemReceta_insert]
(
	@p_id_receta numeric(18)
    ,@p_id_medicamento numeric(18)
    ,@p_cantidad int
)
AS
BEGIN
INSERT INTO [GD2C2013].[TOP_4].[Item_Receta]
           ([id_receta]
           ,[id_medicamento]
           ,[cantidad]
           ,[habilitado])
     VALUES
           (@p_id_receta
           ,@p_id_medicamento
           ,@p_cantidad
           ,'1')
END
GO