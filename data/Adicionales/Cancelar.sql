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

	UPDATE TOP_4.Bono_Consulta
	SET id_turno = NULL
	WHERE id_turno = @p_id_turno
	
END


GO

GO
CREATE PROCEDURE TOP_4.sp_cancelacion_buscar_turno(
	@p_fecha datetime,
	@p_id_profesional numeric(18)
)

AS
BEGIN

SELECT [id_turno]
      ,[id_afiliado]
      ,[id_profesional]
      ,[fecha_turno]
      ,[fecha_llegada]
      ,[habilitado]
  FROM [GD2C2013].[TOP_4].[Turno]
WHERE id_profesional = @p_id_profesional
AND fecha_turno BETWEEN @p_fecha AND dateadd(minute, 59, dateadd(HOUR, 23, @p_fecha))
AND fecha_llegada IS NULL
AND habilitado = '1'

END
GO