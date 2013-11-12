
CREATE PROCEDURE [TOP_4].[sp_dias_disponibles_profesional]
(
	@p_fecha_hoy datetime,
	@p_id_profesional NUMERIC(18,0)
)
AS
BEGIN
	DECLARE @fechaDesde datetime
	SELECT TOP 1 @fechaDesde = ag.fecha_desde
	FROM TOP_4.Agenda ag
	INNER JOIN TOP_4.Profesional pro
		ON pro.id_profesional = ag.id_profesional
	WHERE pro.id_profesional = @p_id_profesional
	AND ag.fecha_hasta <= @p_fecha_hoy
	ORDER BY ag.fecha_desde DESC
	
	IF @fechaDesde > @p_fecha_hoy
	BEGIN
		SELECT TOP 1 ag.fecha_desde as fecha_desde, ag.fecha_hasta as fecha_hasta
		FROM TOP_4.Agenda ag
		INNER JOIN TOP_4.Profesional pro
			ON pro.id_profesional = ag.id_profesional
		WHERE pro.id_profesional = @p_id_profesional
		AND ag.fecha_hasta <= @p_fecha_hoy
		ORDER BY ag.fecha_desde DESC
	END
	ELSE
	BEGIN
		SELECT TOP 1 @p_fecha_hoy as fecha_desde, ag.fecha_hasta as fecha_hasta
		FROM TOP_4.Agenda ag
		INNER JOIN TOP_4.Profesional pro
			ON pro.id_profesional = ag.id_profesional
		WHERE pro.id_profesional = @p_id_profesional
		AND ag.fecha_hasta <= @p_fecha_hoy
		ORDER BY ag.fecha_desde DESC
	END
	
END
GO

CREATE PROCEDURE [TOP_4].[sp_turnos_disponibles_por_dia]
(
	@p_fecha datetime,
	@p_id_profesional NUMERIC(18,0)
)
AS
BEGIN
	CREATE TABLE #tmpTurnos(
		horaInicio time,
		horaFin	time
	)
	DECLARE @horaDesde time
	DECLARE @horaHasta time
	
	SELECT @horaDesde = da.hora_desde, @horaHasta = da.hora_hasta
	FROM TOP_4.Dia_Agenda da
	INNER JOIN TOP_4.Agenda ag
		ON ag.id_agenda = da.id_agenda
	WHERE ag.id_profesional = @p_id_profesional
	AND da.nro_dia_semana = DATEPART(weekday, @p_fecha)
	
	DECLARE @horaActual time
	SET @horaActual = @horaDesde
	
	WHILE @horaActual < @horaHasta
	BEGIN
		IF NOT EXISTS (
			SELECT * 
			FROM TOP_4.Turno tur
			WHERE tur.id_profesional = @p_id_profesional
			AND CAST(tur.fecha_turno as date) = CAST(@p_fecha as date)
			AND CAST(tur.fecha_turno as time) = @horaActual)
		BEGIN
			INSERT INTO #tmpTurnos (horaInicio, horaFin)
			VALUES (@horaActual, DATEADD(minute, 30, @horaActual))
		END
		set @horaActual = DATEADD(minute, 30, @horaActual)
	END
	
	SELECT horaInicio, horaFin FROM #tmpTurnos
	DROP TABLE #tmpTurnos
END 