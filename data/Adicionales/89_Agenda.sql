GO
CREATE PROCEDURE [TOP_4].[sp_Agenda_insert](
	@p_id numeric(18) output,
	@p_id_profesional numeric(18),
	@p_fecha_desde datetime,
	@p_fecha_hasta datetime)
AS
BEGIN
INSERT INTO [TOP_4].[Agenda]
           ([id_profesional]
           ,[fecha_desde]
           ,[fecha_hasta])
     VALUES
           (@p_id_profesional
           ,@p_fecha_desde
           ,@p_fecha_hasta)
SET @p_id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [TOP_4].[sp_consultar_agenda_unica](
	@resultado int output,
	@p_id_profesional numeric(18),
	@p_fecha_desde datetime,
	@p_fecha_hasta datetime)
AS
BEGIN
SELECT @resultado = COUNT(*)
FROM Agenda
WHERE Agenda.id_profesional=@p_id_profesional AND
		(@p_fecha_desde BETWEEN Agenda.fecha_desde AND Agenda.fecha_hasta) OR
		(@p_fecha_hasta BETWEEN Agenda.fecha_desde AND Agenda.fecha_hasta) OR
		(Agenda.fecha_desde BETWEEN @p_fecha_desde AND @p_fecha_hasta) OR
		(Agenda.fecha_hasta BETWEEN @p_fecha_desde AND @p_fecha_hasta)
END
GO