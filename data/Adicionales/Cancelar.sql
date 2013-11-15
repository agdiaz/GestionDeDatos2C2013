CREATE PROCEDURE TOP_4.sp_cancelacion(
	@p_id_tipo_cancelacion numeric(18)
	,@p_id_turno numeric(18)
	,@p_fecha datetime
	,@p_motivo varchar(255)
	,@p_cancelado_por char
)

AS
BEGIN

INSERT INTO [GD2C2013].[TOP_4].[Cancelacion]
           ([id_tipo_cancelacion]
           ,[id_turno]
           ,[fecha]
           ,[cancelado_por]
           ,[motivo]
           ,[habilitado])
     VALUES
           (@p_id_tipo_cancelacion
           ,@p_id_turno
           ,@p_fecha
           ,@p_cancelado_por
           ,@p_motivo
           ,'1')  
END