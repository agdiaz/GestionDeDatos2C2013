USE [GD2C2013]

DROP TABLE TOP_4.Rol_Funcionalidad
DROP TABLE TOP_4.Funcionalidad
DROP TABLE TOP_4.Usuario_Rol
DROP TABLE TOP_4.Rol
DROP TABLE TOP_4.Dia_Agenda
DROP TABLE TOP_4.Agenda
DROP TABLE TOP_4.Profesional_Especialidad
DROP TABLE TOP_4.Especialidad
DROP TABLE TOP_4.Tipo_especialidad
DROP TABLE TOP_4.Profesional
DROP TABLE TOP_4.Usuario
DROP TABLE TOP_4.Plan_medico

-- Borro funciones y sps:

declare @sql varchar(max)

set @sql = (SELECT 'DROP PROCEDURE [' + routine_schema + '].[' + routine_name + ']; '
from information_schema.routines where routine_schema = 'TOP_4' and routine_type IN ('PROCEDURE', 'FUNCTION')
FOR XML PATH (''))
exec(@sql)
