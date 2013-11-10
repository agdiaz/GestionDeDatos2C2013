CREATE PROCEDURE [TOP_4].[sp_Turno_insert]
(
	@p_id numeric(18) output
	,@p_id_afiliado numeric(18)
	,@p_id_profesional numeric(18)
	,@p_fecha_turno datetime
)
AS
BEGIN

	INSERT INTO [TOP_4].[Turno]
			   ([id_afiliado]
			   ,[id_profesional]
			   ,[fecha_turno]
			   ,[habilitado])
		 VALUES
			   (@p_id_afiliado
			   ,@p_id_profesional
			   ,@p_fecha_turno
			   ,'1')
			   
		SET @p_id = SCOPE_IDENTITY()

END

--CREATE PROCEDURE [TOP_4].[sp_turnos_disponibles]
--AS

--BEGIN

--END
--declare @p_id_profesional numeric(18)
--set @p_id_profesional = 7

--SELECT A.id_agenda, A.id_profesional, A.fecha_desde, A.fecha_hasta, DA.nro_dia_semana, Da.Hora_desde, DA.Hora_hasta
--	,T.id_turno, T.fecha_turno 
--FROM TOP_4.Agenda A
--INNER JOIN TOP_4.Dia_Agenda DA 
--	ON DA.id_agenda = A.id_agenda
--LEFT JOIN TOP_4.Turno T
--	ON T.id_profesional = A.id_profesional
--WHERE A.id_profesional = @p_id_profesional
--order by DA.nro_dia_semana