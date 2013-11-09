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