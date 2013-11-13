GO
CREATE PROCEDURE [TOP_4].[sp_DiaAgenda_insert](
	@p_id numeric(18),
	@p_nro_dia_semana numeric(18),
	@p_nombre_dia_semana varchar(255),
	@p_hora_desde datetime,
	@p_hora_hasta datetime)
AS
BEGIN
INSERT INTO [TOP_4].[Dia_Agenda]
           ([id_agenda]
           ,[nro_dia_semana]
           ,[nombre_dia_semana]
           ,[hora_desde]
           ,[hora_hasta])
     VALUES
           (@p_id
           ,@p_nro_dia_semana
           ,@p_nombre_dia_semana
           ,CONVERT(time(7), @p_hora_desde)
           ,CONVERT(TIME(7), @p_hora_hasta))
END
GO